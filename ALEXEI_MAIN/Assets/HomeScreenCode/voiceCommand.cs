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
    private Dictionary<string, System.Action> mainTrigger = new Dictionary<string, System.Action>();
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();


    void Start()
    {
        initalizeSpeechCommand();
    }

    private void initalizeSpeechCommand()
    {
        mainTrigger.Add("ALEXEI start up", startUp);
        mainTrigger.Add("ALEXEI over and out", closeDown);

        keywords.Add("Go to scene two", changeScene);

        if (mainTriggerRecognizer == null)
        {
            mainTriggerRecognizer = new KeywordRecognizer(mainTrigger.Keys.ToArray());
            mainTriggerRecognizer.OnPhraseRecognized += TriggerRecognizedSpeech;
            mainTriggerRecognizer.Start();
        }
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

    private void changeScene()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("SuitMetricScene");
    }

    private void closeDown()
    {
        keywordRecognizer.Stop();
    }

}

