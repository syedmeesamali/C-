// ScreenCapture.cpp: implementation of the CScreenCapture class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "MainWnd.h"
#include "ScreenCapture.h"
#include "io.h"
#include <atlimage.h>

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

#define ULONG_PTR DWORD
//#include <gdiplus.h>
//using namespace Gdiplus;
#define MAX_LOADSTRING 100



int scalew=1;
int scaleh=1;
HWND m_hwnd;

void GetFileName(int i, char* str, char* ext);
/*
int GetEncoderClsid(const WCHAR* format, CLSID* pClsid)
{
   UINT  num = 0;          // number of image encoders
   UINT  size = 0;         // size of the image encoder array in bytes

   ImageCodecInfo* pImageCodecInfo = NULL;

   GetImageEncodersSize(&num, &size);
   if(size == 0)
      return -1;  // Failure

   pImageCodecInfo = (ImageCodecInfo*)(malloc(size));
   if(pImageCodecInfo == NULL)
      return -1;  // Failure

   GetImageEncoders(num, size, pImageCodecInfo);

   for(UINT j = 0; j < num; ++j)
   {
      if( wcscmp(pImageCodecInfo[j].MimeType, format) == 0 )
      {
         *pClsid = pImageCodecInfo[j].Clsid;
         free(pImageCodecInfo);
         return j;  // Success
      }    
   }

   free(pImageCodecInfo);
   return -1;  // Failure
}*/



PBITMAPINFO CreateBitmapInfoStruct(HBITMAP hBmp) 
{ 
	HWND hwnd =0;
    BITMAP bmp; 
    PBITMAPINFO pbmi; 
    WORD    cClrBits; 
 
    /* Retrieve the bitmap's color format, width, and height. */ 
 
    if (!GetObject(hBmp, sizeof(BITMAP), (LPSTR)&bmp)) 
        return NULL;
 
 
    /* Convert the color format to a count of bits. */ 
 
    cClrBits = (WORD)(bmp.bmPlanes * bmp.bmBitsPixel); 
 
    if (cClrBits == 1) 
        cClrBits = 1; 
    else if (cClrBits <= 4) 

        cClrBits = 4; 
    else if (cClrBits <= 8) 
        cClrBits = 8; 
    else if (cClrBits <= 16) 
        cClrBits = 16; 
    else if (cClrBits <= 24) 
        cClrBits = 24; 
    else 
        cClrBits = 32; 
 
    /* 
     * Allocate memory for the BITMAPINFO structure. (This structure 
     * contains a BITMAPINFOHEADER structure and an array of RGBQUAD data 
     * structures.) 
     */ 
 
    if (cClrBits != 24) 
         pbmi = (PBITMAPINFO) LocalAlloc(LPTR, 

                    sizeof(BITMAPINFOHEADER) + 
                    sizeof(RGBQUAD) * (2^cClrBits)); 
 
    /* 
     * There is no RGBQUAD array for the 24-bit-per-pixel format. 
     */ 
 
    else 
         pbmi = (PBITMAPINFO) LocalAlloc(LPTR, 
                    sizeof(BITMAPINFOHEADER)); 
 
 
 
    /* Initialize the fields in the BITMAPINFO structure. */ 
 
    pbmi->bmiHeader.biSize = sizeof(BITMAPINFOHEADER); 
    pbmi->bmiHeader.biWidth = bmp.bmWidth; 

    pbmi->bmiHeader.biHeight = bmp.bmHeight; 
    pbmi->bmiHeader.biPlanes = bmp.bmPlanes; 
    pbmi->bmiHeader.biBitCount = bmp.bmBitsPixel; 
    if (cClrBits < 24) 
        pbmi->bmiHeader.biClrUsed = 2^cClrBits; 
 
 
    /* If the bitmap is not compressed, set the BI_RGB flag. */ 
 
    pbmi->bmiHeader.biCompression = BI_RGB; 
 
    /* 
     * Compute the number of bytes in the array of color 
     * indices and store the result in biSizeImage. 
     */ 

 
    pbmi->bmiHeader.biSizeImage = (pbmi->bmiHeader.biWidth + 7) /8 
                                  * pbmi->bmiHeader.biHeight 
                                  * cClrBits; 
 
    /* 
     * Set biClrImportant to 0, indicating that all of the 
     * device colors are important. 
     */ 
 
    pbmi->bmiHeader.biClrImportant = 0; 
 
    return pbmi; 
 
} 
 

