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
    public GameObject vitalScreen, homeScreen;

    void Start()
    {

        vitalScreen.SetActive(false);
        initalizeDictionary();
        initalizeSpeechCommand();
    }

    private void initalizeDictionary()
    {
            mainTrigger = new Dictionary<string, System.Action>();
            mainTrigger.Add("ALEXEI start up", startUp);
            mainTrigger.Add("ALEXEI over and out", closeDown);

            keywords = new Dictionary<string, System.Action>();
            keywords.Add("Display suit vitals", changeSuitVitalsScene);
            keywords.Add("Dispaly main screen", changeToMainScene);
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
            keywordRecognizer.Start();
        }
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

    private void changeSuitVitalsScene()
    {
        vitalScreen.SetActive(true);
        homeScreen.SetActive(false);
    }

    private void closeDown()
    {
        keywordRecognizer.Stop();
    }

    private void changeToMainScene()
    {
       homeScreen.SetActive(true);
       vitalScreen.SetActive(false);
    }
}

