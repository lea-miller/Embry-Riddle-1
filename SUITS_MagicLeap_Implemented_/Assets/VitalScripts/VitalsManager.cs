using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VitalsManager : MonoBehaviour
{
     private int maxPO2 = 500000;
     private int maxBattery = 30000;
    [SerializeField] private int currentPO2, currentBattery, currentBPM, currentTSUB;
    private GameObject PO2VitalDispNum, batteryVitalDispNum, BPMDispNum, TSUBDispNum;
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
        BPMDispNum = GameObject.Find("/Torso/VitalsScreen/BPMValue");
        TSUBDispNum = GameObject.Find("/Torso/VitalsScreen/TSUBValue");
    }

    // Update is called once per frame
    void Update()
    {
        changeBattery();
        changePO2();
        changeBPM();
        changeTSUB();
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
        currentPO2 = currentPO2 - 10;
        PO2StatusBar.setVitalsValue(currentPO2);
    }

    private void changeBPM()
    {
        currentBPM = 60;
    }

    private void changeTSUB()
    {
        currentTSUB = 4;
    }
    private void updateVitalScreen()
    {
        PO2VitalDispNum.GetComponent<Text>().text = currentPO2.ToString() + " psia";
        batteryVitalDispNum.GetComponent<Text>().text = currentBattery.ToString() + " Ah";
        BPMDispNum.GetComponent<TextMeshProUGUI>().text = currentBPM.ToString() + " BPM";
        TSUBDispNum.GetComponent<TextMeshProUGUI>().text = currentTSUB.ToString() + " degF";
    }

}
