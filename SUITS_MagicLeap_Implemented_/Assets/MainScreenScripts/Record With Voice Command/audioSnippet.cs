using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class audioSnippet :  MonoBehaviour
{
    private AudioSource source;
    private recordCounter recordCounter;
	
    void Awake()
    {
        source = GetComponent<AudioSource>();
        recordCounter = GetComponent<recordCounter>();

		if (Microphone.devices.Length <= 0)
        {
            //Throw a warning message at the console if there isn't  
            Debug.LogWarning("Microphone not connected!");
        }
    }

    public void recordStartAudio()
    {
            source.Stop();
            source.clip = Microphone.Start("", false, recordCounter.getMaxRecordingTime(), 44100);
    }

    public void recordAudioFinished()
    {
            Microphone.End("");
    }

    //TODO: Will have to wrap into a prossible thread
    public void recordSaveAudio()
    {
            SavWav.Save("audio1", source.clip);           
    }

    public void recordPlayAudio()
    {
            Microphone.End("");
            source.Play();
    }
}
