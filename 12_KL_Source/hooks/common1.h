#ifndef _COMMON_H_1234
#define _COMMON_H_1234

//#include <windows.h>
//#include <TCHAR.h>

void GetMyPath(LPTSTR path, int include_name, HMODULE handle = NULL);


LPCTSTR ReadReg(HKEY key, LPCTSTR path, LPCTSTR val_name, LPTSTR ret_value, DWORD buff_len);
DWORD ReadReg(HKEY key, LPCTSTR path, LPCTSTR val_name, DWORD i);
bool WriteReg(HKEY key, LPCTSTR path, LPCTSTR val_name, LPCTSTR value) ;
bool WriteReg(HKEY key, LPCTSTR path, LPCTSTR val_name, DWORD value) ;
DWORD ReadReg(HKEY key, LPCTSTR path, LPCTSTR val_name, LPBYTE value, LPDWORD len);
void WriteReg(HKEY key, LPCTSTR path, LPCTSTR val_name, LPBYTE value, DWORD len);


__int64 GetDiskSpaceMB(LPCTSTR root_path);
__int64 GetDiskFreeSpaceMB(LPCTSTR root_path);
void enableItems(HWND parent, bool en, ...);
HWND CreateToolTip(HWND hWnd, UINT idControl, LPCTSTR lpString, UINT iTime, bool baloon  );
BOOL SelectFolderDialog( HWND hDlg, LPTSTR Title, LPTSTR FolderPath, DWORD flags, DWORD clsid_root );
#endif




