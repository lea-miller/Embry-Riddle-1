using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenVitalManager : MonoBehaviour
{
    private GameObject oxygenMainDispNum, batteryMainDispNum, heartMainRateDispNum, carbonMainDispNum, psiMainDispNum;

    void Awake()
    {
        assignVariables();
    }
    
    //Assigns the variables once so performance can be quicker than assigining it every update
    private void assignVariables()
    {
        oxygenMainDispNum = GameObject.FindWithTag("O2MainDispValue");
        heartMainRateDispNum = GameObject.FindWithTag("heartMainDispValue");
        carbonMainDispNum = GameObject.FindWithTag("co2MainDispValue");
        psiMainDispNum = GameObject.FindWithTag("psiMainDispValue");
    }

    //Is called from Vitals Manager, every update
    public void updateMainScreen(int currentOxygen, int currentCo2, int currentPsi, int currentHeartRate)
    {
        oxygenMainDispNum.GetComponent<Text>().text = currentOxygen.ToString();
        carbonMainDispNum.GetComponent<Text>().text = currentCo2.ToString();
        psiMainDispNum.GetComponent<Text>().text = currentPsi.ToString();
        if (Random.Range(1, 3) == 2)
        {
            heartMainRateDispNum.GetComponent<Text>().text = currentHeartRate.ToString();
        }
        
    }
}
