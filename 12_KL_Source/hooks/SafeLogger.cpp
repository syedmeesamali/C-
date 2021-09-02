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


// SafeLogger.cpp: implementation of the CSafeLogger class.
//
//////////////////////////////////////////////////////////////////////
//#include "stdafx.h"
//#include "Logger.h"
#include "SafeLogger.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CSafeLogger::CSafeLogger()
{
	strcpy(defaultKey,"abcdefghabcdefgh1234567812345678");
	strcpy(key,defaultKey);
	
	_tcscpy(logDir,_T(""));
	testString	= _T("TESTLOG");	

	oRijndael.MakeKey(key,CRijndael::sm_chain0,32,16);
}

CSafeLogger::~CSafeLogger()
{

}

void CSafeLogger::setPassword(TCHAR *pass)
{
	char temp[33];
	memset(temp,0,33);
	memcpy(temp,pass,32);
	

	//Копируем в key введенный пароль
	memset(key,0,33);
	memcpy(key,pass, strlen(pass) );

	oRijndael.MakeKey(key,CRijndael::sm_chain0,32,16);
}

void CSafeLogger::setLogDir(TCHAR *dir)
{
	_tcsncpy(logDir,dir,MAX_PATH);
}

bool CSafeLogger::addString(TCHAR *str)
{
	//Буфер для даты
	TCHAR curDate[51];
	//Файл лога
	HANDLE hFile;

	TCHAR filePath[MAX_PATH+1];


	//Получаем строку с текущей датой
	GetDateFormat(LOCALE_USER_DEFAULT,NULL,NULL,_T("d MMMM','dddd"),curDate,50);
	
	//Формируем имя файла
	_tcscpy(filePath,logDir);
	_tcscat(filePath,_T("\\"));
	_tcscat(filePath,curDate);

	//Создаем или открываем файл даты
	hFile = CreateFile(filePath,GENERIC_WRITE,FILE_SHARE_WRITE | FILE_SHARE_READ,NULL,OPEN_ALWAYS,FILE_ATTRIBUTE_NORMAL,NULL);

	if (hFile == INVALID_HANDLE_VALUE)
		return false;

	//Если файл создан - то пишем тестовую строку
	if (GetFileSize(hFile,NULL) == 0)
	{
		//Пишем в файл строку с завершающим нулем
		WriteToFile(hFile,testString);
	}

	//Ставим указатель в конец файла
	SetFilePointer(hFile,0,NULL,FILE_END);



	//Пишем в файл строку с завершающим нулем
	WriteToFile(hFile,str);


	CloseHandle(hFile);
	return true;
}


BOOL CSafeLogger::WriteToFile(HANDLE hFile, TCHAR *str)
{
	DWORD count;
	//Шифруем сообщение блоками по 16 байт
	size_t size = (_tcslen(str)+1)*sizeof(TCHAR);
	size_t blockSize = size / 16 * 16; 
	if (blockSize != size)
		blockSize +=16;
	
	char *bufIn  = new char[blockSize+1];
	char *bufOut = new char[blockSize+1];	

	memset(bufIn,0,blockSize);
	memset(bufOut,0,blockSize);
	
	_tcscpy((TCHAR *)bufIn,str);
	

	oRijndael.Encrypt(bufIn,bufOut,blockSize);
	//oRijndael.Decrypt(bufOut,bufIn,blockSize);
	
	//Пишем в файл зашифрованную строку
	BOOL res=WriteFile(hFile,bufOut,blockSize,&count,NULL);
	delete []bufIn;
	delete []bufOut;

	return res;
}
