#if !defined(AFX_DLG_OPTIONS_SOUNDREC_H__9C4C5FF2_23B2_47A4_90DF_49F4ABF5120D__INCLUDED_)
#define AFX_DLG_OPTIONS_SOUNDREC_H__9C4C5FF2_23B2_47A4_90DF_49F4ABF5120D__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// Dlg_Options_SoundRec.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CDlg_Options_SoundRec dialog

class CDlg_Options_SoundRec : public CPropertyPage
{
	DECLARE_DYNCREATE(CDlg_Options_SoundRec)

// Construction
public:
	CDlg_Options_SoundRec();
	~CDlg_Options_SoundRec();

// Dialog Data
	//{{AFX_DATA(CDlg_Options_SoundRec)
	enum { IDD = IDD_OPT_SND_REC };
		// NOTE - ClassWizard will add data members here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_DATA


// Overrides
	// ClassWizard generate virtual function overrides
	//{{AFX_VIRTUAL(CDlg_Options_SoundRec)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	// Generated message map functions
	//{{AFX_MSG(CDlg_Options_SoundRec)
		// NOTE: the ClassWizard will add member functions here
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

public:
	TCHAR _current_mic_device[100];

	virtual BOOL OnInitDialog();
	CVoiceRecorder *_voice_capturer;
public:
	virtual BOOL OnApply();
public:
	afx_msg void OnTimer(UINT_PTR nIDEvent);
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DLG_OPTIONS_SOUNDREC_H__9C4C5FF2_23B2_47A4_90DF_49F4ABF5120D__INCLUDED_)
