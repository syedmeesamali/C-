#pragma once

#include <mmsystem.h>

class CVoiceRecorder
{
public:
	CVoiceRecorder(void);
	void reloadConfig();
	int getPeakMeaterValue();

	int device_dwControlID;
	int device_Id;
	HMIXER  device_hMixer;
	MIXERCONTROL mxc;         // Holds the mixer control data.
public:
	~CVoiceRecorder(void);
};
