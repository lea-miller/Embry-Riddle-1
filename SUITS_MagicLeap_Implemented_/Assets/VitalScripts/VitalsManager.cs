using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VitalsManager : MonoBehaviour
{
    [SerializeField] private float currentPO2, currentPO2Rate, currentBattery, currentBPM, currentTSUB, currentPSOP, currentPSOPRate, currentPSUB, currentPSUIT, currentPH2Og, currentPH2OL, currentVFan, batteryPercentage,
        oxPrimaryPercentage,oxSecondaryPercentage;
    private GameObject PO2VitalDispNum, PO2RateDispNum, batteryVitalDispNum, BPMDispNum, TSUBDispNum, PSOPDispNum, PSOPRateDispNum, PSUBDispNum, PSUITDispNum, PH2OgDispNum, PH2OLDispNum, VFanDispNum,
         TimeO2DispNum, TimeBatteryDispNum, TimeH2ODispNum;
    [SerializeField] private SuitVitalBar batteryStatusBar, PO2StatusBar, PSOPStatusBar, PSUBStatusBar, PSUITStatusBar, PH2OgStatusBar, PH2OLStatusBar, VFanStatusBar;
    [SerializeField] private TelemetryStream getValues;
    [SerializeField] private MainScreenVitalManager homeScreen;

    void Awake()
    {
        assignVariables();
    }

    //Assigns the variables once so performance can be quicker than assigining it every update
    private void assignVariables()
    {
        getValues = gameObject.GetComponent<TelemetryStream>();
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
        TimeO2DispNum = GameObject.Find("/Torso/VitalsScreen/TimesCanvas/Time O2");
        TimeBatteryDispNum = GameObject.Find("/Torso/VitalsScreen/TimesCanvas/Time Battery");
        TimeH2ODispNum = GameObject.Find("/Torso/VitalsScreen/TimesCanvas/Time H2O");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(gameObject.GetComponent<TelemetryStream>().GetText());
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
        batteryPercentage = getValues.jsnData.batteryPercent;
        currentBattery = getValues.jsnData.cap_battery;
        batteryStatusBar.setVitalsValue(batteryPercentage);
    }

    private void changePO2()
    {
        oxPrimaryPercentage = float.Parse(getValues.jsnData.ox_primary);
        currentPO2 = float.Parse(getValues.jsnData.p_o2);
        PO2StatusBar.setVitalsValue(oxPrimaryPercentage);
    }

    private void changePO2Rate()
    {
        currentPO2Rate = float.Parse(getValues.jsnData.rate_o2);
    }

    private void changePSOP()
    {
        oxSecondaryPercentage = float.Parse(getValues.jsnData.ox_secondary);
        currentPSOP = float.Parse(getValues.jsnData.p_sop);
        PSOPStatusBar.setVitalsValue(oxSecondaryPercentage);
    }
    private void changePSOPRate()
    {
        currentPSOPRate = float.Parse(getValues.jsnData.rate_sop);
    }

    private void changeBPM()
    {
        currentBPM = getValues.jsnData.heart_bpm;
    }

    private void changeTSUB()
    {
        currentTSUB = float.Parse(getValues.jsnData.t_sub);
    }
    private void changePSUB()
    {
        currentPSUB = float.Parse(getValues.jsnData.p_sub);
        PSUBStatusBar.setVitalsValue(currentPSUB);
    }
    private void changePSUIT()
    {
        currentPSUIT = float.Parse(getValues.jsnData.p_suit);
        PSUITStatusBar.setVitalsValue(currentPSUIT);
    }
    private void changePH2Og()
    {
        currentPH2Og = float.Parse(getValues.jsnData.p_h2o_g);
        PH2OgStatusBar.setVitalsValue(currentPH2Og);
    }
    private void changePH2OL()
    {
        currentPH2OL = float.Parse(getValues.jsnData.p_h2o_l);
        PH2OLStatusBar.setVitalsValue(currentPH2OL);
    }
    private void changeVFan()
    {
        currentVFan = float.Parse(getValues.jsnData.v_fan);
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
        TimeO2DispNum.GetComponent<TextMeshProUGUI>().text = getValues.jsnData.t_oxygen;
        TimeBatteryDispNum.GetComponent<TextMeshProUGUI>().text = getValues.jsnData.t_battery;
        TimeH2ODispNum.GetComponent<TextMeshProUGUI>().text = getValues.jsnData.t_water;
    }

}
