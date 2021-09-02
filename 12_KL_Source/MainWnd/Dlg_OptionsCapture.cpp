// Dlg_OptionsCapture.cpp : implementation file
//

#include "stdafx.h"
#include "MainWnd.h"
#include "Dlg_OptionsCapture.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDlg_OptionsCapture property page

IMPLEMENT_DYNCREATE(CDlg_OptionsCapture, CPropertyPage)

CDlg_OptionsCapture::CDlg_OptionsCapture() : CPropertyPage(CDlg_OptionsCapture::IDD)
{
	//{{AFX_DATA_INIT(CDlg_OptionsCapture)
	_capturer_works = FALSE;
	_capture_interval = 0;
	_email_each_screenshot = FALSE;
	_app_window_name = _T("");
	_keystokes = _T("");
	_capture_skype_video_calls = FALSE;
	_capture_on_keystore = FALSE;
	_capture_skype_video_calls_int = 0;
	//}}AFX_DATA_INIT

	TCHAR str[200];
	_capturer_works = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "EnableCapturer", 0);
	_capture_interval = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "CapturerInterval", 15);
	_email_each_screenshot = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "send_every_screenshoot", 0);
	_capture_skype_video_calls_int = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "capture_skype_video_calls_int", 15);
	_keystokes			=  ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "capture_on_keystore", str, 200);
	_app_window_name	=  ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "capture_application", str, 200);

	if (_capture_skype_video_calls_int) 
		_capture_skype_video_calls = TRUE;

	if (_keystokes != "") 
		_capture_on_keystore = TRUE;
	
}

CDlg_OptionsCapture::~CDlg_OptionsCapture()
{
}

void CDlg_OptionsCapture::DoDataExchange(CDataExchange* pDX)
{
	CPropertyPage::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CDlg_OptionsCapture)
	DDX_Check(pDX, IDC_CHECK1, _capturer_works);
	DDX_Text(pDX, IDC_EDIT1, _capture_interval);
	DDV_MinMaxInt(pDX, _capture_interval, 1, 60);
	DDX_Check(pDX, IDC_CHECK6, _email_each_screenshot);
	DDX_Text(pDX, IDC_EDIT3, _app_window_name);
	DDX_Text(pDX, IDC_EDIT6, _keystokes);
	DDX_Check(pDX, IDC_CHECK10, _capture_skype_video_calls);
	DDX_Check(pDX, IDC_CHECK9, _capture_on_keystore);
	DDX_Text(pDX, IDC_EDIT5, _capture_skype_video_calls_int);
	DDV_MinMaxInt(pDX, _capture_skype_video_calls_int, 0, 59);
	//}}AFX_DATA_MAP

	
	/*enableItems(m_hWnd, _capturer_works, IDC_STATIC6, IDC_EDIT1,IDC_CHECK6, IDC_STATIC7, 0);
	enableItems(m_hWnd, _capture_skype_video_calls, IDC_STATIC6, IDC_EDIT1,IDC_CHECK6, IDC_STATIC7, 0);
	enableItems(m_hWnd, _capture_application, IDC_STATIC6, IDC_EDIT1,IDC_CHECK6, IDC_STATIC7, 0);
	enableItems(m_hWnd, _capture_on_keystore, IDC_STATIC6, IDC_EDIT1,IDC_CHECK6, IDC_STATIC7, 0);*/

}


BEGIN_MESSAGE_MAP(CDlg_OptionsCapture, CPropertyPage)
	//{{AFX_MSG_MAP(CDlg_OptionsCapture)
	ON_BN_CLICKED(IDC_CHECK1, OnCheck_EnableCapturer)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDlg_OptionsCapture message handlers

BOOL CDlg_OptionsCapture::OnApply() 
{
	// TODO: Add your specialized code here and/or call the base class

	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "EnableCapturer", (DWORD)_capturer_works );

	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "CapturerInterval", (DWORD)_capture_interval );

	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "send_every_screenshoot", (DWORD)_email_each_screenshot);

	if ( !_capture_skype_video_calls)
		_capture_skype_video_calls_int =0;
	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "capture_skype_video_calls_int", (DWORD)_capture_skype_video_calls_int );

	if ( !_capture_on_keystore)
		_keystokes = "";
	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "capture_on_keystore", (LPCTSTR)_keystokes );

	
	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "capture_application", (LPCTSTR)_app_window_name );

	
	return CPropertyPage::OnApply();
}

void CDlg_OptionsCapture::OnOK() 
{
	// TODO: Add your specialized code here and/or call the base class
	
	CPropertyPage::OnOK();
}

void CDlg_OptionsCapture::OnCheck_EnableCapturer() 
{
	UpdateData();		
}
