#if !defined(AFX_DLG_SAFELOGREADER_H__D1F60477_9407_4E81_8CAD_1546F933FD48__INCLUDED_)
#define AFX_DLG_SAFELOGREADER_H__D1F60477_9407_4E81_8CAD_1546F933FD48__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// Dlg_SafeLogReader.h : header file
//

#include "Rijndael.h"

/////////////////////////////////////////////////////////////////////////////
// CDlg_SafeLogReader dialog

class CDlg_SafeLogReader : public CDialog
{
// Construction
public:
	CDlg_SafeLogReader(CWnd* pParent = NULL);   // standard constructor

	//Установить папку с логами
	void setLogDir(TCHAR*);
// Dialog Data
	//{{AFX_DATA(CDlg_SafeLogReader)
	enum { IDD = IDD_LOGREADER_DIALOG };
	CButton	m_showall;
	CEdit	m_logview;
	CButton	m_clear;
	CComboBox	m_Files;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDlg_SafeLogReader)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
	//Получить пароль из реестра
	void GetPassword();
	//Заполнить комбобокс
	void FillComboBox();
	//Сделать доступными эл-ты управления
	void EnableControls(bool);
	//Читаем лог-файл
	//FALSE - если файл не лог
	bool ReadLog(TCHAR*);
	//Читаем все лог-файлы
	void ReadAll();
	//Очистить лог
	void ClearLog(TCHAR *);
	
	

protected:

	// Generated message map functions
	//{{AFX_MSG(CDlg_SafeLogReader)
	virtual BOOL OnInitDialog();
	afx_msg void OnSelchangeCombo1();
	afx_msg void OnShowall();
	afx_msg BOOL OnSetCursor(CWnd* pWnd, UINT nHitTest, UINT message);
	afx_msg void OnClear();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

	CRijndael oRijndael;

	//Массив лог-файлов
	CStringArray logFiles;
	//Массив времен создания лог-файлов
	CDWordArray	 timeFiles;

	//Читаем лог-файл и возвращаем CString - содержимое файла
	bool ReadLog(TCHAR*, CString&);

	//Сортировать файлы по дате создания
	void SortByTime();

	//Проверяет, является ли файл логом (по 1-му закодированному блоку)
	bool isLog(TCHAR*);

	//TRUE - текущий курсор - часики
	bool m_bCursorOn;

	static time_t FILEFileTimeToUnixTime( FILETIME, long *);
private:
	char defaultKey[33];	//Ключ по умолчанию
	char key[33];			//Текущий ключ
	TCHAR *testString;		//Тестовая строка
	TCHAR logDir[500+1];	//Папка, где хранятся логи
	

};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DLG_SAFELOGREADER_H__D1F60477_9407_4E81_8CAD_1546F933FD48__INCLUDED_)
