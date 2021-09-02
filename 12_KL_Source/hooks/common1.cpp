/**********************************************************************
** Copyright (C) 1998-2010 Tesline-Service S.R.L.  All rights reserved.
**
** KidLogger
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


#define WINVER 0x0500
#define _WIN32_IE 0x0500
#include <windows.h>

#include <stdio.h>

#include "TCHAR.H"

#include <shlobj.h>
#include <Shlwapi.h>
#include <io.h>

#include "common1.h"





/** return path with \\
*/
void GetMyPath(LPTSTR path, int include_name, HMODULE handle)
{
    GetModuleFileName(handle, path, MAX_PATH);
	if ( include_name != 0 ) return;

    LPTSTR ch = _tcsrchr(path, '\\');
    if ( ch ) *(ch+1) = 0;
}





void enableItems(HWND parent, bool en, ...)
{
	va_list ap;
	int item;
	va_start(ap, en);

	while ((item= va_arg(ap,int)) != 0)	
	{
		//if (item!=1)
		EnableWindow( GetDlgItem(parent,item), en);
	}
		
	va_end(ap);
}

/** показать / скрыть контролы у окна
\param show = 0, 1

*/
void showItems(HWND parent, int show, ...)
{
	va_list ap;
	int item;
	va_start(ap, show);

	while ((item= va_arg(ap,int)) != 0)			
		ShowWindow( GetDlgItem(parent, item), show);
		
	va_end(ap);
}


/** read a global setting from registry (at User)
params - none
key, HKEY_LOCAL_MACHINE, HKEY_CURRENT_USER
*/
LPCTSTR ReadReg(HKEY key, LPCTSTR path, LPCTSTR val_name, LPTSTR ret_value, DWORD buff_len) 
{	
	HKEY hKey;
	
	if (!ret_value) return 0;
		
	if( RegOpenKeyEx(key, path, 0, KEY_QUERY_VALUE, &hKey)) 
		if ( RegCreateKey(key, path, &hKey) )
		{
			// read/write HKCU if there is no access rights
			RegOpenKeyEx(HKEY_CURRENT_USER, path, 0, KEY_QUERY_VALUE, &hKey);
		}
	
	buff_len = (buff_len-1) * sizeof(TCHAR);
	memset(ret_value, 0, buff_len);
	buff_len -= 2;
	DWORD type = REG_SZ;	
	
	LONG ret = RegQueryValueEx(hKey, val_name, NULL, &type, (LPBYTE)ret_value, &buff_len);
	
	if(ERROR_SUCCESS !=ret 	){			
		
	}	else

	ret_value[buff_len]=0;
	ret_value[buff_len+1]=0;
	
	RegCloseKey(hKey);

	return ret_value;
}




/** read a global setting from registry (at User)
params - none
*/
DWORD ReadReg(HKEY key, LPCTSTR path, LPCTSTR val_name, DWORD i) 
{	
	HKEY hKey;
	DWORD len, val[3]={0};
	DWORD type=0;
	
	if( RegOpenKeyEx(key, path, 0, KEY_QUERY_VALUE, &hKey)) 
		if ( RegCreateKey(key, path, &hKey) )
		{
			// read/write HKCU if there is no access rights
			RegOpenKeyEx(HKEY_CURRENT_USER, path, 0, KEY_QUERY_VALUE, &hKey);
		}
	
	len = sizeof(DWORD)+1;
	LONG ret = RegQueryValueEx(hKey, val_name, NULL, &type, (LPBYTE)&val, &len);
	if ( ERROR_SUCCESS != ret) {
		
		val[0] = i;
	}

	if (type==REG_SZ) { // это "0" или "1"
		int i=0;
		if ( _tcslen((LPCTSTR)val) )
			i = _ttoi( (LPCTSTR)val);
		val[0] = i;
	}
		
	RegCloseKey(hKey);

	return val[0];
}


/** write a local setting from registry (at User)
params - none
*/
DWORD ReadReg(HKEY key, LPCTSTR path, LPCTSTR val_name, LPBYTE value, LPDWORD len) 
{
	
	HKEY hKey;
	LONG ret;
	DWORD type = REG_BINARY;
		
	if( RegOpenKeyEx(key, path, 0, KEY_QUERY_VALUE, &hKey)) 
		if ( RegCreateKey(key, path, &hKey) )
		{
			// read/write HKCU if there is no access rights
			RegOpenKeyEx(HKEY_CURRENT_USER, path, 0, KEY_QUERY_VALUE, &hKey);
		}

	if (!value && len) {		
		ret = RegQueryValueEx(hKey, val_name, 0, &type, NULL, len);
	}
	else {		
		ret = RegQueryValueEx(hKey, val_name, 0, &type, value, len);
		if ( ERROR_SUCCESS != ret) {		
			*len=0;
		}
	}

	RegCloseKey(hKey);

	return *len;
}


