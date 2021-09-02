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


// USBCopy.cpp : implementation file
//

#include "stdafx.h"
#include "MainWnd.h"
#include "USBCopy.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif
CListBox lbox;
/////////////////////////////////////////////////////////////////////////////
// USBCopy dialog


USBCopy::USBCopy(CWnd* pParent /*=NULL*/)
	: CDialog(USBCopy::IDD, pParent)
{
	//{{AFX_DATA_INIT(USBCopy)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
}


void USBCopy::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(USBCopy)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(USBCopy, CDialog)
	//{{AFX_MSG_MAP(USBCopy)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// USBCopy message handlers

void USBCopy::OnOK() 
{

	
	//make_stealth("c:\\stealth");
	TCHAR buf[1024],*t;
	
	lbox.GetText(lbox.GetCurSel(),buf);
	t = strstr(buf,"\\");
	if(t)
	{
		t++;
		(*t)=0;
	}

	make_stealth(buf);
	CDialog::OnOK();
}

void USBCopy::OnCancel() 
{
	
	CDialog::OnCancel();
}

BOOL USBCopy::OnInitDialog() 
{
	CDialog::OnInitDialog();
	TCHAR buf[256],lbl[256],fsn[256];
	int i;
	CString ret;
	DWORD sn,mcl,fsys;
	HWND wnd;

	GetDlgItem(IDC_USB_DRIVES,&wnd);
	lbox.Attach(wnd);
	GetLogicalDriveStrings(256,buf);
	i=0;
	lbox.ResetContent();
	while(buf[i] && buf[i+1])
	{
		//GetDriveType(buf+i);
		if(buf[i]!='A' && buf[i]!='B')
		{
			sn=mcl=fsys=0;
			memset(lbl,0,256);
			GetVolumeInformation(buf+i,lbl,256,&sn,&mcl,&fsys,fsn,256);
			ret = CString(buf+i);
			if((*lbl))
				ret+=" ["+CString(lbl)+"]";
			lbox.InsertString(-1,ret);
		}

		i+=lstrlen(buf)+1;
	}
	
	return TRUE; 
}
