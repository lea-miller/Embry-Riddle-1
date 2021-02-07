﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
public class TelemetryStream : MonoBehaviour
{
    public jsonDataClass jsnData;
    public UIAjsonDataClass jsnUIAData; 

    public IEnumerator GetText()
    {
        UnityWebRequest getVitals = UnityWebRequest.Get("http://localhost:3000/api/simulation/state");
        UnityWebRequest getUIAState = UnityWebRequest.Get("http://localhost:3000/api/simulation/uiastate");
        yield return getVitals.SendWebRequest();
        yield return getUIAState.SendWebRequest();

        if (getVitals.isNetworkError || getVitals.isHttpError || getUIAState.isNetworkError || getUIAState.isHttpError)
        {
            Debug.Log("Vital Newtwork Error");
        }
        else
        {
            // Show results as text
            processJsonData(getVitals.downloadHandler.text, getUIAState.downloadHandler.text);
        }
    }
    public void processJsonData(string jsonDataText, string jsonUIADataText)
    {
        jsnData = JsonUtility.FromJson<jsonDataClass>(jsonDataText);
        jsnUIAData = JsonUtility.FromJson<UIAjsonDataClass>(jsonUIADataText);
    }
}