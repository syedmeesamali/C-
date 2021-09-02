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
** See http://www.rohos.com/kid-logger/ for GPL licensing information.
**
** Contact info@rohos.com if any conditions of this licensing are
** not clear to you.
**
**********************************************************************/



// Dlg_SafeLogReader.cpp : implementation file
//

#include "stdafx.h"
#include "MainWnd.h"
#include "Dlg_SafeLogReader.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDlg_SafeLogReader dialog


CDlg_SafeLogReader::CDlg_SafeLogReader(CWnd* pParent /*=NULL*/)
	: CDialog(CDlg_SafeLogReader::IDD, pParent)
{
	//{{AFX_DATA_INIT(CDlg_SafeLogReader)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT

	strcpy(defaultKey,"abcdefghabcdefgh1234567812345678");
	strcpy(key,defaultKey);
	testString	= _T("TESTLOG");
	_tcscpy(logDir,_T(""));
	
	m_bCursorOn = false;

	oRijndael.MakeKey(key,CRijndael::sm_chain0,32,16);

}


void CDlg_SafeLogReader::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CDlg_SafeLogReader)
	DDX_Control(pDX, IDC_SHOWALL, m_showall);
	DDX_Control(pDX, IDC_LOGVIEW, m_logview);
	DDX_Control(pDX, IDC_CLEAR, m_clear);
	DDX_Control(pDX, IDC_COMBO1, m_Files);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CDlg_SafeLogReader, CDialog)
	//{{AFX_MSG_MAP(CDlg_SafeLogReader)
	ON_CBN_SELCHANGE(IDC_COMBO1, OnSelchangeCombo1)
	ON_BN_CLICKED(IDC_SHOWALL, OnShowall)
	ON_WM_SETCURSOR()
	ON_BN_CLICKED(IDC_CLEAR, OnClear)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDlg_SafeLogReader message handlers

BOOL CDlg_SafeLogReader::OnInitDialog() 
{
	

	CDialog::OnInitDialog();	
	
	//Получаем пароль из реестра
	GetPassword();
	//Устанавливаем папку с логами
	//setLogDir(_T("C:\\")); 

	AfxGetApp()->BeginWaitCursor();
	//Заполняем комбобокс
	FillComboBox();
	AfxGetApp()->EndWaitCursor();

	//Если есть хоть один лог - делаем доступными эл-ты управления
	EnableControls(m_Files.GetCount()!=0);

	
	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}


void CDlg_SafeLogReader::FillComboBox()
{
	
	WIN32_FIND_DATA FindFileData;
	HANDLE			hFind;
	CString			text;
	TCHAR			filePath[500+1];

	_tcscpy(filePath,logDir);
	_tcscat(filePath,_T("\\*"));

	
	m_Files.Clear();
	logFiles.RemoveAll();
	timeFiles.RemoveAll();

	hFind = FindFirstFile(filePath,&FindFileData);
	
	if(hFind!=INVALID_HANDLE_VALUE)
	do {
		if(FindFileData.dwFileAttributes ^ FILE_ATTRIBUTE_DIRECTORY)	//Пропускаем директории
		{
			//text.Format(_T("%s (%d байт)"),FindFileData.cFileName,FindFileData.nFileSizeLow);

			if(isLog(FindFileData.cFileName))
			{
				time_t st;
				st = FILEFileTimeToUnixTime(FindFileData.ftLastWriteTime,NULL);
				timeFiles.Add(st);
				logFiles.Add(FindFileData.cFileName);
			}
		}
		
	} while (FindNextFile(hFind,&FindFileData)!=0);
	
	FindClose(hFind);

	SortByTime();
	
	if(logFiles.GetSize() > 0)
	{
		for(int i=0;i<logFiles.GetSize();i++)
			m_Files.AddString(logFiles.GetAt(i));
		m_Files.SetCurSel(0);
		ReadLog((TCHAR*)(LPCTSTR)logFiles.GetAt(0));
	}

	

	UpdateData(TRUE);
}

void CDlg_SafeLogReader::EnableControls(bool isEnable)
{
	m_showall.EnableWindow(isEnable);
	m_Files.EnableWindow(isEnable);
	m_clear.EnableWindow(isEnable);
	m_logview.EnableWindow(isEnable);
}

