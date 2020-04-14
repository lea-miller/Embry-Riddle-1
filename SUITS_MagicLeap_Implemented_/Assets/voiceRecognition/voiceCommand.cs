using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class voiceCommand : MonoBehaviour
{
    public GameObject mainCamera;
    private KeywordRecognizer keywordRecognizer;
    private KeywordRecognizer mainTriggerRecognizer;
    private Dictionary<string, System.Action> mainTrigger;
    private Dictionary<string, System.Action> keywords;
    private GameObject vitalScreen, noteScreen;
    private trackCanvasScreen vitalTrackScript, noteTrackScript;

    void Start()
    {
        initalizeDictionary();
        initalizeSpeechCommand();
        
        //Must get the vital's object
        vitalScreen = GameObject.FindWithTag("VitalsUI");
        vitalTrackScript = vitalScreen.GetComponent <trackCanvasScreen>();
        //Must get the notes's object
        noteScreen = GameObject.FindWithTag("NotesUI");
        noteTrackScript = vitalScreen.GetComponent<trackCanvasScreen>();
    }
    
    private void initalizeDictionary()
    {
        mainTrigger = new Dictionary<string, System.Action>();
        mainTrigger.Add("ALEXEI start up", startUp);
        mainTrigger.Add("ALEXEI shutdown", closeDown);
        mainTrigger.Add("ALEXEI hide notes", hideNotesDisplay);
        mainTrigger.Add("ALEXEI hide vitals", hideVitalsDisplay);
        mainTrigger.Add("AELEXI display notes", showNotesDisplay);
        mainTrigger.Add("ALEXEI display vitals", showVitalsDisplay);

        keywords = new Dictionary<string, System.Action>();
        keywords.Add("Hide notes", hideNotesDisplay);
        keywords.Add("Hide vitals", hideVitalsDisplay);
        keywords.Add("Display notes", showNotesDisplay);
        keywords.Add("Display vitals", showVitalsDisplay);
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

    private void hideNotesDisplay()
    {
        noteScreen.SetActive(false);
    }

    private void showNotesDisplay()
    {
        noteScreen.SetActive(true);
    }

    private void hideVitalsDisplay()
    {
       vitalScreen.SetActive(false);
    }

    private void showVitalsDisplay()
    {
        vitalScreen.SetActive(true);
    }

}

