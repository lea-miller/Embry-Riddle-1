using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class audioRecord : MonoBehaviour
{

private bool isRecording;
private int savedCounter;
private AudioSource _source;
private List<string> savedNames;
private string defualtName, currentName;
public audioRecordDisplay display;
private audioTimer timer;
private List<AudioClip> recordList;

    void Awake()
    {
   
        recordList = new List<AudioClip>();
        _source = GetComponent<AudioSource>();
        timer = new audioTimer();
        savedNames = new List<string>();
        isRecording = false;
        defualtName = "audioRecording";
        savedCounter = 0;
    }

    public void recording()
    {
        isRecording = isRecording? false:true;
        if(isRecording)
        {
            timer.setStartCount(0);
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
        _source.clip = Microphone.Start("",false,(int)timer.getEndCount(),48000);
    }

    private void endMic()
    {
        Microphone.End("");
        _source.Stop();
    }

    //Saves a temporary Location of it until system shuts down
    private void saveRecording()
    {
        checkSaveFile();
        recordList.Add(_source.clip);
        //export it
        display.changeRecordingDisplay(false);          
    }

    //If the time ran out before the user clicked to finish recording
    private void checkCounter()
    {   
        if(timer.getStartCount() > timer.getEndCount() && isRecording)
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
            timer.setStartCount(timer.getStartCount());
            display.displayCounterGUI(timer.getStartCount());
            checkCounter();
        }
    }

    //Check SaveFile Exists
    private void checkSaveFile()
    {
        timer.setStartCount(timer.getStartCount());
        if(savedNames.Contains(currentName))
        {
            savedCounter = savedCounter + 1;
            currentName = defualtName + "_" + savedCounter;
            savedNames.Add(currentName);
        }else
        {
            currentName = defualtName;
            savedNames.Add(currentName);
        }

    }


}
