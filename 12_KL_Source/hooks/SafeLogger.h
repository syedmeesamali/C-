// SafeLogger.h: interface for the CSafeLogger class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_SAFELOGGER_H__FF844EC9_9C6A_4E17_9B0D_54F1DBBFA440__INCLUDED_)
#define AFX_SAFELOGGER_H__FF844EC9_9C6A_4E17_9B0D_54F1DBBFA440__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
#include "StdAfx.h"
#include "Rijndael.h"
#include "tchar.h"
//#include "windows.h"

class CSafeLogger  
{
private:
	char defaultKey[33];	//Ключ по умолчанию
	char key[33];			//Текущий ключ
	TCHAR *testString;		//Тестовая строка
	TCHAR logDir[MAX_PATH+1];	//Папка, где хранятся логи
public:
	CSafeLogger();
	virtual ~CSafeLogger();

	//установить пароль
	void setPassword(TCHAR*);

	//Установить папку с логами
	void setLogDir(TCHAR*);

	//добавить строку к логу
	bool addString(TCHAR *);

protected:
	CRijndael oRijndael;
	
	//Записать строку в файл
	BOOL WriteToFile(HANDLE, TCHAR *);

};

#endif // !defined(AFX_SAFELOGGER_H__FF844EC9_9C6A_4E17_9B0D_54F1DBBFA440__INCLUDED_)
