<<<<<<< HEAD
﻿using System;
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
    private recordManager audioManager;

    void Start()
    {
        //Must get the vital's object
        vitalScreen = GameObject.FindWithTag("VitalsUI");
        vitalTrackScript = vitalScreen.GetComponent <trackCanvasScreen>();
        //Must get the notes's object
        noteScreen = GameObject.FindWithTag("NotesUI");
        noteTrackScript = vitalScreen.GetComponent<trackCanvasScreen>();
        //Must get the audio Snipp for recording
        audioManager = this.GetComponent<recordManager>();
        initalizeDictionary();
        initalizeSpeechCommand();
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
        
        mainTrigger.Add("ALEXEI take a note", startRecord);
        mainTrigger.Add("ALEXEI start a note", startRecord);
        mainTrigger.Add("ALEXEI finish note", endRecord);
        mainTrigger.Add("ALEXEI end note", endRecord);
        mainTrigger.Add("ALEXEI redo note", redoRecord);
        mainTrigger.Add("ALEXEI cancel note", cancelRecord);

        keywords = new Dictionary<string, System.Action>();
        keywords.Add("Hide notes", hideNotesDisplay);
        keywords.Add("Hide vitals", hideVitalsDisplay);
        keywords.Add("Display notes", showNotesDisplay);
        keywords.Add("Display vitals", showVitalsDisplay);

        keywords.Add("Take a note", startRecord);
        keywords.Add("Start a note", startRecord);
        keywords.Add("Finish note", endRecord);
        keywords.Add("End note", endRecord);
        keywords.Add("Redo note", redoRecord);
        keywords.Add("Cancel note", cancelRecord);
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

    private void startRecord()
    {
        audioManager.startAudioRecord();
    }

    private void endRecord()
    {
        audioManager.endAudioRecord();
    }

    private void redoRecord()
    {
        audioManager.redoAudio();
    }

    private void cancelRecord()
    {
        audioManager.cancelAudio();
    }

}


=======
﻿using System;
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

>>>>>>> master
