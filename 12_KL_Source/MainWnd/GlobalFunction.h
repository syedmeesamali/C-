
#pragma once

typedef HRESULT (STDAPICALLTYPE *LPFNOBJECTFROMLRESULT)(LRESULT lResult, REFIID riid, WPARAM wParam, void** ppvObject);

extern LPFNOBJECTFROMLRESULT pfObjectFromLresult;
void dump_urls_to_log();