bool CDlg_SafeLogReader::ReadLog(TCHAR *file)
{
	CString contents = "";

	bool result = ReadLog(file,contents);

	m_logview.SetWindowText(contents);

	return result;
}

void CDlg_SafeLogReader::ReadAll()
{
	CString contents = "";
	CString temp;
	//Меняем курсор
	m_bCursorOn = true;

	for(int i = 0; i< logFiles.GetSize(); i++)
	{
		if (ReadLog((TCHAR*)(LPCTSTR)logFiles.GetAt(i),temp))
		{
			contents+="--------------------"+logFiles.GetAt(i)+"--------------------\r\n";
			contents+=temp;
		}
	}
	m_logview.SetWindowText(contents);

	//Возвращаем старый курсор
	m_bCursorOn = false;


}

bool CDlg_SafeLogReader::ReadLog(TCHAR *file,CString &contents)
{
	HANDLE hFile;
	char bufIn[18];
	char bufOut[18];
	DWORD count;
	contents = "";

	TCHAR filePath[500+1];

	//Формируем имя файла
	_tcscpy(filePath,logDir);
	_tcscat(filePath,_T("\\"));
	_tcscat(filePath,file);


	hFile = CreateFile(filePath,GENERIC_READ,FILE_SHARE_WRITE | FILE_SHARE_READ,NULL,OPEN_EXISTING,FILE_ATTRIBUTE_ARCHIVE,NULL);
	if(hFile == INVALID_HANDLE_VALUE)
		return false;
	//Читаем первые 16 байт и сверяемся с тестовой строкой
	if (ReadFile(hFile,bufIn,16,&count,NULL) && count == 16)
	{
		oRijndael.Decrypt(bufIn,bufOut,16);
		//Сверяемся с тестовой строкой
		if(_tcscmp((TCHAR *)bufOut,testString))
		{
			CloseHandle(hFile);
			return false;
		}
		//Все ОК - читаем строки
		do {
			if(ReadFile(hFile,bufIn,16,&count,NULL) && count == 16)
			{
				oRijndael.Decrypt(bufIn,bufOut,16);
				//закрываем строку нулем
				bufOut[16]='\0';
				bufOut[17]='\0';
				
				contents+=(TCHAR *)bufOut;
				if(bufOut[15]=='\0' && (sizeof(TCHAR)==1 || bufOut[14]=='\0'))
					contents+=_T("\r\n");
				

			}
		} while(count == 16);
	}
	else
	{
		CloseHandle(hFile);
		return false;
	}
	CloseHandle(hFile);
	return true;
}

void CDlg_SafeLogReader::GetPassword()
{
	HKEY hKey;
	DWORD size = 33;
	char temp[33];
	memset(temp,0,33);

	TCHAR str[106];
	ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Explorer\\tkl") , "Tesl_key0", str, 100);

	memset(key,0,33);
	memcpy(key,str,strlen(str));
			
	oRijndael.MakeKey(key, CRijndael::sm_chain0,32,16);
	
	
}

bool CDlg_SafeLogReader::isLog(TCHAR *file)
{
	HANDLE	hFile;
	char	bufIn[17];
	char	bufOut[17];
	DWORD	count;
	bool	result; 

	TCHAR filePath[500+1];

	//Формируем имя файла
	_tcscpy(filePath,logDir);
	_tcscat(filePath,_T("\\"));
	_tcscat(filePath,file);



	hFile = CreateFile(filePath,GENERIC_READ,FILE_SHARE_WRITE | FILE_SHARE_READ,NULL,OPEN_EXISTING,FILE_ATTRIBUTE_ARCHIVE,NULL);
	if(hFile == INVALID_HANDLE_VALUE)
		return false;
	result = false;
	//Читаем первые 16 байт и сверяемся с тестовой строкой
	if (ReadFile(hFile,bufIn,16,&count,NULL) && count == 16)
	{
		oRijndael.Decrypt(bufIn,bufOut,16);
		//Сверяемся с тестовой строкой
		if(!_tcscmp((TCHAR *)bufOut,testString))
			result = true;
	}
	CloseHandle(hFile);
	return result; 
}

void CDlg_SafeLogReader::setLogDir(TCHAR *dir)
{
	_tcscpy(logDir,dir);
}




