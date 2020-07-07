using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainScreenVitalManager : MonoBehaviour
{
    private GameObject BPMMainDispNum, missionTime, lowestTime, vitalsListText;


    void Awake()
    {
        assignVariables();
        vitalsListText.GetComponent<TextMeshProUGUI>().color = Color.red;
    }
    
    //Assigns the variables once so performance can be quicker than assigining it every update
    private void assignVariables()
    {
        BPMMainDispNum = GameObject.Find("/Head/MainScreen/Vitals/HeartRate/Heart-Rate Numerical Value");
        missionTime = GameObject.Find("/Head/MainScreen/Timers/MissionTime");
        lowestTime = GameObject.Find("/Head/MainScreen/Timers/LowestTime");
        vitalsListText = GameObject.Find("/Head/MainScreen/Vitals/VitalsList");
    }

    //Is called from Vitals Manager, every update
    public void updateMainScreen(float currentBPM, string missionTimeString, int lowestCase, string o2Time, string batteryTime, string h2OTime, string vitalsListString)
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
        missionTime.GetComponent<Text>().text = missionTimeString;
        //show the lowest resource time from vitalsmanager
        switch (lowestCase)
        {
            case 1:
                lowestTime.GetComponent<Text>().text = o2Time + " (O2)";
                break;
            case 2:
                lowestTime.GetComponent<Text>().text = batteryTime + " (BATTERY)";
                break;
            case 3:
                lowestTime.GetComponent<Text>().text = h2OTime + " (H2O)";
                break;
        }
        // Display vitals list string
        vitalsListText.GetComponent<TextMeshProUGUI>().text = vitalsListString;
    }
}
