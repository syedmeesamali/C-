#include "afxwin.h"
#if !defined(AFX_DLG_SMTP_H__DBC0BFBC_D880_489C_9933_43A943CD2B9E__INCLUDED_)
#define AFX_DLG_SMTP_H__DBC0BFBC_D880_489C_9933_43A943CD2B9E__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// Dlg_SMTP.h : header file
//

#include "GifAnimation.h"
#include "demoredir.h"


/////////////////////////////////////////////////////////////////////////////
// Dlg_SMTP dialog

class Dlg_SMTP : public CPropertyPage
{
	CDemoRedirector m_redir;

// Construction
public:
	Dlg_SMTP(CWnd* pParent = NULL);   // standard constructor
	TCHAR *save_params(int n,...);
	void load_params(int n,...);
// Dialog Data
	//{{AFX_DATA(Dlg_SMTP)
	enum { IDD = IDD_SMTP };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(Dlg_SMTP)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(Dlg_SMTP)
	virtual BOOL OnApply();
	virtual void OnOK();
	virtual void OnCancel();
	virtual BOOL OnInitDialog();
	afx_msg void OnTestEmailLog();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
public:
	CGifAnimation  _animation;
public:
	afx_msg void OnTimer(UINT_PTR nIDEvent);
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DLG_SMTP_H__DBC0BFBC_D880_489C_9933_43A943CD2B9E__INCLUDED_)
