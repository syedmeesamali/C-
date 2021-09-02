// ScreenCapture.h: interface for the CScreenCapture class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_SCREENCAPTURE_H__669BFE73_35E8_4CA4_B8B1_C1948DFF4911__INCLUDED_)
#define AFX_SCREENCAPTURE_H__669BFE73_35E8_4CA4_B8B1_C1948DFF4911__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CScreenCapture  
{
public:
	BOOL _gdi_plus_init;
	

	bool Capture(HWND window, LPCTSTR tag_name, LPTSTR file_name = NULL, BOOL history = true	);
	CScreenCapture();
	virtual ~CScreenCapture();

	CStringArray	_window_list;
	CPtrArray	_hbmp_list;
	HWND _hwnd; ///< parent

};

#endif // !defined(AFX_SCREENCAPTURE_H__669BFE73_35E8_4CA4_B8B1_C1948DFF4911__INCLUDED_)
