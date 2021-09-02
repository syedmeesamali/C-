#include "stdafx.h"
#include "VoiceRecorder.h"
#include "common1.h"




CVoiceRecorder::CVoiceRecorder(void)
{
	device_hMixer = NULL;



}

void CVoiceRecorder::reloadConfig()
{
	device_Id = ReadReg(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\KidLogger") , "current_mic_device_id", 0 );

	if (device_hMixer)
		mixerClose(device_hMixer);

	MMRESULT rc;              // Return code.
	
	
	MIXERLINE mxl;            // Holds the mixer line data.
	MIXERLINECONTROLS mxlc;   // Obtains the mixer control.

	// Open the mixer. This opens the mixer with a deviceID of 0. If you
	// have a single sound card/mixer, then this will open it. If you have
	// multiple sound cards/mixers, the deviceIDs will be 0, 1, 2, and
	// so on.
	rc = mixerOpen(&device_hMixer, device_Id,0,0,MIXER_OBJECTF_MIXER);
	if (MMSYSERR_NOERROR != rc) {
		// Couldn't open the mixer.
	}

	// Initialize MIXERLINE structure.
	ZeroMemory(&mxl,sizeof(mxl));
	mxl.cbStruct = sizeof(mxl);

	// Specify the line you want to get. You are getting the input line
	// here. If you want to get the output line, you need to use
	// MIXERLINE_COMPONENTTYPE_SRC_WAVEOUT.
	mxl.dwComponentType = MIXERLINE_COMPONENTTYPE_DST_WAVEIN;

	rc = mixerGetLineInfo((HMIXEROBJ)device_hMixer, &mxl,
		MIXER_GETLINEINFOF_COMPONENTTYPE);
	if (MMSYSERR_NOERROR == rc) {
		// Couldn't get the mixer line.
	}

	// Get the control.
    ZeroMemory(&mxlc, sizeof(mxlc));
    mxlc.cbStruct = sizeof(mxlc);
    mxlc.dwLineID = mxl.dwLineID;
    mxlc.dwControlType = MIXERCONTROL_CONTROLTYPE_PEAKMETER;
    mxlc.cControls = 1;
    mxlc.cbmxctrl = sizeof(mxc);
    mxlc.pamxctrl = &mxc;
    ZeroMemory(&mxc, sizeof(mxc));
    mxc.cbStruct = sizeof(mxc);
    rc = mixerGetLineControls((HMIXEROBJ)device_hMixer,&mxlc,
                               MIXER_GETLINECONTROLSF_ONEBYTYPE);
    if (MMSYSERR_NOERROR != rc) {
        // Couldn't get the control.
    }

	device_dwControlID = mxc.dwControlID;


}

int CVoiceRecorder::getPeakMeaterValue()
{
	// After successfully getting the peakmeter control, the volume range
    // will be specified by mxc.Bounds.lMinimum to mxc.Bounds.lMaximum.

	if (device_hMixer == NULL)
		reloadConfig();

	 MMRESULT rc;
    MIXERCONTROLDETAILS mxcd;             // Gets the control values.
    MIXERCONTROLDETAILS_SIGNED volStruct; // Gets the control values.
    long volume;                          // Holds the final volume value.

    // Initialize the MIXERCONTROLDETAILS structure
    ZeroMemory(&mxcd, sizeof(mxcd));
    mxcd.cbStruct = sizeof(mxcd);
    mxcd.cbDetails = sizeof(volStruct);
    mxcd.dwControlID = device_dwControlID;
    mxcd.paDetails = &volStruct;
    mxcd.cChannels = 1;

    // Get the current value of the peakmeter control. Typically, you
    // would set a timer in your program to query the volume every 10th
    // of a second or so.
    rc = mixerGetControlDetails((HMIXEROBJ)device_hMixer, &mxcd,
                                 MIXER_GETCONTROLDETAILSF_VALUE);
    if (MMSYSERR_NOERROR == rc) {
        // Couldn't get the current volume.
    }
    volume = volStruct.lValue;

    // Get the absolute value of the volume.
    if (volume < 0)
        volume = -volume;

	float per_percent = (float)mxc.Bounds.lMaximum / (float)100;
	if (per_percent ==0)
		return volume;

	return (float)volume / (float)per_percent ;  

}

CVoiceRecorder::~CVoiceRecorder(void)
{
}
