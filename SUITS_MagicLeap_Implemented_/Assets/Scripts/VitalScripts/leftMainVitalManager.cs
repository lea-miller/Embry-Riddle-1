using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class leftMainVitalManager : MonoBehaviour
{
    private GameObject BPMMainDispNum, missionTime, vitalsListText;

    void OnEnable()
    {
        assignVariables();
        vitalsListText.GetComponent<TextMeshProUGUI>().color = Color.red;
    }
    
    //Assigns the variables once so performance can be quicker than assigining it every update
    private void assignVariables()
    {
        BPMMainDispNum = GameObject.Find("Vitals/HeartRate/Heart-Rate Numerical ValueLeft");
        missionTime = GameObject.Find("Vital Timers/EVA StartupTimeLeft");
        vitalsListText = GameObject.Find("Vitals/VitalsListLeft");
    }

    //Is called from Vitals Manager, every update
    public void updatePanelScreen(float currentBPM, string missionTimeString, string vitalsListString)
    {
        BPMMainDispNum.GetComponent<Text>().text = currentBPM.ToString();
        if (currentBPM > 100)
        {
            BPMMainDispNum.GetComponent<Text>().color = Color.red;
        }
        else
        {
            BPMMainDispNum.GetComponent<Text>().color = Color.white;
        }
        //show mission time
        missionTime.GetComponent<Text>().text = "T+" + missionTimeString;
        // Display vitals list string
        vitalsListText.GetComponent<TextMeshProUGUI>().text = vitalsListString;
    }
}