//The following example code defines a function that initializes the remaining structures, retrieves the array of palette indices, opens the file, copies the data, and closes the file. 

int CreateBMPFile(LPTSTR pszFile, PBITMAPINFO pbi,  HBITMAP hBMP, HDC hDC) 
 { 
 
	HWND hwnd =0;
    HANDLE hf;                  /* file handle */ 
    BITMAPFILEHEADER hdr;       /* bitmap file-header */ 
    PBITMAPINFOHEADER pbih;     /* bitmap info-header */ 
    LPBYTE lpBits;              /* memory pointer */ 
    DWORD dwTotal;              /* total count of bytes */ 
    DWORD cb;                   /* incremental count of bytes */ 
    BYTE *hp;                   /* byte pointer */ 

    DWORD dwTmp; 
 
 
    pbih = (PBITMAPINFOHEADER) pbi; 
    lpBits = (LPBYTE) GlobalAlloc(GMEM_FIXED, pbih->biSizeImage);
    if (!lpBits) 
         return -1;
 
    /* 
     * Retrieve the color table (RGBQUAD array) and the bits 
     * (array of palette indices) from the DIB. 
     */ 
 
    if (!GetDIBits(hDC, hBMP, 0, (WORD) pbih->biHeight, 
                   lpBits, pbi, DIB_RGB_COLORS)) 
        return -2;

 

    /* Create the .BMP file. */ 

	//MessageBox(NULL,pszFile,"",0); 
 
    hf = CreateFile(pszFile, 
                   GENERIC_READ | GENERIC_WRITE, 
                   FILE_SHARE_WRITE | FILE_SHARE_READ, 
                   (LPSECURITY_ATTRIBUTES) NULL, 
                   CREATE_ALWAYS, 
                   FILE_ATTRIBUTE_NORMAL, 
                   (HANDLE) NULL); 
 
    if (hf == INVALID_HANDLE_VALUE) 
        return -3;
 
    hdr.bfType = 0x4d42;        /* 0x42 = "B" 0x4d = "M" */ 
 
    /* Compute the size of the entire file. */ 

 
    hdr.bfSize = (DWORD) (sizeof(BITMAPFILEHEADER) + 
                 pbih->biSize + pbih->biClrUsed 
                 * sizeof(RGBQUAD) + pbih->biSizeImage); 
 
    hdr.bfReserved1 = 0; 
    hdr.bfReserved2 = 0; 
 
    /* Compute the offset to the array of color indices. */ 
 
    hdr.bfOffBits = (DWORD) sizeof(BITMAPFILEHEADER) + 
                    pbih->biSize + pbih->biClrUsed 
                    * sizeof (RGBQUAD); 
 
    /* Copy the BITMAPFILEHEADER into the .BMP file. */ 

 
    if (!WriteFile(hf, (LPVOID) &hdr, sizeof(BITMAPFILEHEADER), 
       (LPDWORD) &dwTmp, (LPOVERLAPPED) NULL)) 
       return -4;
 
    /* Copy the BITMAPINFOHEADER and RGBQUAD array into the file. */ 
 
    if (!WriteFile(hf, (LPVOID) pbih, sizeof(BITMAPINFOHEADER) 
                  + pbih->biClrUsed * sizeof (RGBQUAD), 
                  (LPDWORD) &dwTmp, (LPOVERLAPPED) NULL)) 
       return -5;
 
    /* Copy the array of color indices into the .BMP file. */ 

 
    dwTotal = cb = pbih->biSizeImage; 
    hp = lpBits; 

#define MAXWRITE 0xFFFFF

    while (cb > MAXWRITE)  { 
            if (!WriteFile(hf, (LPSTR) hp, (int) MAXWRITE, 
                          (LPDWORD) &dwTmp, (LPOVERLAPPED) NULL)) 
                return -6;
            cb-= MAXWRITE; 
            hp += MAXWRITE; 
    } 
    if (!WriteFile(hf, (LPSTR) hp, (int) cb, 
         (LPDWORD) &dwTmp, (LPOVERLAPPED) NULL)) 
           return -7;
    
 
    CloseHandle(hf);     

    GlobalFree((HGLOBAL)lpBits);
	return 0;
} 
 

