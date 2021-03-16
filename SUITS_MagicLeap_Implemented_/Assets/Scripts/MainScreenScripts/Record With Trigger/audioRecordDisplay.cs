using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioRecordDisplay : MonoBehaviour
{
    private GameObject recordDisplay, recordSelection, recordOption,recordSave,
        recordSaveTimer, recordSaveBackground, recordNotify, recordCounter;
    private bool isNotify;
    private GameObject counterRecordTextObject;
    private Text counterRecordText;

    void Awake()
    {
        recordDisplay = GameObject.FindWithTag("Recording Display");
        recordSelection = GameObject.FindWithTag("Recording Selection");
        recordOption = GameObject.FindWithTag("Recording Options");
        recordSave = GameObject.FindWithTag("Recording Saved");
        recordSaveTimer = GameObject.FindWithTag("Recording Save Timer");
        recordSaveBackground = GameObject.FindWithTag("Recording Save Background");
        recordNotify = GameObject.FindWithTag("Recording Notification");
        counterRecordTextObject = GameObject.FindGameObjectWithTag("Record Counter");
        counterRecordText = counterRecordTextObject.GetComponent<Text>();

        recordDisplay.SetActive(false);
        recordSelection.SetActive(false);
    }

    void Start()
    {
        setNotify(false);
    }

    public void changeRecordingDisplay(bool isActive)
    {
        recordDisplay.SetActive(isActive);
    }

    public void changeRecordingSelection(bool isActive)
    {
        recordSelection.SetActive(isActive);
    }

    public void changeSaveNotification(bool isActive)
    {
        recordSave.SetActive(isActive);
    }

    public void changeRecordingOption(bool isActive)
    {
        recordOption.SetActive(isActive);
    }

    public void changeOptionTimer(bool isActive)
    {
        recordSaveTimer.SetActive(isActive);
        recordSaveBackground.SetActive(isActive);
    }

    public void changeRecordingNotification()
    {
        isNotify = !(isNotify);
        recordNotify.SetActive(isNotify);
    }

    public void setNotify(bool isActive)
    {
        isNotify = isActive;
    }

    public void displayCounterGUI(float startCounter)
    {
        counterRecordText.text = startCounter.ToString();
    }
}
