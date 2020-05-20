using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VitalsManager : MonoBehaviour
{
    [SerializeField] private float currentPO2, currentPO2Rate, currentBattery, currentBPM, currentTSUB, currentPSOP, currentPSOPRate, currentPSUB, currentPSUIT, currentPH2Og, currentPH2OL, currentVFan, batteryPercentage,
        oxPrimaryPercentage,oxSecondaryPercentage;
    private GameObject PO2VitalDispNum, PO2RateDispNum, batteryVitalDispNum, BPMDispNum, TSUBDispNum, PSOPDispNum, PSOPRateDispNum, PSUBDispNum, PSUITDispNum, PH2OgDispNum, PH2OLDispNum, VFanDispNum,
         TimeO2DispNum, TimeBatteryDispNum, TimeH2ODispNum;
    private GameObject textO2time, textBatterytime, textH2Otime, textBPM, textTSUB, textPO2, textPO2rate, textPSOP, textPSOPrate, textBattery, textPSUB, textPSUIT,
        textPH2Og, textPH2OL, textVFAN;
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
        //Gets TelemetryStream from the VitalsScreen
        getValues = gameObject.GetComponent<TelemetryStream>();

        //Finds the numbers as gameobjects to change to display Vital Values
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

        //Assigns text to gameobjects
        textO2time = GameObject.Find("/Torso/VitalsScreen/TimesCanvas/Time O2 Label");
        textBatterytime = GameObject.Find("/Torso/VitalsScreen/TimesCanvas/Time Battery Label");
        textH2Otime = GameObject.Find("/Torso/VitalsScreen/TimesCanvas/Time H2O Label");
        textBPM = GameObject.Find("/Torso/VitalsScreen/BPM");
        textTSUB = GameObject.Find("/Torso/VitalsScreen/TSUB");
        textPO2 = GameObject.Find("/Torso/VitalsScreen/PO2");
        textPO2rate = GameObject.Find("/Torso/VitalsScreen/PO2Rate");
        textPSOP = GameObject.Find("/Torso/VitalsScreen/PSOP");
        textPSOPrate = GameObject.Find("/Torso/VitalsScreen/PSOPRate");
        textBattery = GameObject.Find("/Torso/VitalsScreen/Battery");
        textPSUB = GameObject.Find("/Torso/VitalsScreen/PSUB");
        textPSUIT = GameObject.Find("/Torso/VitalsScreen/PSUIT");
        textPH2Og = GameObject.Find("/Torso/VitalsScreen/PH2Og");
        textPH2OL = GameObject.Find("/Torso/VitalsScreen/PH2OL");
        textVFAN = GameObject.Find("/Torso/VitalsScreen/VFan");
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
        changeTimes();
        updateVitalScreen();
        //homeScreen.updateMainScreen(currentPO2,currentCo2,currentPsi,currentHeartRate);
    }

    private void changeTimes()
    {
        //Gets time from json, splits into a string array, converts that array to integers, and converts HH:MM:SS to seconds
        string timeO2String = getValues.jsnData.t_oxygen;
        string[] O2Array = timeO2String.Split(':');
        int[] intO2Array = Array.ConvertAll<string, int>(O2Array, int.Parse);
        int O2SecondsValue = 3600 * intO2Array[0] + 60* intO2Array[1] + intO2Array[2];

        string timeBatteryString = getValues.jsnData.t_battery;
        string[] BatteryArray = timeBatteryString.Split(':');
        int[] intBatteryArray = Array.ConvertAll<string, int>(BatteryArray, int.Parse);
        int BatterySecondsValue = 3600 * intBatteryArray[0] + 60 * intBatteryArray[1] + intBatteryArray[2];

        string timeH2OString = getValues.jsnData.t_water;
        string[] H2OArray = timeH2OString.Split(':');
        int[] intH2OArray = Array.ConvertAll<string, int>(H2OArray, int.Parse);
        int H2OSecondsValue = 3600 * intH2OArray[0] + 60 * intH2OArray[1] + intH2OArray[2];

        // finds the lowest value from the seconds obtained from each
        int lowest = Mathf.Min(O2SecondsValue, BatterySecondsValue, H2OSecondsValue);
        if( lowest == O2SecondsValue) {
            Debug.Log("O2 is Lowest!");
            textO2time.GetComponent<TextMeshProUGUI>().color = Color.red;
            TimeO2DispNum.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        if (lowest == BatterySecondsValue)
        {
            Debug.Log("Battery is Lowest!");
            textBatterytime.GetComponent<TextMeshProUGUI>().color = Color.red;
            TimeBatteryDispNum.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        if (lowest == H2OSecondsValue)
        {
            Debug.Log("H2O is Lowest!");
            textH2Otime.GetComponent<TextMeshProUGUI>().color = Color.red;
            TimeH2ODispNum.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }

    private void changeBattery()
    {
        batteryPercentage = getValues.jsnData.batteryPercent;
        currentBattery = getValues.jsnData.cap_battery;
        batteryStatusBar.setVitalsValue(batteryPercentage);
        if (batteryPercentage <= 30)
        {
            textBattery.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            textBattery.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }

    private void changePO2()
    {
        oxPrimaryPercentage = float.Parse(getValues.jsnData.ox_primary);
        currentPO2 = float.Parse(getValues.jsnData.p_o2);
        PO2StatusBar.setVitalsValue(oxPrimaryPercentage);
        if (oxPrimaryPercentage <= 30)
        {
            textPO2.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            textPO2.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }

    private void changePO2Rate()
    {
        currentPO2Rate = float.Parse(getValues.jsnData.rate_o2);
        if (currentPO2Rate > 1)
        {
            textPO2rate.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            textPO2rate.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }

    private void changePSOP()
    {
        oxSecondaryPercentage = float.Parse(getValues.jsnData.ox_secondary);
        currentPSOP = float.Parse(getValues.jsnData.p_sop);
        PSOPStatusBar.setVitalsValue(oxSecondaryPercentage);
        if (oxSecondaryPercentage <= 30)
        {
            textPSOP.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            textPSOP.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
    private void changePSOPRate()
    {
        currentPSOPRate = float.Parse(getValues.jsnData.rate_sop);
        if (currentPSOPRate > 1)
        {
            textPSOPrate.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            textPSOPrate.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }

    private void changeBPM()
    {
        currentBPM = getValues.jsnData.heart_bpm;
        if (currentBPM > 100)
        {
            textBPM.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            textBPM.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }

    private void changeTSUB()
    {
        currentTSUB = float.Parse(getValues.jsnData.t_sub);
        if (currentTSUB > 100)
        {
            textTSUB.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            textTSUB.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
    private void changePSUB()
    {
        currentPSUB = float.Parse(getValues.jsnData.p_sub);
        PSUBStatusBar.setVitalsValue(currentPSUB);
        if (currentPSUB <= 2 || currentPSUB >= 4)
        {
            textPSUB.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            textPSUB.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
    private void changePSUIT()
    {
        currentPSUIT = float.Parse(getValues.jsnData.p_suit);
        PSUITStatusBar.setVitalsValue(currentPSUIT);
        if (currentPSUIT <= 2 || currentPSUIT >= 4)
        {
            textPSUIT.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            textPSUIT.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
    private void changePH2Og()
    {
        currentPH2Og = float.Parse(getValues.jsnData.p_h2o_g);
        PH2OgStatusBar.setVitalsValue(currentPH2Og);
        if (currentPH2Og <= 14 || currentPH2Og >= 16)
        {
            textPH2Og.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            textPH2Og.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
    private void changePH2OL()
    {
        currentPH2OL = float.Parse(getValues.jsnData.p_h2o_l);
        PH2OLStatusBar.setVitalsValue(currentPH2OL);
        if (currentPH2OL <= 14 || currentPH2OL >= 16)
        {
            textPH2OL.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            textPH2OL.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
    private void changeVFan()
    {
        currentVFan = float.Parse(getValues.jsnData.v_fan);
        VFanStatusBar.setVitalsValue(currentVFan);
        if (currentVFan <= 10000 || currentVFan >= 40000)
        {
            textVFAN.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            textVFAN.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
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
        TimeO2DispNum.GetComponent<TextMeshProUGUI>().text = getValues.jsnData.t_oxygen;
        TimeBatteryDispNum.GetComponent<TextMeshProUGUI>().text = getValues.jsnData.t_battery;
        TimeH2ODispNum.GetComponent<TextMeshProUGUI>().text = getValues.jsnData.t_water;
    }

}
