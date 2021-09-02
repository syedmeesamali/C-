#if !defined(AFX_DLG_OPTIONS_H__3F9DF51E_A928_418C_90C7_48FD7D6090D3__INCLUDED_)
#define AFX_DLG_OPTIONS_H__3F9DF51E_A928_418C_90C7_48FD7D6090D3__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// Dlg_Options.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CDlg_Options dialog

class CDlg_Options : public CPropertyPage
{
// Construction
public:
	CDlg_Options(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CDlg_Options)
	enum { IDD = IDD_OPTIONS };
	BOOL	_enable_password;
	BOOL	_safe_logger;
	BOOL	_log_clipboard;
	CString	_password;
	CString	_confirmation;
	CString	_loffiles_path;
	BOOL	_usb_monitor;
	BOOL	_log_keystrokes;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDlg_Options)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CDlg_Options)
	afx_msg void OnPassword();
	virtual void OnOK();
	afx_msg void OnCheckEnablePassword();
	afx_msg void OnCheckEnableCapturer();
	virtual BOOL OnInitDialog();
	afx_msg void OnBrowse();
	afx_msg void OnHide();
	afx_msg void OnOptSmtp();
	afx_msg HBRUSH OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor);
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DLG_OPTIONS_H__3F9DF51E_A928_418C_90C7_48FD7D6090D3__INCLUDED_)
