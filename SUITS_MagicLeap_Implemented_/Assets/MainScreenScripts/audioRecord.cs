using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class audioRecord : MonoBehaviour
{

private bool isRecording;
private int  endCount, startCounter;
private AudioSource _source;

    void Awake()
    {
        _source = GetComponent<AudioSource>();
        endCount = 200;
        isRecording = false;
    }

    public void recording()
    {
        isRecording = isRecording? false:true;
        if(isRecording)
        {
            startCounter = 0;
            StartCoroutine(startCount());
            startMic();
            Debug.Log(isRecording);
        }
        else
        {
            endRecording();
            Debug.Log(isRecording);
        }

    }

    public void endRecording()
    {
      isRecording = false;
      endMic();
      saveRecording();
    }

    private void startMic()
    {
        _source.clip = Microphone.Start("",true,10,48000);
    }

    private void endMic()
    {
        Microphone.End("");
        _source.Stop();
    }

    private void saveRecording()
    {
        Debug.Log("You were saved!");
    }

    //If the time ran out before the user clicked to finish recording
    private void checkCounter()
    {
        if(startCounter == endCount && isRecording)
        {
            endRecording();
        }
    }
    
    //The total time that can be recorded
    private IEnumerator startCount()
    {
        while(isRecording)
        {
            yield return new WaitForSeconds(0);
            startCounter = startCounter + 1;
            checkCounter();
        }
    }
}
