using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VitalsManager : MonoBehaviour
{
    [SerializeField] private int currentPO2, currentPO2Rate, currentBattery, currentBPM, currentTSUB, currentPSOP, currentPSOPRate, currentPSUB, currentPSUIT, currentPH2Og, currentPH2OL, currentVFan;
    private GameObject PO2VitalDispNum, PO2RateDispNum, batteryVitalDispNum, BPMDispNum, TSUBDispNum, PSOPDispNum, PSOPRateDispNum, PSUBDispNum, PSUITDispNum, PH2OgDispNum, PH2OLDispNum, VFanDispNum;
    [SerializeField] private SuitVitalBar batteryStatusBar, PO2StatusBar, PSOPStatusBar, PSUBStatusBar, PSUITStatusBar, PH2OgStatusBar, PH2OLStatusBar, VFanStatusBar;
    [SerializeField] private MainScreenVitalManager homeScreen;

    void Awake()
    {
        assignVariables();
    }

    //Assigns the variables once so performance can be quicker than assigining it every update
    private void assignVariables()
    {
        PO2VitalDispNum = GameObject.Find("/Torso/VitalsScreen/PO2BarBody/PO2BarSlider/PO2NumericalValue");
        PO2RateDispNum = GameObject.Find("/Torso/VitalsScreen/PO2Rate");
        batteryVitalDispNum = GameObject.Find("/Torso/VitalsScreen/BatteryBarBody/BatteryBarSlider/BatteryNumericalValue");
        BPMDispNum = GameObject.Find("/Torso/VitalsScreen/BPMValue");
        TSUBDispNum = GameObject.Find("/Torso/VitalsScreen/TSUBValue");
        PSOPDispNum = GameObject.Find("/Torso/VitalsScreen/PSOPBarBody/PSOPBarSlider/PSOPNumericalValue");
        PSOPRateDispNum = GameObject.Find("/Torso/VitalsScreen/PSOPRate");
        PSUBDispNum = GameObject.Find("/Torso/VitalsScreen/PSUBBarBody/PSUBBarSlider/PSUBNumericalValue");
        PSUITDispNum = GameObject.Find("/Torso/VitalsScreen/PSUITBarBody/PSUITBarSlider/PSUITNumericalValue");
        PH2OgDispNum = GameObject.Find("/Torso/VitalsScreen/PH2OgBarBody/PH2OgBarSlider/PH2OgNumericalValue");
        PH2OLDispNum = GameObject.Find("/Torso/VitalsScreen/PH2OLBarBody/PH2OLBarSlider/PH2OLNumericalValue");
        VFanDispNum = GameObject.Find("/Torso/VitalsScreen/VFanBarBody/VFanBarSlider/VFanNumericalValue");
    }

    // Update is called once per frame
    void Update()
    {
        changeBattery();
        changePO2();
        changePO2Rate();
        changePSOP();
        changePSOPRate();
        changeBPM();
        changeTSUB();
        changePSUB();
        changePSUIT();
        changePH2Og();
        changePH2OL();
        changeVFan();
        updateVitalScreen();
        //homeScreen.updateMainScreen(currentPO2,currentCo2,currentPsi,currentHeartRate);
    }

    private void changeBattery()
    {
        currentBattery = 27;
        batteryStatusBar.setVitalsValue(currentBattery);
    }

    private void changePO2()
    {
        currentPO2 = 815;
        PO2StatusBar.setVitalsValue(currentPO2);
    }

    private void changePO2Rate()
    {
        currentPO2Rate = 1;
    }

    private void changePSOP()
    {
        currentPSOP = 942;
        PSOPStatusBar.setVitalsValue(currentPSOP);
    }
    private void changePSOPRate()
    {
        currentPSOPRate = 0;
    }

    private void changeBPM()
    {
        currentBPM = 60;
    }

    private void changeTSUB()
    {
        currentTSUB = 4;
    }
    private void changePSUB()
    {
        currentPSUB = 2;
        PSUBStatusBar.setVitalsValue(currentPSUB);
    }
    private void changePSUIT()
    {
        currentPSUIT = 4;
        PSUITStatusBar.setVitalsValue(currentPSUIT);
    }
    private void changePH2Og()
    {
        currentPH2Og = 15;
        PH2OgStatusBar.setVitalsValue(currentPH2Og);
    }
    private void changePH2OL()
    {
        currentPH2OL = 16;
        PH2OLStatusBar.setVitalsValue(currentPH2OL);
    }
    private void changeVFan()
    {
        currentVFan = 39034;
        VFanStatusBar.setVitalsValue(currentVFan);
    }
    private void updateVitalScreen()
    {
        PO2VitalDispNum.GetComponent<Text>().text = currentPO2.ToString() + " psia";
        batteryVitalDispNum.GetComponent<Text>().text = currentBattery.ToString() + " Ah";
        BPMDispNum.GetComponent<TextMeshProUGUI>().text = currentBPM.ToString() + " BPM";
        TSUBDispNum.GetComponent<TextMeshProUGUI>().text = currentTSUB.ToString() + " degF";
        PO2RateDispNum.GetComponent<TextMeshProUGUI>().text = currentPO2Rate.ToString() + " psi/min";
        PSOPDispNum.GetComponent<Text>().text = currentPSOP.ToString() + " psia";
        PSOPRateDispNum.GetComponent<TextMeshProUGUI>().text = currentPSOPRate.ToString() + " psi/min";
        PSUBDispNum.GetComponent<Text>().text = currentPSUB.ToString() + " psia";
        PSUITDispNum.GetComponent<Text>().text = currentPSUIT.ToString() + " psid";
        PH2OgDispNum.GetComponent<Text>().text = currentPH2Og.ToString() + " psia";
        PH2OLDispNum.GetComponent<Text>().text = currentPH2OL.ToString() + " psia";
        VFanDispNum.GetComponent<Text>().text = currentVFan.ToString() + " RPM";
    }

}
