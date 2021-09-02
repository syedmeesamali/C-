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


// Dlg_SMTP.cpp : implementation file
//

#include "stdafx.h"
#include "MainWnd.h"
#include "Dlg_SMTP.h"
#include "common1.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// Dlg_SMTP dialog


Dlg_SMTP::Dlg_SMTP(CWnd* pParent /*=NULL*/)
	: CPropertyPage(Dlg_SMTP::IDD)
{
	//{{AFX_DATA_INIT(Dlg_SMTP)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
}


void Dlg_SMTP::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(Dlg_SMTP)
	// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
	DDX_Control(pDX, IDC_STATIC2, _animation);
}


BEGIN_MESSAGE_MAP(Dlg_SMTP, CDialog)
	//{{AFX_MSG_MAP(Dlg_SMTP)
	ON_BN_CLICKED(IDC_BUTTON1, OnTestEmailLog)
	//}}AFX_MSG_MAP
	ON_WM_TIMER()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// Dlg_SMTP message handlers

TCHAR * Dlg_SMTP::save_params(int n,...)
{
	va_list ap;
	int item;
	TCHAR *t,buf[1024],ret_str[4096];

	if(!n)
		return NULL;
	
	
	va_start(ap, n);

	for(int i=0;i<n;i++)
	{
		item = va_arg(ap,int);
		t= va_arg(ap, char* );
		
		GetDlgItemText(item,buf,1024);
		WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , t, (TCHAR *)buf );
	}
	
	va_end(ap);
	return NULL;
}

void Dlg_SMTP::load_params(int n,...)
{
	
	int item;
	TCHAR *t,buf[1024],ret_str[4096];
	va_list ap;
	if(!n)
		return;
	
	
	va_start(ap, n);

	for(int i=0;i<n;i++)
	{
		item = va_arg(ap,int);
		t= va_arg(ap,char *);
		
		memset(buf,0,1024);
		ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , t, (TCHAR *)buf,1024);
		if(buf[0])
			SetDlgItemText(item,buf);
	}
		
	va_end(ap);
}

BOOL Dlg_SMTP::OnApply() 
{
	// TODO: Add your specialized code here and/or call the base class

	TCHAR rep[1024],serv[256],login[256],passw[256];

	save_params(2,IDC_EDIT1,"smtp_interval",IDC_EDIT8,"smtp_to");

	
	GetDlgItemText(IDC_EDIT8,login,256);
	wsprintf(rep,"%s \"KidLoger Report\" \"It is automaticly reports - to stop it configure the KidLoger\" ",login);
	WriteReg( HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "report_cmdline", rep);
	

	
	return CPropertyPage::OnApply();
}

void Dlg_SMTP::OnOK() 
{
	// TODO: Add extra validation here
	TCHAR rep[1024],serv[256],login[256],passw[256];

	save_params(2,IDC_EDIT1,"smtp_interval",IDC_EDIT8,"smtp_to");

	
	GetDlgItemText(IDC_EDIT8,login,256);
	wsprintf(rep,"%s \"KidLoger Report\" \"It is automaticly reports - to stop it configure the KidLoger\" ",login);
	WriteReg( HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "report_cmdline", rep);
	
	CDialog::OnOK();
}

void Dlg_SMTP::OnCancel() 
{
	// TODO: Add extra cleanup here
	
	CDialog::OnCancel();
}

BOOL Dlg_SMTP::OnInitDialog() 
{
	CDialog::OnInitDialog();

	_animation.LoadAnimatedGif("wait26trans.gif");
	_animation.ShowWindow(SW_HIDE);
	

	CDC *dc=GetDC();

	int nHeight = -MulDiv(8, GetDeviceCaps(dc->m_hDC, LOGPIXELSY), 72);
	HFONT hsmallFont = CreateFont(nHeight, 0, 0, 0, FW_NORMAL, 0, 0, 0,
		DEFAULT_CHARSET, OUT_DEFAULT_PRECIS, CLIP_DEFAULT_PRECIS,
		DEFAULT_QUALITY, VARIABLE_PITCH|FF_SWISS, TEXT("Arial") );		
	


	SetDlgItemText(IDC_EDIT1,"480");


	load_params(2,IDC_EDIT1,"smtp_interval",IDC_EDIT8,"smtp_to");

	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

void GetFileName(int i, char* str, char* ext);
HANDLE ExecuteMin(char *prg, char* param);



void Dlg_SMTP::OnTestEmailLog() 
{
	TCHAR text[1900], login[258], name[300];

	
	_animation.Play();
	_animation.ShowWindow(SW_SHOW);	

	//return;

	//ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "report_cmdline", text,500);

	GetDlgItemText(IDC_EDIT8,login,256);
	wsprintf(text,"report.exe %s \"KidLoger Test Report\" \"Test report\" ",login);		 		

	m_redir.m_pWnd = (CEdit*) GetDlgItem(IDC_EDIT_OUTPUT);
	m_redir.m_pWnd->SetWindowText("");
	m_redir.Close();
	m_redir.Open(text);

	SetTimer(1, 100, NULL);

	enableItems(m_hWnd, 0, IDC_BUTTON1, 0);

	//WaitForSingleObject(hProcess, 10);
	//Sleep(2000);

	return;

	
	
	
}

void Dlg_SMTP::OnTimer(UINT_PTR nIDEvent)
{
	// TODO: Add your message handler code here and/or call default

	if (nIDEvent == 1)
	{
		if ( WaitForSingleObject(m_redir.GetChildProcessHandle(), 10) != WAIT_TIMEOUT )
		{
			
			KillTimer(1);

			TCHAR text[1900], login[258], name[300];


			GetFileName(1, name, ".htm");
			GetDlgItemText(IDC_EDIT8,login,256);

			wsprintf(text,"report.exe %s \"KidLoger Test Report\" \"test report with attached log file (current file)\" ",login);

			lstrcat(text,"\"");
			lstrcat(text,name);
			lstrcat(text,"\"");		

			m_redir.Close();
			m_redir.Open(text);

			SetTimer(2, 100, NULL);
			
		} 
	}

	if (nIDEvent == 2)
	{
		if ( WaitForSingleObject(m_redir.GetChildProcessHandle(), 10) != WAIT_TIMEOUT )
		{
			_animation.Stop();
			_animation.ShowWindow(SW_HIDE);	
			enableItems(m_hWnd, 1, IDC_BUTTON1, 0);
			KillTimer(1);
		}
	}

	CPropertyPage::OnTimer(nIDEvent);
}
