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


#include "stdafx.h"
#include "MainWnd.h"
#include "MainWndDlg.h"
#include "Dlg_pass.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#include <eh.h>


void SeTranslator(UINT nSeCode, _EXCEPTION_POINTERS* pExcPointers)
{
	
	MessageBox(0,  "Application performed an illegal operation and will be closed.", "Application",MB_ICONWARNING);

	terminate();
	
}


/////////////////////////////////////////////////////////////////////////////
// CMainWndApp

BEGIN_MESSAGE_MAP(CMainWndApp, CWinApp)
	//{{AFX_MSG_MAP(CMainWndApp)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMainWndApp construction

CMainWndApp::CMainWndApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CMainWndApp object

CMainWndApp theApp;
HINSTANCE h_lang;

/////////////////////////////////////////////////////////////////////////////
// CMainWndApp initialization

void set_foreground(HWND hWnd)
{
	HWND hCurrWnd;
	int iMyTID;
	int iCurrTID;
	
	hCurrWnd = ::GetForegroundWindow();
	iMyTID   = GetCurrentThreadId();
	iCurrTID = GetWindowThreadProcessId(hCurrWnd,0);
	
	AttachThreadInput(iMyTID, iCurrTID, TRUE);
	
	// hWnd - дескриптор окна.
	SetForegroundWindow(hWnd);
	BringWindowToTop(hWnd);
    
	AttachThreadInput(iMyTID, iCurrTID, FALSE);	
}


BOOL CMainWndApp::InitInstance()
{

	//CMainWndDlg dlg;

	_set_se_translator(SeTranslator);

	CoInitialize(NULL);
	
	HINSTANCE hInstOLEACC = ::LoadLibrary( _T("OLEACC.DLL") );
	
	
	pfObjectFromLresult = (LPFNOBJECTFROMLRESULT)::GetProcAddress( hInstOLEACC, _T("ObjectFromLresult") );
		
	

	// Standard initialization
	// If you are not using these features and wish to reduce the size
	//  of your final executable, you should remove from the following
	//  the specific initialization routines you do not need.

	// создание окна
	pDlg = new CMainWndDlg();
	pDlg->_start_in_reg_mode = 0;
	if ( strlen(m_lpCmdLine) ) 
	{
		if( FindWindow(NULL, "Control panel  [--]"))
			ExitProcess(0);
			
		if(!strcmp(m_lpCmdLine,"/stealth"))
		{
			copy_stealth();
			ExitProcess(1);
			
		}

		if(!strcmp(m_lpCmdLine,"/init"))
		{
			pDlg->_start_in_reg_mode = 1;
			Sleep(30000);
			
		}

		

		pDlg->_start_minimized = true;


	} else {

		// check password if there is.
		CDlg_pass dlg;
		if ( dlg.DoModal() != IDOK)
			return false;

		HWND wnd = FindWindow(NULL, "Control panel  [--]");
		if (wnd) {
			ShowWindow(wnd, SW_SHOW);
			ShowWindow(wnd, SW_RESTORE);
			set_foreground(wnd);
			return false;
		}		
	}



	m_pMainWnd = pDlg;
	pDlg->Create(IDD_MAINWND_DIALOG);	

	return TRUE; // start the application's message pump
}

int CMainWndApp::ExitInstance() 
{
	CoUninitialize();	
	return CWinApp::ExitInstance();
}



void CMainWndApp::ReloadConfig()
{

}
