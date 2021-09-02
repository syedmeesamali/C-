#if !defined(AFX_USBCOPY_H__92820EAA_EE68_4F13_9A65_DA7446BA55D6__INCLUDED_)
#define AFX_USBCOPY_H__92820EAA_EE68_4F13_9A65_DA7446BA55D6__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// USBCopy.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// USBCopy dialog

class USBCopy : public CDialog
{
// Construction
public:
	USBCopy(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(USBCopy)
	enum { IDD = IDD_USB };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(USBCopy)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(USBCopy)
	virtual void OnOK();
	virtual void OnCancel();
	virtual BOOL OnInitDialog();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_USBCOPY_H__92820EAA_EE68_4F13_9A65_DA7446BA55D6__INCLUDED_)
