# Microsoft Developer Studio Project File - Name="MainWnd" - Package Owner=<4>
# Microsoft Developer Studio Generated Build File, Format Version 6.00
# ** DO NOT EDIT **

# TARGTYPE "Win32 (x86) Application" 0x0101

CFG=MainWnd - Win32 Release
!MESSAGE This is not a valid makefile. To build this project using NMAKE,
!MESSAGE use the Export Makefile command and run
!MESSAGE 
!MESSAGE NMAKE /f "MainWnd.mak".
!MESSAGE 
!MESSAGE You can specify a configuration when running NMAKE
!MESSAGE by defining the macro CFG on the command line. For example:
!MESSAGE 
!MESSAGE NMAKE /f "MainWnd.mak" CFG="MainWnd - Win32 Release"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "MainWnd - Win32 Release" (based on "Win32 (x86) Application")
!MESSAGE "MainWnd - Win32 Debug" (based on "Win32 (x86) Application")
!MESSAGE 

# Begin Project
# PROP AllowPerConfigDependencies 0
# PROP Scc_ProjName ""
# PROP Scc_LocalPath ""
CPP=cl.exe
MTL=midl.exe
RSC=rc.exe

!IF  "$(CFG)" == "MainWnd - Win32 Release"

# PROP BASE Use_MFC 5
# PROP BASE Use_Debug_Libraries 0
# PROP BASE Output_Dir "Release"
# PROP BASE Intermediate_Dir "Release"
# PROP BASE Target_Dir ""
# PROP Use_MFC 5
# PROP Use_Debug_Libraries 0
# PROP Output_Dir "Release"
# PROP Intermediate_Dir "Release"
# PROP Ignore_Export_Lib 0
# PROP Target_Dir ""
# ADD BASE CPP /nologo /MT /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /Yu"stdafx.h" /FD /c
# ADD CPP /nologo /MT /W3 /GX /O2 /I "..\hooks" /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_MBCS" /Yu"stdafx.h" /FD /c
# SUBTRACT CPP /Fr
# ADD BASE MTL /nologo /D "NDEBUG" /mktyplib203 /win32
# ADD MTL /nologo /D "NDEBUG" /mktyplib203 /win32
# ADD BASE RSC /l 0x419 /d "NDEBUG"
# ADD RSC /l 0x419 /i "R:\rohos\library\version\\" /d "NDEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LINK32=link.exe
# ADD BASE LINK32 /nologo /subsystem:windows /machine:I386
# ADD LINK32 ../hooks/release/kidlog.lib version.lib Shlwapi.lib Htmlhelp.lib nafxcw.lib shell32.lib Userenv.lib Oleacc.lib psapi.lib gdi32.lib gdiplus.lib /nologo /subsystem:windows /pdb:none /machine:I386 /nodefaultlib:"nafxcw.lib" /out:"Release/Kidlogger.exe"
# SUBTRACT LINK32 /debug

!ELSEIF  "$(CFG)" == "MainWnd - Win32 Debug"

# PROP BASE Use_MFC 5
# PROP BASE Use_Debug_Libraries 0
# PROP BASE Output_Dir "MainWnd___Win32_Debug0"
# PROP BASE Intermediate_Dir "MainWnd___Win32_Debug0"
# PROP BASE Ignore_Export_Lib 0
# PROP BASE Target_Dir ""
# PROP Use_MFC 5
# PROP Use_Debug_Libraries 0
# PROP Output_Dir "MainWnd___Win32_Debug0"
# PROP Intermediate_Dir "MainWnd___Win32_Debug0"
# PROP Ignore_Export_Lib 0
# PROP Target_Dir ""
# ADD BASE CPP /nologo /MT /W3 /GX /O2 /I "..\hooks" /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_MBCS" /Yu"stdafx.h" /FD /c
# SUBTRACT BASE CPP /Fr
# ADD CPP /nologo /MT /W3 /GX /ZI /I "..\hooks" /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_MBCS" /Yu"stdafx.h" /FD /c
# ADD BASE MTL /nologo /D "NDEBUG" /mktyplib203 /win32
# ADD MTL /nologo /D "NDEBUG" /mktyplib203 /win32
# ADD BASE RSC /l 0x419 /d "NDEBUG"
# ADD RSC /l 0x419 /i "R:\rohos\library\version\\" /d "NDEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LINK32=link.exe
# ADD BASE LINK32 ../hooks/release/kidlog.lib version.lib Shlwapi.lib Htmlhelp.lib nafxcw.lib shell32.lib Userenv.lib /nologo /subsystem:windows /pdb:none /machine:I386 /nodefaultlib:"nafxcw.lib" /out:"Release/Kidlogger.exe"
# SUBTRACT BASE LINK32 /debug
# ADD LINK32 ../hooks/release/kidlog.lib version.lib Shlwapi.lib Htmlhelp.lib nafxcw.lib shell32.lib Userenv.lib Oleacc.lib psapi.lib gdi32.lib gdiplus.lib /nologo /subsystem:windows /pdb:none /debug /machine:I386 /nodefaultlib:"nafxcw.lib" /out:"Debug/Kidlogger.exe"

