using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalsManager : MonoBehaviour
{
     private int maxPO2 = 500000;
     private int maxBattery = 30000;
    [SerializeField] private int  currentPO2, currentBattery, currentPsi, currentHeartRate, currentCo2;
    private GameObject PO2VitalDispNum, batteryVitalDispNum;
    [SerializeField] private SuitVitalBar batteryStatusBar, PO2StatusBar;
    [SerializeField] private MainScreenVitalManager homeScreen;

    void Awake()
    {
        assignVariables();
    }

    //Assigns the variables once so performance can be quicker than assigining it every update
    private void assignVariables()
    {
        currentPO2 = maxPO2;
        currentBattery = maxBattery;
        PO2VitalDispNum = GameObject.Find("/Torso/VitalsScreen/PO2BarBody/PO2BarSlider/PO2NumericalValue");
        batteryVitalDispNum = GameObject.Find("/Torso/VitalsScreen/BatteryBarBody/BatteryBarSlider/BatteryNumericalValue");
    }

    // Update is called once per frame
    void Update()
    {
        changeBattery();
        changePO2();
        changeHeartRate();
        changeCo2();
        changePsi();
        updateVitalScreen();
        //homeScreen.updateMainScreen(currentPO2,currentCo2,currentPsi,currentHeartRate);
    }

    private void changeBattery()
    {
        currentBattery = currentBattery - 1;
        batteryStatusBar.setVitalsValue(currentBattery);
    }

    private void changePO2()
    {
        currentPO2 = currentPO2 - 1000;
        PO2StatusBar.setVitalsValue(currentPO2);
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
        PO2VitalDispNum.GetComponent<Text>().text = currentPO2.ToString() + " psia";
        batteryVitalDispNum.GetComponent<Text>().text = currentBattery.ToString() + " Ah";
    }

}