HBITMAP GetDesktopImage(HWND window, int scw, int sch)
{	
	BITMAP bmp;

	HDC hdcScreen 	= GetDC(window); 	//CreateDC("DISPLAY", NULL, NULL, NULL); 
	if ( !hdcScreen ) return (HBITMAP)-1;

	HDC hdcCompatible = CreateCompatibleDC(hdcScreen); 	
	if ( !hdcCompatible  ) return (HBITMAP)-2;

	int w, h=0;

	if (window == NULL)
	{
		w = GetDeviceCaps(hdcScreen, HORZRES);
		h = GetDeviceCaps(hdcScreen, VERTRES);
	} else
	{
		RECT r;
		GetWindowRect(window, &r);
   
		w = r.right - r.left; w-= GetSystemMetrics(SM_CYFIXEDFRAME)*2; 
		h = r.bottom - r.top; h-= GetSystemMetrics(SM_CYCAPTION); h-= GetSystemMetrics(SM_CYMENU);
	}


	int bw = ( scw < 10 ) ? w / scw : scw;
	int bh = ( sch < 10 ) ? h / sch : sch;

	HBITMAP hOld,hBmp = CreateCompatibleBitmap(hdcScreen, bw, bh);		
	if ( !hBmp ) return (HBITMAP)-3;

	GetObject(hBmp, sizeof(BITMAP), &bmp);		
	if ( !(hOld=(HBITMAP)SelectObject(hdcCompatible, hBmp)) ) return (HBITMAP) -4;
	
	StretchBlt(hdcCompatible, 
		0, 0, 
		bmp.bmWidth  , bmp.bmHeight , 
		hdcScreen, 
		0, 0, 
		w, h, 
		SRCCOPY); 

	SelectObject(hdcCompatible, hOld);
	ReleaseDC(NULL,hdcScreen);
	DeleteDC(hdcCompatible);

	return hBmp;
}


/////////////////////////////////////////////////////////////////////////////
//
//  CompareBitmaps
//    Compares two HBITMAPs to see if they contain the same image
//
//  Parameters :
//    HBitmapLeft  [in] : The HBITMAP handles that are to be compared
//    HBitmapRight [in] :
//
//  Returns :
//    true if the bitmaps are the same
//    false if they are different
//
/////////////////////////////////////////////////////////////////////////////


