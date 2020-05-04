using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalsManager : MonoBehaviour
{
    [SerializeField] private int maxOxygen = 500000;
    [SerializeField] private int maxBattery = 30000;
    [SerializeField] private int  currentOxygen, currentBattery, currentPsi, currentHeartRate, currentCo2;
    private GameObject oxygenVitalDispNum, batteryVitalDispNum;
    private GameObject OxygenBar;
    [SerializeField] private SuitVitalBar oxygenStatusBar, batteryStatusBar;
    [SerializeField] private MainScreenVitalManager homeScreen;

    void Awake()
    {
        assignVariables();
    }

    //Assigns the variables once so performance can be quicker than assigining it every update
    private void assignVariables()
    {
        currentOxygen = maxOxygen;
        currentBattery = maxBattery;
        oxygenVitalDispNum = GameObject.Find("Torso/VitalsScreen/VitalBars/OxygenBar/O2 Numerical Value");
        batteryVitalDispNum = GameObject.Find("Torso/VitalsScreen/VitalBars/BatteryBar/Battery Numerical Value");
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
        batteryVitalDispNum.GetComponent<Text>().text = currentBattery.ToString();
    }

}