/** write a global setting from registry (at User)
params - none
*/
bool WriteReg(HKEY key, LPCTSTR path, LPCTSTR val_name, LPCTSTR value) 
{	
	HKEY hKey;
	LONG ret;
	DWORD dwDisposition=0;
		
	if( RegOpenKeyEx(key, path, 0, KEY_READ|KEY_SET_VALUE, &hKey)) 
		if ( RegCreateKeyEx(key, path, 0, 0, 0, KEY_READ|KEY_SET_VALUE, NULL, &hKey, &dwDisposition) )
		{
			// read/write HKCU if there is no access rights
			if ( RegOpenKeyEx(HKEY_CURRENT_USER, path, 0, KEY_READ|KEY_SET_VALUE, &hKey) )
				RegCreateKey(HKEY_CURRENT_USER, path, &hKey);
		}

	if (value==NULL) 
		ret = RegDeleteValue(hKey, val_name);
	else {		
		ret = RegSetValueEx(hKey, val_name, 0, REG_SZ, (LPBYTE)value, _tcslen(value) * sizeof(TCHAR));
		
		
	}
	RegCloseKey(hKey);

	if (ret == ERROR_SUCCESS) 
		return true;
	else
		return false;

}


/** write a to registry (at User)
params - none
*/
void WriteReg(HKEY key, LPCTSTR path, LPCTSTR val_name, LPBYTE value, DWORD len) 
{
	
	HKEY hKey;
	LONG ret;
		
	if( RegOpenKeyEx(key, path, 0, KEY_READ|KEY_SET_VALUE, &hKey)) 
		if ( RegCreateKey(key, path, &hKey) )
		{
			// read/write HKCU if there is no access rights
			if ( RegOpenKeyEx(HKEY_CURRENT_USER, path, 0, KEY_READ|KEY_SET_VALUE, &hKey) )
				RegCreateKey(HKEY_CURRENT_USER, path, &hKey);
		}

	if (value==NULL) 
		ret = RegDeleteValue(hKey, val_name);
	else {		
		ret = RegSetValueEx(hKey, val_name, 0, REG_BINARY, value, len);
	
	}

	RegCloseKey(hKey);

	return ;
}



/** write a global setting from registry (at User)
params - none
*/

bool WriteReg(HKEY key, LPCTSTR path, LPCTSTR val_name, DWORD value) 
{	
	HKEY hKey;
	LONG ret=0;
		
	if( RegOpenKeyEx(key, path, 0, KEY_READ|KEY_SET_VALUE, &hKey)) 
		if ( RegCreateKey(key, path, &hKey) )
		{
			// read/write HKCU if there is no access rights
			if ( RegOpenKeyEx(HKEY_CURRENT_USER, path, 0, KEY_READ|KEY_SET_VALUE, &hKey) )
				RegCreateKey(HKEY_CURRENT_USER, path, &hKey);
		}

	ret = RegSetValueEx(hKey, val_name, 0, REG_DWORD, (LPBYTE)&value, sizeof(DWORD));

	RegCloseKey(hKey);

	if (ret == ERROR_SUCCESS) 
		return true;
	else
		return false;

}





/** get disk space in Megabytes
*/
__int64 GetDiskSpaceMB(LPCTSTR root_path) {

	if (root_path==NULL) return 0;
	ULARGE_INTEGER FreeBytesAvailable;    // bytes available to caller
	ULARGE_INTEGER TotalNumberOfBytes;    // bytes on disk
	//ULARGE_INTEGER TotalNumberOfFreeBytes // free bytes on disk

	if ( GetDiskFreeSpaceEx( root_path, &FreeBytesAvailable, 
				&TotalNumberOfBytes, NULL) ) 

		return TotalNumberOfBytes.QuadPart / 1048000;
	else {
		//return 0;

		
		if (!root_path) return 0;
		if (_tcslen(root_path)<2) return 0;
		

		return 0;
	}

}

