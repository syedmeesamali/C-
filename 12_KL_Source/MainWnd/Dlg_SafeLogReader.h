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

	//���������� ����� � ������
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
	//�������� ������ �� �������
	void GetPassword();
	//��������� ���������
	void FillComboBox();
	//������� ���������� ��-�� ����������
	void EnableControls(bool);
	//������ ���-����
	//FALSE - ���� ���� �� ���
	bool ReadLog(TCHAR*);
	//������ ��� ���-�����
	void ReadAll();
	//�������� ���
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

	//������ ���-������
	CStringArray logFiles;
	//������ ������ �������� ���-������
	CDWordArray	 timeFiles;

	//������ ���-���� � ���������� CString - ���������� �����
	bool ReadLog(TCHAR*, CString&);

	//����������� ����� �� ���� ��������
	void SortByTime();

	//���������, �������� �� ���� ����� (�� 1-�� ��������������� �����)
	bool isLog(TCHAR*);

	//TRUE - ������� ������ - ������
	bool m_bCursorOn;

	static time_t FILEFileTimeToUnixTime( FILETIME, long *);
private:
	char defaultKey[33];	//���� �� ���������
	char key[33];			//������� ����
	TCHAR *testString;		//�������� ������
	TCHAR logDir[500+1];	//�����, ��� �������� ����
	

};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DLG_SAFELOGREADER_H__D1F60477_9407_4E81_8CAD_1546F933FD48__INCLUDED_)
