using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recordManager : MonoBehaviour
{
    private audioSnippet audioRecording;
    private audioRecordDisplay audioDisplay;
    private recordCounter audioCounter;
    private bool didUserSelected, isRecording, displaySelection;
    private string selection;
    private float notifyCounter;

    void Awake()
    {
        audioRecording = GetComponent<audioSnippet>();
        audioDisplay = GetComponent<audioRecordDisplay>();
        audioCounter = GetComponent<recordCounter>();
    }

    void Start()
    {
        setUserSelect(false);
        setIsRecording(false);
        setDisplaySelection(false);
        notifyCounter = 0;
    }

    void Update()
    {
        //If audio is recording, preform the counter and display on GUI
        if (getIsRecording())
        {
            audioCounter.setRecordingCounter(audioCounter.getRecordingCounter() + Time.deltaTime);
            audioCounter.updateAudioRecordingCounterText();
            performBlinkingNotification();

            //If the user reaches the limit
            if (audioCounter.getRecordingCounter() >= audioCounter.getMaxRecordingTime())
            {
                endAudioRecord();
            }
        }

        //The recording has just finished, begin the saving counter
        if(getDisplaySelection())
        {
            audioCounter.setSaveRecordingCounter(audioCounter.getSaveRecordingCounter() - Time.deltaTime);
            audioCounter.updateSaveRecordingCounterStatusBar();
           
            //Once the counter reaches 0 seconds and if the user did not speak it will begin autoSave process 
            if (audioCounter.getSaveRecordingCounter() <= 0 && !getUserSelect())
            {
                userDidnotSelectAnOption();
            }
            else if (getUserSelect()) //If the user did speak and the time did not run out yet
            {
                userSelectedAnOption();
            }
        }
    }

    public void startAudioRecord()
    {
        //Ensures that the user cannot say "take not" when its all ready recording and the display options are present
        if (!getIsRecording() && !getDisplaySelection())
        {
            audioRecording.recordStartAudio();
            audioDisplay.changeRecordingDisplay(true);
            audioDisplay.setNotify(false);
            audioDisplay.changeRecordingNotification();
            setIsRecording(true);
        }
    }

    private void userSelectedAnOption()
    {
        //Reset the select condition
        setUserSelect(false);
        //No longer check display options
        setDisplaySelection(false);
        //Reset the save counter
        audioCounter.setSaveRecordingCounter(audioCounter.getSaveWaitTime());
        audioCounter.updateSaveRecordingCounterStatusBar();
        audioDisplay.changeOptionTimer(false);
        //Get rid of Display Options
        audioDisplay.changeRecordingOption(false);

        //Perform speech action
        switch (selection)
        {
            case "redo":
                startAudioRecord();
                break;
            case "cancel":
                //do nothing
                break;
        }
    }

    //The red blinking notificatiion light
    private void performBlinkingNotification()
    {
        notifyCounter += Time.deltaTime;
        if (notifyCounter >= 1.20)
        {
            audioDisplay.changeRecordingNotification();
            notifyCounter = 0;
        }
    }

    private void userDidnotSelectAnOption()
    {
        //No longer check display options
        setDisplaySelection(false);
        //Reset the save counter
        audioCounter.setSaveRecordingCounter(audioCounter.getSaveWaitTime());
        //Display The Save Completed
        activateSaveCompleted();
        Invoke("changeSaveCondition", 3.0f);
    }

    public void endAudioRecord()
    {
        if (getIsRecording())
        {
            audioRecording.recordAudioFinished();
            audioCounter.setRecordingCounter(0);
            setIsRecording(false);
            setDisplaySelection(true);
            activateSelectionOption();
            audioDisplay.changeOptionTimer(true);
        }
    }

    public void redoAudio()
    {
        if(getDisplaySelection())
        { 
        setUserSelect(true);
        setSelectionString("redo");
        }
    }

    public void cancelAudio()
    {
        if(getDisplaySelection())
        {
        setUserSelect(true);
        setSelectionString("cancel");
        }
    }

    private void activateSelectionOption()
    {
        audioDisplay.changeRecordingDisplay(false);
        audioDisplay.changeRecordingOption(true);
        audioDisplay.changeSaveNotification(false);
        audioDisplay.changeRecordingSelection(true);
    }

    private void activateSaveCompleted()
    {
        audioDisplay.changeRecordingOption(false);
        audioDisplay.changeSaveNotification(true);
    }

    private void changeSaveCondition()
    {
        audioDisplay.changeSaveNotification(false);
    }

    //Set if the user spoke during the selection after the note take
    private void setUserSelect(bool isTrue)
    {
        didUserSelected = isTrue;
    }

    private bool getUserSelect()
    {
        return didUserSelected;
    }

    private bool getIsRecording()
    {
        return isRecording;
    }

    private void setIsRecording(bool isActive)
    {
        isRecording = isActive;
    }

    //This allows the system to know that the recording has finished to begin the save counter
    private void setDisplaySelection(bool displaySelection)
    {
        this.displaySelection = displaySelection;
    }

    private bool getDisplaySelection()
    {
        return displaySelection;
    }

    private string getSelectionString()
    {
        return selection;
    }
    
    private void setSelectionString(string selection)
    {
        this.selection = selection;
    }

}

