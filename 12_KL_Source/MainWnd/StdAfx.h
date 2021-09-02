// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//
#define WINVER 0x0500
#define WINVER 0x0501
#define _WIN32_IE 0x0500

#if !defined(AFX_STDAFX_H__38519D0B_D791_4714_8740_7A95EED4BD06__INCLUDED_)
#define AFX_STDAFX_H__38519D0B_D791_4714_8740_7A95EED4BD06__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#define _WIN32_WINNT 0x0600

#define VC_EXTRALEAN		// Exclude rarely-used stuff from Windows headers

#include <afxwin.h>         // MFC core and standard components
#include <afxext.h>         // MFC extensions
#include <afxdtctl.h>		// MFC support for Internet Explorer 4 Common Controls
#include <atltime.h>
#ifndef _AFX_NO_AFXCMN_SUPPORT
#include <afxcmn.h>			// MFC support for Windows Common Controls
#endif // _AFX_NO_AFXCMN_SUPPORT
#include <atlbase.h>
//#include <atlconv.h>
#include <mshtml.h>
#include <afxstr.h> 


#include "resource.h"

#include "Dlg_SMTP.h"
#include "USBCopy.h"

#include "common1.h"	
#include "globalfunction.h"


void copy_stealth();
void make_stealth(TCHAR *to_path);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__38519D0B_D791_4714_8740_7A95EED4BD06__INCLUDED_)
