using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class audioRecord : MonoBehaviour
{

private bool isRecording;
private int  endCount, startCounter, savedCounter;
private AudioSource _source;
private List<string> savedNames;
private string defualtName, currentName;
public audioRecordDisplay display;

    void Awake()
    {
        defualtName = "audioRecording";
        savedNames = new List<string>();
        _source = GetComponent<AudioSource>();
        endCount = 200;
        savedCounter = 0;
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
        }
        else
        {
            endRecording();
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
        display.changeRecordingDisplay(true);
        _source.clip = Microphone.Start("",true,10,48000);
    }

    private void endMic()
    {
        Microphone.End("");
        _source.Stop();
    }

    private void saveRecording()
    {
        checkSaveFile();
        SavWav.Save(currentName, _source.clip);
        display.changeRecordingDisplay(false);          
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

    //Check SaveFile Exists
    private void checkSaveFile()
    {
        savedCounter = savedCounter + 1;
        if(savedNames.Contains(currentName))
        {
            currentName = defualtName + "_" + savedCounter;
            savedNames.Add(currentName);
            Debug.Log(savedNames[savedCounter-1]);
        }else
        {
            currentName = defualtName;
            savedNames.Add(currentName);
        }

    }

}