/** get disk Free space in Megabytes
*/
__int64 GetDiskFreeSpaceMB(LPCTSTR root_path) {


	if (!root_path) return 0;
	if (_tcslen(root_path)<2) return 0;

	ULARGE_INTEGER FreeBytesAvailable;    // bytes available to caller
	ULARGE_INTEGER TotalNumberOfBytes;    // bytes on disk
	ULARGE_INTEGER TotalNumberOfFreeBytes; // free bytes on disk

	if ( GetDiskFreeSpaceEx( root_path, &FreeBytesAvailable, 
				&TotalNumberOfBytes, &TotalNumberOfFreeBytes) ) 

		return TotalNumberOfFreeBytes.QuadPart / 1048000;
	else {

	
		return 0;
	}

}



// Creates ToolTip for Control in dialog
HWND CreateToolTip(HWND hWnd, UINT idControl, LPCTSTR lpString, UINT iTime, bool baloon  )
{
	DWORD flags = TTS_NOPREFIX | TTS_ALWAYSTIP;
	if (baloon)
		flags = WS_POPUP | TTS_NOPREFIX | TTS_BALLOON | TTS_CLOSE | TTS_ALWAYSTIP;

				// CREATE A TOOLTIP WINDOW
	HWND hWndTT = CreateWindowEx(WS_EX_TOPMOST,
		TOOLTIPS_CLASS, NULL, flags, 
		CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT,
		NULL, NULL, NULL, NULL 	);
	
	TOOLINFO ti;	
	SetWindowLong( GetDlgItem(hWnd, idControl), GWL_USERDATA, (LONG)hWndTT);
	
	memset(&ti, 0, sizeof(TOOLINFO) );
	ti.cbSize = sizeof(TOOLINFO);
	ti.uFlags = TTF_SUBCLASS | TTF_IDISHWND ;
	
	ti.hwnd = hWnd ;
//	ti.hinst = hinst;
	ti.uId = (UINT)GetDlgItem(hWnd, idControl);
	ti.lpszText = (LPTSTR)lpString; 
	if (baloon) {
		ti.lpszText = NULL; 
		ti.uId = idControl; 
		ti.uFlags = TTF_TRANSPARENT | TTF_CENTERTIP | TTF_TRACK | TTF_SUBCLASS;
	}
	
	
	SendMessage(hWndTT, TTM_ADDTOOL, 0, (LPARAM) (LPTOOLINFO) &ti);
	
	SendMessage(hWndTT, TTM_SETMAXTIPWIDTH, 0, (LPARAM) 200);
	SendMessage(hWndTT, TTM_SETDELAYTIME, TTDT_INITIAL, iTime); // ... time to wait before the ToolTip window appears
	SendMessage(hWndTT, TTM_SETDELAYTIME, TTDT_AUTOPOP, 8000); // ... time to Tip - remains visible 

	//if (baloon)
	//  чтобы показать “ул“ип надо вызвать DisplayToolTip

	return hWndTT;
}

/** ƒиалог дл€ выбора папки
*/
BOOL SelectFolderDialog( HWND hDlg, LPTSTR Title, LPTSTR FolderPath, DWORD flags, DWORD clsid_root )
{
	BROWSEINFO BrowseInfo;
	ITEMIDLIST *pItemIDList;

	ITEMIDLIST *RootIDList = NULL;

	if (clsid_root)
		SHGetFolderLocation(NULL, clsid_root, NULL, NULL, &RootIDList);

	memset( &BrowseInfo, 0, sizeof( BROWSEINFO ) );
	 

	BrowseInfo.hwndOwner = hDlg;
	BrowseInfo.pidlRoot = RootIDList;
	BrowseInfo.pszDisplayName = FolderPath;
	BrowseInfo.lpszTitle = Title;
	if (flags==0)
		BrowseInfo.ulFlags = BIF_RETURNONLYFSDIRS | BIF_USENEWUI;
	else 
		BrowseInfo.ulFlags = flags ;
	BrowseInfo.lpfn = NULL;
	BrowseInfo.lParam = NULL;
	BrowseInfo.iImage = NULL;
	if( ( pItemIDList = SHBrowseForFolder( (LPBROWSEINFO)&BrowseInfo ) ) != NULL &&
		SHGetPathFromIDList( pItemIDList, FolderPath ) )
			return TRUE;
 return FALSE;   
}