bool CompareBitmaps(HBITMAP HBitmapLeft, HBITMAP HBitmapRight)
{
    if (HBitmapLeft == HBitmapRight)
    {
        return true;
    }

    if (NULL == HBitmapLeft || NULL == HBitmapRight)
    {
        return false;
    }

    bool bSame = false;

    HDC hdc = GetDC(NULL);
    BITMAPINFO BitmapInfoLeft = {0};
    BITMAPINFO BitmapInfoRight = {0};

    BitmapInfoLeft.bmiHeader.biSize = sizeof(BITMAPINFOHEADER);
    BitmapInfoRight.bmiHeader.biSize = sizeof(BITMAPINFOHEADER);

    if (0 != GetDIBits(hdc, HBitmapLeft, 0, 0, NULL, &BitmapInfoLeft, DIB_RGB_COLORS) &&
        0 != GetDIBits(hdc, HBitmapRight, 0, 0, NULL, &BitmapInfoRight, DIB_RGB_COLORS))
    {
        // Compare the BITMAPINFOHEADERs of the two bitmaps

        if (0 == memcmp(&BitmapInfoLeft.bmiHeader, &BitmapInfoRight.bmiHeader, 
            sizeof(BITMAPINFOHEADER)))
        {
            // The BITMAPINFOHEADERs are the same so now compare the actual bitmap bits

            BYTE *pLeftBits = new BYTE[BitmapInfoLeft.bmiHeader.biSizeImage];
            BYTE *pRightBits = new BYTE[BitmapInfoRight.bmiHeader.biSizeImage];
            BYTE *pByteLeft = NULL;
            BYTE *pByteRight = NULL;

            PBITMAPINFO pBitmapInfoLeft = &BitmapInfoLeft;
            PBITMAPINFO pBitmapInfoRight = &BitmapInfoRight;

            // calculate the size in BYTEs of the additional

            // memory needed for the bmiColor table

            int AdditionalMemory = 0;
            switch (BitmapInfoLeft.bmiHeader.biBitCount)
            {
            case 1:
                AdditionalMemory = 1 * sizeof(RGBQUAD);
                break;
            case 4:
                AdditionalMemory = 15 * sizeof(RGBQUAD);
                break;
            case 8:
                AdditionalMemory = 255 * sizeof(RGBQUAD);
                break;
            case 16:
            case 32:
                AdditionalMemory = 2 * sizeof(RGBQUAD);
            }

            if (AdditionalMemory)
            {
                // we have to allocate room for the bmiColor table that will be

                // attached to our BITMAPINFO variables

                pByteLeft = new BYTE[sizeof(BITMAPINFO) + AdditionalMemory];
                if (pByteLeft)
                {
                    memset(pByteLeft, 0, sizeof(BITMAPINFO) + AdditionalMemory);
                    memcpy(pByteLeft, pBitmapInfoLeft, sizeof(BITMAPINFO));
                    pBitmapInfoLeft = (PBITMAPINFO)pByteLeft;
                }

                pByteRight = new BYTE[sizeof(BITMAPINFO) + AdditionalMemory];
                if (pByteRight)
                {
                    memset(pByteRight, 0, sizeof(BITMAPINFO) + AdditionalMemory);
                    memcpy(pByteRight, pBitmapInfoRight, sizeof(BITMAPINFO));
                    pBitmapInfoRight = (PBITMAPINFO)pByteRight;
                }
            }

            if (pLeftBits && pRightBits && pBitmapInfoLeft && pBitmapInfoRight)
            {
                // zero out the bitmap bit buffers

                memset(pLeftBits, 0, BitmapInfoLeft.bmiHeader.biSizeImage);
                memset(pRightBits, 0, BitmapInfoRight.bmiHeader.biSizeImage);

                // fill the bit buffers with the actual bitmap bits

                if (0 != GetDIBits(hdc, HBitmapLeft, 0, 
                    pBitmapInfoLeft->bmiHeader.biHeight, pLeftBits, pBitmapInfoLeft, 
                    DIB_RGB_COLORS) && 0 != GetDIBits(hdc, HBitmapRight, 0, 
                    pBitmapInfoRight->bmiHeader.biHeight, pRightBits, pBitmapInfoRight, 
                    DIB_RGB_COLORS))
                {
                    // compare the actual bitmap bits of the two bitmaps

                    /*bSame = 0 == memcmp(pLeftBits, pRightBits, 
                        pBitmapInfoLeft->bmiHeader.biSizeImage);*/

					int Different_bloks =0;

					// scan by blocks and find out how many blocks are diffirent.
					for (int i=0; i < pBitmapInfoLeft->bmiHeader.biSizeImage / 1000; i++)
					{
						if ( memcmp(pLeftBits + i*1000, pRightBits + i*1000, 1000) )
							Different_bloks++;

					}

					bSame = true; 
					
					//  setup a 5% allowed limit.
					int allowed_limit = (pBitmapInfoLeft->bmiHeader.biSizeImage / 10000) / 2;

					/*TCHAR str[70];
					sprintf(str, "diff %X - limit %X - sz %X", Different_bloks, allowed_limit, pBitmapInfoLeft->bmiHeader.biSizeImage); 
					SendMessage( GetDlgItem(m_hwnd, IDC_LIST1 ),  LB_ADDSTRING, 0, (LPARAM)str);
					SendMessage( GetDlgItem(m_hwnd, IDC_LIST1 ),  LB_SETTOPINDEX, SendMessage( GetDlgItem(m_hwnd, IDC_LIST1 ),  LB_GETCOUNT, 0, (LPARAM)0)-1, (LPARAM)0);
					*/

					if (Different_bloks > allowed_limit)
						bSame = false;						

                }
            }

            // clean up

            delete[] pLeftBits;
            delete[] pRightBits;
            delete[] pByteLeft;
            delete[] pByteRight;
        }
    }

    ReleaseDC(NULL, hdc);

    return bSame;
}

