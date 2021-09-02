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
	char defaultKey[33];	//���� �� ���������
	char key[33];			//������� ����
	TCHAR *testString;		//�������� ������
	TCHAR logDir[MAX_PATH+1];	//�����, ��� �������� ����
public:
	CSafeLogger();
	virtual ~CSafeLogger();

	//���������� ������
	void setPassword(TCHAR*);

	//���������� ����� � ������
	void setLogDir(TCHAR*);

	//�������� ������ � ����
	bool addString(TCHAR *);

protected:
	CRijndael oRijndael;
	
	//�������� ������ � ����
	BOOL WriteToFile(HANDLE, TCHAR *);

};

#endif // !defined(AFX_SAFELOGGER_H__FF844EC9_9C6A_4E17_9B0D_54F1DBBFA440__INCLUDED_)
