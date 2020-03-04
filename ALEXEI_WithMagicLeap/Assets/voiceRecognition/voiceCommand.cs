using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class voiceCommand : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private KeywordRecognizer mainTriggerRecognizer;
    private Dictionary<string, System.Action> mainTrigger;
    private Dictionary<string, System.Action> keywords;
    public GameObject vitalScreen, homeScreen, noteScreen, taskScreen;

    void Start()
    {

        initalizeDictionary();
        initalizeSpeechCommand();
    }

    private void initalizeDictionary()
    {
        mainTrigger = new Dictionary<string, System.Action>();
        mainTrigger.Add("ALEXEI start up", startUp);
        mainTrigger.Add("ALEXEI over and out", closeDown);
        mainTrigger.Add("ALEXEI display suit vitals", changeToVitalsScreen);
        mainTrigger.Add("ALEXEI display home screen", changeToMainScreen);
        mainTrigger.Add("ALEXEI display notes screen", changeToNoteScreen);
        mainTrigger.Add("ALEXEI display tasks screen", changeToTaskScreen);
        mainTrigger.Add("ALEXEI show home screen", changeToMainScreen);
        mainTrigger.Add("ALEXEI show suit vitals screen", changeToVitalsScreen);
        mainTrigger.Add("ALEXEI show notes screen", changeToNoteScreen);
        mainTrigger.Add("ALEXEI show tasks screen", changeToTaskScreen);
        mainTrigger.Add("ALEXEI take me home", changeToMainScreen);

        keywords = new Dictionary<string, System.Action>();
        keywords.Add("Display suit vitals", changeToVitalsScreen);
        keywords.Add("Dispaly main screen", changeToMainScreen);
        keywords.Add("Display notes screen", changeToNoteScreen);
        keywords.Add("Display tasks screen", changeToTaskScreen);
        keywords.Add("Show suit vitals", changeToVitalsScreen);
        keywords.Add("Show main screen", changeToMainScreen);
        keywords.Add("Show notes screen", changeToNoteScreen);
        keywords.Add("Show tasks screen", changeToTaskScreen);
        keywords.Add("Take me home", changeToMainScreen);
    }

    private void initalizeSpeechCommand()
    {

        mainTriggerRecognizer = new KeywordRecognizer(mainTrigger.Keys.ToArray());
        mainTriggerRecognizer.OnPhraseRecognized += TriggerRecognizedSpeech;
        mainTriggerRecognizer.Start();
    }

    private void startUp()
    {
        if (keywordRecognizer == null)
        {
            keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
            keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        }
        keywordRecognizer.Start();
    }

    private void TriggerRecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        mainTrigger[speech.text].Invoke();
    }


    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        keywords[speech.text].Invoke();
    }

    private void closeDown()
    {
        keywordRecognizer.Stop();
    }

    private void changeToVitalsScreen()
    {
        changeScene(false, true, false, false);
    }

    private void changeToNoteScreen()
    {
        changeScene(false, false, true, false);
    }

    private void changeToTaskScreen()
    {
        changeScene(false, false, false, true);
    }

    private void changeToMainScreen()
    {
        changeScene(true, false, false, false);
    }

    private void changeScene(Boolean isHomeScreenActive, Boolean isVitalScreenActive, Boolean isNoteScreenActive, Boolean isTaskScreenActive)
    {
        homeScreen.SetActive(isHomeScreenActive);
        vitalScreen.SetActive(isVitalScreenActive);
        noteScreen.SetActive(isNoteScreenActive);
        taskScreen.SetActive(isTaskScreenActive);
    }
}