//GdiplusStartupInput ginp;
	ULONG_PTR gtoken;


//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CScreenCapture::CScreenCapture()
{
	_gdi_plus_init =0;

}

CScreenCapture::~CScreenCapture()
{

}

/** Make a screen capture of a entire desktop or window

 before capture make sure the window content is changed

 file_name - where screen were saved.

*/
bool CScreenCapture::Capture(HWND window, LPCTSTR tag_name, LPTSTR file_name/* = NULL*/, BOOL history/* = true*/)
{
	CString tag = tag_name;


	int arr_idx = -1; 
	
	if (history)
	{
		for (int x=0; x<_window_list.GetSize(); x++ )
		{
			if ( _window_list[x] == tag_name)	
				arr_idx = x;
		}	
	}

	if ( !_gdi_plus_init)
	{
		_gdi_plus_init = true;	
		m_hwnd = _hwnd;
		//GdiplusStartup(&gtoken, &ginp, NULL);
	}	

	
	// make screen capture 
	
	
	int res =0;			
	HBITMAP bmp = GetDesktopImage(window, scalew,scaleh);	
	HDC dc = ::GetDC(0);			

	if (history)
	{
		// compare bitmaps, if equal do not save it.	
		
		if (arr_idx >=0)
		{
			// сравнить картинки если равны то выход
			
			HBITMAP hbmp_old = (HBITMAP)_hbmp_list.GetAt(arr_idx);
			
			if (CompareBitmaps(hbmp_old, bmp ) == true)
				{
				return true;		
				DeleteObject( bmp );
				}
		}
		
		
		if (arr_idx >=0)
		{
			HBITMAP hbmp_old = (HBITMAP)_hbmp_list.GetAt(arr_idx);
			
			_hbmp_list.SetAt(arr_idx, (void*)bmp);
			
			DeleteObject( hbmp_old );
			
		} else 
		{
			_window_list.Add(tag_name);
			_hbmp_list.Add((void*)bmp);
			
		}
		
	}

	//save image as BMP
	TCHAR file_postfix[150], file_path[900]; 
	sprintf(file_postfix, " %s.jpg", tag);
	GetFileName(2, file_path, file_postfix);	
	if (file_name)
		strcpy(file_name, file_path); // return jpg file path if possible

	//strcat(file_path, ".bmp");

	CImage  img;
	img.Attach(bmp);
	img.Save(file_path);
	img.Detach();

	
	/*

	//CLSID jpgClsid;
	//EncoderParameters encoderParameters;
	//ULONG             quality;
	
	WCHAR wpath[901];
	PBITMAPINFO inf;
	inf = CreateBitmapInfoStruct(bmp);		
	res = CreateBMPFile(file_path, inf, bmp, dc );			
	
	::ReleaseDC(0,dc);
	if (!history)
	{
		DeleteObject( bmp );
	}
	

	//return true;
	
	
	MultiByteToWideChar(CP_ACP,0,file_path,-1,wpath,900);
	
	//convert image to JPG
	Image *img = new Image(wpath);
	//Image img(wpath);
	encoderParameters.Count = 1;
	encoderParameters.Parameter[0].Guid = EncoderQuality;
	encoderParameters.Parameter[0].Type = EncoderParameterValueTypeLong;
	encoderParameters.Parameter[0].NumberOfValues = 1;
	
	GetEncoderClsid(L"image/jpeg", &jpgClsid);
	quality = 75;
	encoderParameters.Parameter[0].Value = &quality;
	wpath[lstrlenW(wpath)-7]=0;
	lstrcatW(wpath,L"jpg");
	
	img->Save(wpath, &jpgClsid, &encoderParameters);

	delete img;
	*/

	// delete BMP image 
	//DeleteFile(file_path);
	

	return true;
	

}
