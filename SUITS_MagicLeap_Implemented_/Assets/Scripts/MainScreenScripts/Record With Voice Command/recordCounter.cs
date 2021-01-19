using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recordCounter : MonoBehaviour
{
    public int maxRecordingTime, saveWaitTime;
    private Text counterRecordText;
	private float currentAudioCounter,currentSaveCounter;
    private GameObject counterRecordTextObject, saveCounterBackgroundObject, saveCounterObject;
    private audioRecordDisplay recordDisplay;
    private Image backgroundSaveTimer, saveTimer;

    // Start is called before the first frame update
    void Awake()
    {
        counterRecordTextObject = GameObject.FindGameObjectWithTag("Record Counter");
        saveCounterBackgroundObject = GameObject.FindGameObjectWithTag("Recording Save Background");
        saveCounterObject = GameObject.FindGameObjectWithTag("Recording Save Timer");
        
        recordDisplay = GetComponent<audioRecordDisplay>();
        counterRecordText = counterRecordTextObject.GetComponent<Text>();
    }

    void Start()
    {
        setSaveRecordingCounter(saveWaitTime);
        setRecordingCounter(0);
    }
    
    //TODO: Move to audioDisplay
    public void updateAudioRecordingCounterText()
    {
        int timeTemp = (int)currentAudioCounter;
        counterRecordText.text = timeTemp.ToString();
    }
    //TODO: Move to audioDisplay
    public void updateSaveRecordingCounterStatusBar()
    {
        backgroundSaveTimer = saveCounterBackgroundObject.GetComponent<Image>();
        backgroundSaveTimer.fillAmount = currentSaveCounter / 10;
        saveTimer = saveCounterObject.GetComponent<Image>();
        saveTimer.fillAmount = currentSaveCounter / 10;
    }

    public float getSaveRecordingCounter()
    {
        return currentSaveCounter;
    }

    public void setSaveRecordingCounter(float saveCounter)
    {
        this.currentSaveCounter = saveCounter;
    }

    public void setRecordingCounter(float currentAudioCounter)
    {
        this.currentAudioCounter = currentAudioCounter;
    }

    public float getRecordingCounter()
    {
        return currentAudioCounter;
    }

    public int getMaxRecordingTime()
    {
        return maxRecordingTime;
    }

    public int getSaveWaitTime()
    {
        return saveWaitTime;
    }
}