void CDlg_SafeLogReader::OnSelchangeCombo1() 
{
	ReadLog((TCHAR*)(LPCTSTR)logFiles.GetAt(m_Files.GetCurSel()));
}

void CDlg_SafeLogReader::OnShowall() 
{
	ReadAll();	
}

BOOL CDlg_SafeLogReader::OnSetCursor(CWnd* pWnd, UINT nHitTest, UINT message) 
{
    if(m_bCursorOn)
    {
            ::SetCursor(AfxGetApp()->LoadStandardCursor(IDC_WAIT));
            return 1;
    }	
	
	return CDialog::OnSetCursor(pWnd, nHitTest, message);
}

void CDlg_SafeLogReader::SortByTime()
{
	DWORD tempTime;
	CString tempLog;
	for(int i=0;i<timeFiles.GetSize();i++)
	{
		for(int j=0;j<timeFiles.GetSize()-i-1; j++)
			if((LONG)timeFiles.GetAt(j)<(LONG)timeFiles.GetAt(j+1))
			{
				tempTime = timeFiles.GetAt(j);
				timeFiles.SetAt(j,timeFiles.GetAt(j+1));
				timeFiles.SetAt(j+1,tempTime);

				tempLog = logFiles.GetAt(j);
				logFiles.SetAt(j,logFiles.GetAt(j+1));
				logFiles.SetAt(j+1,tempLog);
			}
	}

}


void CDlg_SafeLogReader::ClearLog(TCHAR *file)
{
	HANDLE hFile;
	char bufIn[18];
	char bufOut[18];
	DWORD count;

	TCHAR filePath[500+1];

	FILETIME ft;

	//Формируем имя файла
	_tcscpy(filePath,logDir);
	_tcscat(filePath,_T("\\"));
	_tcscat(filePath,file);


	hFile = CreateFile(filePath,GENERIC_READ | GENERIC_WRITE ,FILE_SHARE_WRITE | FILE_SHARE_READ,NULL,OPEN_EXISTING,FILE_ATTRIBUTE_ARCHIVE,NULL);
	if(hFile == INVALID_HANDLE_VALUE)
		return;
	//Получаем время изменения файла
	GetFileTime(hFile,NULL,NULL,&ft);

	//Читаем первые 16 байт и сверяемся с тестовой строкой
	if (ReadFile(hFile,bufIn,16,&count,NULL) && count == 16)
	{
		oRijndael.Decrypt(bufIn,bufOut,16);
		//Сверяемся с тестовой строкой
		if(_tcscmp((TCHAR *)bufOut,testString))
		{
			CloseHandle(hFile);
			DeleteFile(file);
			return;
		}
		//Все ОК - усекаем файл
		SetEndOfFile(hFile);
		//Восстанавливаем время изменения
		SetFileTime(hFile,NULL,NULL,&ft);

	}
	else
	{
		CloseHandle(hFile);
		DeleteFile(file);
		return;
	}
	CloseHandle(hFile);
	return;
	
}

void CDlg_SafeLogReader::OnClear() 
{
	ClearLog((TCHAR*)(LPCTSTR)logFiles.GetAt(m_Files.GetCurSel()));	
	ReadLog((TCHAR*)(LPCTSTR)logFiles.GetAt(m_Files.GetCurSel()));
}


time_t CDlg_SafeLogReader::FILEFileTimeToUnixTime( FILETIME FileTime, long *nsec )
{
	__int64 UnixTime;
	static const __int64 SECS_BETWEEN_EPOCHS = 11644473600;
	static const __int64 SECS_TO_100NS = 10000000; /* 10^7 */

	/* get the full win32 value, in 100ns */
	UnixTime = ((__int64)FileTime.dwHighDateTime << 32) + 
	FileTime.dwLowDateTime;
 
	/* convert to the Unix epoch */
	UnixTime -= (SECS_BETWEEN_EPOCHS * SECS_TO_100NS);

	if ( nsec )
	{
		/* get the number of 100ns, convert to ns */
		*nsec = (UnixTime % SECS_TO_100NS) * 100;
	}
  
	UnixTime /= SECS_TO_100NS; /* now convert to seconds */
 

	return (time_t)UnixTime;
}