!ENDIF 

# Begin Target

# Name "MainWnd - Win32 Release"
# Name "MainWnd - Win32 Debug"
# Begin Group "Source Files"

# PROP Default_Filter "cpp;c;cxx;rc;def;r;odl;idl;hpj;bat"
# Begin Group "IHTML"

# PROP Default_Filter ""
# End Group
# Begin Source File

SOURCE=..\hooks\common1.cpp
# SUBTRACT CPP /YX /Yc /Yu
# End Source File
# Begin Source File

SOURCE=.\Dlg_Options.cpp
# End Source File
# Begin Source File

SOURCE=.\Dlg_Options_SoundRec.cpp
# End Source File
# Begin Source File

SOURCE=.\Dlg_OptionsCapture.cpp
# End Source File
# Begin Source File

SOURCE=.\Dlg_pass.cpp
# End Source File
# Begin Source File

SOURCE=.\Dlg_SafeLogReader.cpp
# End Source File
# Begin Source File

SOURCE=.\Dlg_SMTP.cpp
# End Source File
# Begin Source File

SOURCE=.\GlobalFunction.cpp
# End Source File
# Begin Source File

SOURCE=.\GlobalFunction.h
# End Source File
# Begin Source File

SOURCE=.\MainWnd.cpp
# End Source File
# Begin Source File

SOURCE=.\MainWnd.rc
# End Source File
# Begin Source File

SOURCE=.\MainWndDlg.cpp
# End Source File
# Begin Source File

SOURCE=.\Rijndael.cpp
# End Source File
# Begin Source File

SOURCE=.\ScreenCapture.cpp
# End Source File
# Begin Source File

SOURCE=.\StdAfx.cpp
# ADD CPP /Yc"stdafx.h"
# End Source File
# Begin Source File

SOURCE=.\stealth.cpp
# End Source File
# Begin Source File

SOURCE=.\USBCopy.cpp
# End Source File
# End Group
# Begin Group "Header Files"

# PROP Default_Filter "h;hpp;hxx;hm;inl"
# Begin Source File

SOURCE=..\hooks\common1.h
# End Source File
# Begin Source File

SOURCE=.\Dlg_Options.h
# End Source File
# Begin Source File

SOURCE=.\Dlg_Options_SoundRec.h
# End Source File
# Begin Source File

SOURCE=.\Dlg_OptionsCapture.h
# End Source File
# Begin Source File

SOURCE=.\Dlg_pass.h
# End Source File
# Begin Source File

SOURCE=.\Dlg_SafeLogReader.h
# End Source File
# Begin Source File

SOURCE=.\Dlg_SMTP.h
# End Source File
# Begin Source File

SOURCE=.\hashverf.h
# End Source File
# Begin Source File

SOURCE=.\MainWnd.h
# End Source File
# Begin Source File

SOURCE=.\MainWndDlg.h
# End Source File
# Begin Source File

SOURCE=.\Resource.h
# End Source File
# Begin Source File

SOURCE=.\ScreenCapture.h
# End Source File
# Begin Source File

SOURCE=.\StdAfx.h
# End Source File
# Begin Source File

SOURCE=.\USBCopy.h
# End Source File
# End Group
# Begin Group "Resource Files"

# PROP Default_Filter "ico;cur;bmp;dlg;rc2;rct;bin;rgs;gif;jpg;jpeg;jpe"
# Begin Source File

SOURCE=".\res\folder-files-16.ico"
# End Source File
# Begin Source File

SOURCE=".\res\folder-files-32.ico"
# End Source File
# Begin Source File

SOURCE=.\res\icon1.ico
# End Source File
# Begin Source File

SOURCE=.\res\icon10.ico
# End Source File
# Begin Source File

SOURCE=.\res\icon2.ico
# End Source File
# Begin Source File

SOURCE=.\res\icon3.ico
# End Source File
# Begin Source File

SOURCE=.\res\icon9.ico
# End Source File
# Begin Source File

SOURCE=.\res\MainWnd.ico
# End Source File
# Begin Source File

SOURCE=.\res\MainWnd.rc2
# End Source File
# Begin Source File

SOURCE=".\res\options-32.ico"
# End Source File
# Begin Source File

SOURCE=.\res\password.ico
# End Source File
# Begin Source File

SOURCE=".\res\start-logs-32.ico"
# End Source File
# End Group
# Begin Source File

SOURCE=.\ReadMe.txt
# End Source File
# End Target
# End Project
