using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
public class TelemetryStream : MonoBehaviour
{
    public jsonDataClass jsnData;

    public IEnumerator GetText()
    {
        UnityWebRequest getVitals = UnityWebRequest.Get("http://localhost:3000/api/simulation/state");
        yield return getVitals.SendWebRequest();

        if (getVitals.isNetworkError || getVitals.isHttpError)
        {
            Debug.Log(getVitals.error);
        }
        else
        {
            // Show results as text
            processJsonData(getVitals.downloadHandler.text);
            //Debug.Log(jsnData.p_h2o_g);
        }
    }
    public void processJsonData(string textFromURL)
    {
        jsnData = JsonUtility.FromJson<jsonDataClass>(textFromURL);
    }
}