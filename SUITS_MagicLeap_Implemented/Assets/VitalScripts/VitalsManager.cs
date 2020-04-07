using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalsManager : MonoBehaviour
{

    public int maxOxygen, maxBattery = 5000000;
    private int  currentOxygen, currentBattery, currentPsi, currentHeartRate, currentCo2;
    private GameObject oxygenVitalDispNum;
    public SuitVitalBar oxygenStatusBar, batteryStatusBar;
    public MainScreenVitalManager homeScreen;

    void Awake()
    {
        currentOxygen = maxOxygen;
        currentBattery = maxBattery;
        oxygenStatusBar.setMaxVitalsValue(maxOxygen);
        batteryStatusBar.setMaxVitalsValue(maxBattery);
        assignVariables();
    }

    //Assigns the variables once so performance can be quicker than assigining it every update
    private void assignVariables()
    {
        oxygenVitalDispNum = GameObject.FindWithTag("O2VitalDispValue");
    }

    // Update is called once per frame
    void Update()
    {
        changeBattery();
        changeOxygen();
        changeHeartRate();
        changeCo2();
        changePsi();
        updateVitalScreen();
        homeScreen.updateMainScreen(currentOxygen,currentCo2,currentPsi,currentHeartRate);
    }

    private void changeBattery()
    {
        currentBattery = currentBattery - 10;
        batteryStatusBar.setVitalsValue(currentBattery);
    }

    private void changeOxygen()
    {
        currentOxygen = currentOxygen - 20;
        oxygenStatusBar.setVitalsValue(currentOxygen);
    }

    private void changeHeartRate()
    {
        currentHeartRate = Random.Range(60, 65);
    }

    private void changeCo2()
    {
        currentCo2 = currentCo2 + 20;
    }

    private void changePsi()
    {
        currentPsi = 5;
    }

    private void updateVitalScreen()
    {
        oxygenVitalDispNum.GetComponent<Text>().text = currentOxygen.ToString();
    }

}
