using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
public class TelemetryStream : MonoBehaviour
{
    public jsonDataClass jsnData;
    public UIAjsonDataClass jsnUIAData;
    private int logCount = 0;

    public IEnumerator GetText()
    {
        UnityWebRequest getVitals = UnityWebRequest.Get("http://localhost:3000/api/simulation/state");
        UnityWebRequest getUIAState = UnityWebRequest.Get("http://localhost:3000/api/simulation/uiastate");
        yield return getVitals.SendWebRequest();
        yield return getUIAState.SendWebRequest();
        if (getVitals.isNetworkError || getVitals.isHttpError || getUIAState.isNetworkError || getUIAState.isHttpError)
        {
            if(logCount == 0)
            {
                Debug.Log("Vital Network Error");  
            }
            gameObject.GetComponent<VitalsManager>().networkError = true;
            logCount = 1;
        }
        else
        {
            // Show results as text
            processJsonData(getVitals.downloadHandler.text, getUIAState.downloadHandler.text);
            gameObject.GetComponent<VitalsManager>().networkError = false;
            logCount = 0;
        }
    }
    public void processJsonData(string jsonDataText, string jsonUIADataText)
    {
        jsnData = JsonUtility.FromJson<jsonDataClass>(jsonDataText);
        jsnUIAData = JsonUtility.FromJson<UIAjsonDataClass>(jsonUIADataText);
    }
}