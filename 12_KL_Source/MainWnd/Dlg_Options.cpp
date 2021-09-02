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
#include "Dlg_Options.h"
#include "Dlg_pass.h"

#include "common1.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDlg_Options dialog


CDlg_Options::CDlg_Options(CWnd* pParent /*=NULL*/)
	: CPropertyPage(CDlg_Options::IDD)
{	

	//{{AFX_DATA_INIT(CDlg_Options)
	_enable_password = FALSE;
	_safe_logger = FALSE;
	_log_clipboard = FALSE;
	_password = _T("");
	_confirmation = _T("");
	_loffiles_path = _T("");
	_usb_monitor = FALSE;
	_log_keystrokes = FALSE;
	//}}AFX_DATA_INIT

	TCHAR str[806];
	ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Explorer") , "Tesl_key0", str, 100);

	if ( _tcslen(str) ) {
		_enable_password = TRUE;
		_password = str;
		_confirmation = str;
	}

	
	
	_usb_monitor = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "UsbMonitor", 0);
	_safe_logger = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "SafeLogger", 0);
	_log_clipboard = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogClipboard", 0);
	_log_keystrokes = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogKeyStrokes", 1);
	
	_loffiles_path = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogFilesPath", str, 600);
	if ( _tcslen(_loffiles_path)==0){
		GetMyPath(str, false, NULL);
		_loffiles_path = str;
	}

	
}


void CDlg_Options::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CDlg_Options)
	DDX_Check(pDX, IDC_CHECK2, _enable_password);
	DDX_Check(pDX, IDC_CHECK4, _safe_logger);
	DDX_Check(pDX, IDC_CHECK5, _log_clipboard);
	DDX_Text(pDX, IDC_EDIT2, _password);
	DDX_Text(pDX, IDC_EDIT3, _confirmation);
	DDX_Text(pDX, IDC_EDIT4, _loffiles_path);
	DDX_Check(pDX, IDC_CHECK3, _usb_monitor);
	DDX_Check(pDX, IDC_CHECK7, _log_keystrokes);
	//}}AFX_DATA_MAP

	enableItems(m_hWnd, _enable_password, IDC_STATIC4, IDC_STATIC5, IDC_EDIT2, IDC_EDIT3, 0);		
	
}


BEGIN_MESSAGE_MAP(CDlg_Options, CDialog)
	//{{AFX_MSG_MAP(CDlg_Options)
	ON_BN_CLICKED(IDC_BUTTON1, OnPassword)
	ON_BN_CLICKED(IDC_CHECK2, OnCheckEnablePassword)
	ON_BN_CLICKED(IDC_CHECK1, OnCheckEnableCapturer)
	ON_BN_CLICKED(IDC_BUTTON5, OnBrowse)
	ON_BN_CLICKED(IDC_STATIC8, OnHide)
	ON_BN_CLICKED(IDC_OPT_SMTP, OnOptSmtp)
	ON_WM_CTLCOLOR()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDlg_Options message handlers

void CDlg_Options::OnPassword() 
{
	CDlg_pass dlg;

	dlg.DoModal();
	
}

void CDlg_Options::OnOK() 
{	
	CString old_password = _password;

	UpdateData();	

	if ( _enable_password) {		

		if (_password.IsEmpty() ) {
			AfxMessageBox("The password could not be empty.", MB_ICONWARNING);
			return;
		}
		if (_password != _confirmation) {
			AfxMessageBox("The password does not match with the confirmation.", MB_ICONWARNING);
			return;
		}

		WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Explorer\\tkl") , "Tesl_key0",  _password);

		TCHAR str[106];
		ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Explorer\\tkl") , "Tesl_key0", str, 100);

		if (_password != str) {
			AfxMessageBox("Could not save password.\n\nPlease note: This operation requires Admin priveleges.", MB_ICONWARNING);
			return;
		}

		if (_safe_logger && old_password != _password) {

			AfxMessageBox("Please restart your computer in order to apply new encryption password. ", MB_ICONINFORMATION);

			if (_password.GetLength() ==0) 
				WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\Kidlogger") , "Key",  NULL, 0);

		}

	} else
		WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Explorer") , "Tesl_key0",  (LPCTSTR)NULL);




	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "UsbMonitor", (DWORD)_usb_monitor );

	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "SafeLogger", (DWORD)_safe_logger);

	
	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogClipboard", (DWORD)_log_clipboard); 
	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogKeyStrokes", (DWORD)_log_keystrokes); 

	WriteReg( HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogFilesPath", _loffiles_path);

	CDialog::OnOK();
}

void CDlg_Options::OnCheckEnablePassword() 
{
	UpdateData();	
	
}

