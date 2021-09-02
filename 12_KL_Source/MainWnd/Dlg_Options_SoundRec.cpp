// Dlg_Options_SoundRec.cpp : implementation file
//

#include "stdafx.h"
#include "MainWnd.h"
#include "Dlg_Options_SoundRec.h"
#include "Mmsystem.h"

#include <mmdeviceapi.h>

#include <endpointvolume.h>
#include <ksmedia.h>



#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDlg_Options_SoundRec property page

IMPLEMENT_DYNCREATE(CDlg_Options_SoundRec, CPropertyPage)

CDlg_Options_SoundRec::CDlg_Options_SoundRec() : CPropertyPage(CDlg_Options_SoundRec::IDD)
{
	//{{AFX_DATA_INIT(CDlg_Options_SoundRec)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
}

CDlg_Options_SoundRec::~CDlg_Options_SoundRec()
{
}

void CDlg_Options_SoundRec::DoDataExchange(CDataExchange* pDX)
{
	CPropertyPage::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CDlg_Options_SoundRec)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CDlg_Options_SoundRec, CPropertyPage)
	//{{AFX_MSG_MAP(CDlg_Options_SoundRec)
		// NOTE: the ClassWizard will add message map macros here
	//}}AFX_MSG_MAP
	ON_WM_TIMER()
END_MESSAGE_MAP()

 static IAudioMeterInformation *pMeterInfo = NULL;
 static HWND hPeakMeter = NULL;
 static float peak = 0;


/////////////////////////////////////////////////////////////////////////////
// CDlg_Options_SoundRec message handlers

BOOL CDlg_Options_SoundRec::OnInitDialog()
{
	CPropertyPage::OnInitDialog();

	// TODO:  Add extra initialization here


	HRESULT hr;
    IMMDeviceEnumerator *pEnumerator = NULL;
    IMMDevice *pDevice = NULL;
    //IAudioMeterInformation *pMeterInfo = NULL;


    CoInitialize(NULL);

    // Get enumerator for audio endpoint devices.
    hr = CoCreateInstance(__uuidof(MMDeviceEnumerator),
                          NULL, CLSCTX_INPROC_SERVER,
                          __uuidof(IMMDeviceEnumerator),
                          (void**)&pEnumerator);
    

    // Get peak meter for default audio-rendering device.
    hr = pEnumerator->GetDefaultAudioEndpoint(eCapture, eConsole, &pDevice);
    

    hr = pDevice->Activate(__uuidof(IAudioMeterInformation),
                           CLSCTX_ALL, NULL, (void**)&pMeterInfo);


	int nInDev = waveInGetNumDevs();

	//pMeterInfo  = 
	
	ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "current_mic_device", _current_mic_device, 90);

	WAVEINCAPS wic;

	for (int i = 0; i < nInDev; i++) {
		if (!waveInGetDevCaps(i, &wic, sizeof(WAVEINCAPS))) {

			// We are only interested in devices supporting
			// 44.1 kHz, stereo, 16-bit, stereo input
			if (wic.dwFormats & WAVE_FORMAT_4S16) {

				int idx = SendDlgItemMessage(IDC_LIST1,  LB_ADDSTRING, 0, (LPARAM)wic.szPname );

				
				
			}
		}
	}

	SendDlgItemMessage( IDC_LIST1,  LB_SELECTSTRING , -1, (LPARAM)_current_mic_device );				

	SetTimer(1, 50, NULL);





	return TRUE;  // return TRUE unless you set the focus to a control
	// EXCEPTION: OCX Property Pages should return FALSE
}

BOOL CDlg_Options_SoundRec::OnApply()
{
	// TODO: Add your specialized code here and/or call the base class

	int _device_id = SendDlgItemMessage( IDC_LIST1,  LB_GETCURSEL, 0, 0);

	SendDlgItemMessage( IDC_LIST1,  LB_GETTEXT , _device_id, (LPARAM)_current_mic_device );

	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "current_mic_device", _current_mic_device );
	WriteReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "current_mic_device_id", _device_id );


	return CPropertyPage::OnApply();
}

void CDlg_Options_SoundRec::OnTimer(UINT_PTR nIDEvent)
{
	// TODO: Add your message handler code here and/or call default

	if (nIDEvent == 1)
	{
		/*int level = _voice_capturer->getPeakMeaterValue();
		char s[10]; 
		itoa(level, s, 10);

		SetDlgItemText(IDC_STATIC1, s);*/

		// Update the peak meter in the dialog box.

		HRESULT hr;

            hr = pMeterInfo->GetPeakValue(&peak);
            if (FAILED(hr))
            {
              /*  MessageBox(hDlg, TEXT("The program will exit."),
                           TEXT("Fatal error"), MB_OK);
                KillTimer(hDlg, ID_TIMER);
                EndDialog(hDlg, TRUE);
                return TRUE;*/
            }
           // DrawPeakMeter(hPeakMeter, peak);

			/*char s[10]; 
			itoa(peak, s, 10);

			SetDlgItemText(IDC_STATIC1, s);*/

			HDC hdc;
			RECT rect;

			HWND hPeakMeter = ::GetDlgItem(m_hWnd, IDC_STATIC4);

			::GetClientRect(hPeakMeter, &rect);
			hdc = ::GetDC(hPeakMeter);
			FillRect(hdc, &rect, (HBRUSH)(COLOR_3DSHADOW+1));
			rect.left++;
			rect.top++;
			rect.right = rect.left +
				max(0, (LONG)(peak*(rect.right-rect.left)-1.5));
			rect.bottom--;
			FillRect(hdc, &rect, (HBRUSH)(COLOR_3DHIGHLIGHT+1));
			::ReleaseDC(hPeakMeter, hdc);


	}

	CPropertyPage::OnTimer(nIDEvent);
}
