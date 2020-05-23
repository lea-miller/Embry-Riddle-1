using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenVitalManager : MonoBehaviour
{
    private GameObject BPMMainDispNum, missionTime, lowestTime;

    void Awake()
    {
        assignVariables();
    }
    
    //Assigns the variables once so performance can be quicker than assigining it every update
    private void assignVariables()
    {
        BPMMainDispNum = GameObject.Find("/Head/MainScreen/Vitals/HeartRate/Heart-Rate Numerical Value");
        missionTime = GameObject.Find("/Head/MainScreen/Timers/MissionTime");
        lowestTime = GameObject.Find("/Head/MainScreen/Timers/LowestTime");
    }

    //Is called from Vitals Manager, every update
    public void updateMainScreen(float currentBPM, string missionTimeString, int lowestCase, string o2Time, string batteryTime, string h2OTime)
    {
        BPMMainDispNum.GetComponent<Text>().text = currentBPM.ToString();
        missionTime.GetComponent<Text>().text = missionTimeString;
        switch (lowestCase)
        {
            case 1:
                lowestTime.GetComponent<Text>().text = o2Time;
                break;
            case 2:
                lowestTime.GetComponent<Text>().text = batteryTime;
                break;
            case 3:
                lowestTime.GetComponent<Text>().text = h2OTime;
                break;
        }
    }
}