void CDlg_Options::OnCheckEnableCapturer() 
{
	UpdateData();	
}

BOOL CDlg_Options::OnInitDialog() 
{
	CDialog::OnInitDialog();

	CDC *dc = GetDC();
	int nHeight = -MulDiv(8, GetDeviceCaps(dc->m_hDC, LOGPIXELSY), 72);
	HFONT hBoldFont = CreateFont(nHeight, 0, 0, 0, FW_BOLD, 0, 0, 0,
		DEFAULT_CHARSET, OUT_DEFAULT_PRECIS, CLIP_DEFAULT_PRECIS,
		DEFAULT_QUALITY, VARIABLE_PITCH|FF_SWISS, TEXT("MS Shell Dlg") );		

	SendDlgItemMessage( IDC_CHECK1, WM_SETFONT , (WPARAM)hBoldFont, MAKELPARAM(1,0) );
	SendDlgItemMessage( IDC_CHECK2, WM_SETFONT , (WPARAM)hBoldFont, MAKELPARAM(1,0) );
	SendDlgItemMessage( IDC_CHECK3, WM_SETFONT , (WPARAM)hBoldFont, MAKELPARAM(1,0) );
	
	//SendDlgItemMessage( IDC_OPT_SMTP, WM_SETFONT , (WPARAM)hBoldFont, MAKELPARAM(1,0) );
	
	nHeight = -MulDiv(8, GetDeviceCaps(dc->m_hDC, LOGPIXELSY), 72);
	hBoldFont = CreateFont(nHeight, 0, 0, 0, FW_NORMAL, 0, 1, 0,
		DEFAULT_CHARSET, OUT_DEFAULT_PRECIS, CLIP_DEFAULT_PRECIS,
		DEFAULT_QUALITY, VARIABLE_PITCH|FF_SWISS, TEXT("MS Shell Dlg") );		

	SendDlgItemMessage( IDC_OPT_SMTP, WM_SETFONT , (WPARAM)hBoldFont, MAKELPARAM(1,0) );
	SendDlgItemMessage( IDC_OPT_USB, WM_SETFONT , (WPARAM)hBoldFont, MAKELPARAM(1,0) );

	SetClassLong( GetDlgItem(IDC_OPT_SMTP)->m_hWnd, GCL_HCURSOR, (LONG)LoadCursor(NULL,IDC_HAND) );
	CreateToolTip( m_hWnd, IDC_OPT_SMTP, "Configure intervals, mail options of mail sender", 300, 0);

//	SetClassLong( GetDlgItem(IDC_OPT_USB)->m_hWnd, GCL_HCURSOR, (LONG)LoadCursor(NULL,IDC_HAND) );
//	CreateToolTip( m_hWnd, IDC_OPT_USB, "Make a mobile version of KidLoger ( Copying it into a flash drive a make's autorun )", 300, 0);

	nHeight = -MulDiv(7, GetDeviceCaps(dc->m_hDC, LOGPIXELSY), 72);
	HFONT hsmallFont = CreateFont(nHeight, 0, 0, 0, FW_NORMAL, 0, 0, 0,
		DEFAULT_CHARSET, OUT_DEFAULT_PRECIS, CLIP_DEFAULT_PRECIS,
		DEFAULT_QUALITY, VARIABLE_PITCH|FF_SWISS, TEXT("Arial") );		
	

	SendDlgItemMessage( IDC_STATIC9, WM_SETFONT , (WPARAM)hsmallFont, MAKELPARAM(1,0) );
	

	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

void CDlg_Options::OnBrowse() 
{
	TCHAR path[700];
	if ( SelectFolderDialog(m_hWnd, "Select folder where log files should be stored", path, 0, 0) ) {
		_loffiles_path = path;
		_loffiles_path += "\\";
		UpdateData(false);
	}


	
}

void CDlg_Options::OnHide() 
{

	//WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Teslain KidLogger_is1") , "EnableCapturer", (DWORD)_capturer_works );
	
}

void CDlg_Options::OnOptSmtp() 
{
	// TODO: Add your control notification handler code here
	Dlg_SMTP dlg;

	dlg.DoModal();
}

HBRUSH CDlg_Options::OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor) 
{
	HBRUSH hbr = CDialog::OnCtlColor(pDC, pWnd, nCtlColor);
	
	int id = pWnd->GetDlgCtrlID();

	if (nCtlColor == CTLCOLOR_STATIC ) {		
		if (id == IDC_OPT_SMTP || id == IDC_OPT_USB)
			pDC->SetTextColor( RGB(0,0,228) );			
	}
	return hbr;
}
