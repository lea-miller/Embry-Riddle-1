using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VitalsManager : MonoBehaviour
{
    [SerializeField] private float currentPO2, currentPO2Rate, currentBattery, currentBPM, currentTSUB, currentPSOP, currentPSOPRate, currentPSUB, currentPSUIT, currentPH2Og, currentPH2OL, currentVFan, batteryPercentage,
        oxPrimaryPercentage, oxSecondaryPercentage, currentEMU1O2Value, currentEMU2O2Value;
    private GameObject PO2VitalDispNum, PO2RateDispNum, batteryVitalDispNum, BPMDispNum, TSUBDispNum, PSOPDispNum, PSOPRateDispNum, PSUBDispNum, PSUITDispNum, PH2OgDispNum, PH2OLDispNum, VFanDispNum,
         TimeO2DispNum, TimeBatteryDispNum, TimeH2ODispNum;
    private GameObject textO2time, textBatterytime, textH2Otime, textBPM, textTSUB, textPO2, textPO2rate, textPSOP, textPSOPrate, textBattery, textPSUB, textPSUIT,
        textPH2Og, textPH2OL, textVFAN;
    private GameObject textEMU1, textEMU2, textPUMP, textEV1SUPPLY, textEV1OXYGEN, textEV1WASTE, textEV2SUPPLY, textEV2OXYGEN, textEV2WASTE, textO2VENT, textEMU1O2PRESSUREVALUE, textEMU2O2PRESSUREVALUE;
    [SerializeField] private List<string> vitalsList = new List<string>();
    public string vitalsListString;
    [SerializeField] private SuitVitalBar batteryStatusBar, PO2StatusBar, PSOPStatusBar, PSUBStatusBar, PSUITStatusBar, VFanStatusBar;
    [SerializeField] private TelemetryStream getValues;
    [SerializeField] private MainScreenVitalManager homeScreen;
    [SerializeField] private int lowestCase;

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
        PH2OgDispNum = GameObject.Find("/Torso/VitalsScreen/PH2OgValue");
        PH2OLDispNum = GameObject.Find("/Torso/VitalsScreen/PH2OLValue");
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

        //Assigns text to UIA switch gameobjects
        textEMU1 = GameObject.Find("/Torso/VitalsScreen/EMU1");
        textEMU2 = GameObject.Find("/Torso/VitalsScreen/EMU2");
        textPUMP = GameObject.Find("/Torso/VitalsScreen/PUMP");
        textO2VENT = GameObject.Find("/Torso/VitalsScreen/O2VENT");
        textEV1SUPPLY = GameObject.Find("/Torso/VitalsScreen/EV1 SUPPLY");
        textEV1OXYGEN = GameObject.Find("/Torso/VitalsScreen/EV1 OXYGEN");
        textEV1WASTE = GameObject.Find("/Torso/VitalsScreen/EV1 WASTE");
        textEV2SUPPLY = GameObject.Find("/Torso/VitalsScreen/EV2 SUPPLY");
        textEV2OXYGEN = GameObject.Find("/Torso/VitalsScreen/EV2 OXYGEN");
        textEV2WASTE = GameObject.Find("/Torso/VitalsScreen/EV2 WASTE");

        textEMU1O2PRESSUREVALUE = GameObject.Find("/Torso/VitalsScreen/EMU1 O2 PRESSURE VALUE");
        textEMU2O2PRESSUREVALUE = GameObject.Find("/Torso/VitalsScreen/EMU2 O2 PRESSURE VALUE");

    }

    // Update is called once per frame
    void Update()
    {
        //start getting values, and update the telemetry values every frame
        StartCoroutine(gameObject.GetComponent<TelemetryStream>().GetText());
        //clear the vitals notification list every frame so errors do not persist after they are fixed
        vitalsList = new List<string>();
        //update vitals values
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
        writeListToString();
        //change UIA values every frame as well
        changeUIA();
        //writes new values to vitals screen
        updateVitalScreen();
        //writes new values to main screen
        homeScreen.updateMainScreen(currentBPM, getValues.jsnData.timer, lowestCase, getValues.jsnData.t_oxygen, getValues.jsnData.t_battery, getValues.jsnData.t_water, vitalsListString);
    }

    private void changeTimes()
    {
        //Gets time from json, splits into a string array, converts that array to integers, and converts HH:MM:SS to seconds
        string timeO2String = getValues.jsnData.t_oxygen;
        string[] O2Array = timeO2String.Split(':');
        int[] intO2Array = Array.ConvertAll<string, int>(O2Array, int.Parse);
        int O2SecondsValue = 3600 * intO2Array[0] + 60 * intO2Array[1] + intO2Array[2];

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
        if (lowest == O2SecondsValue) {
            textO2time.GetComponent<TextMeshProUGUI>().color = Color.red;
            TimeO2DispNum.GetComponent<TextMeshProUGUI>().color = Color.red;
            lowestCase = 1;
        }
        else
        {
            textO2time.GetComponent<TextMeshProUGUI>().color = Color.white;
            TimeO2DispNum.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        if (lowest == BatterySecondsValue)
        {
            textBatterytime.GetComponent<TextMeshProUGUI>().color = Color.red;
            TimeBatteryDispNum.GetComponent<TextMeshProUGUI>().color = Color.red;
            lowestCase = 2;
        }
        else
        {
            textBatterytime.GetComponent<TextMeshProUGUI>().color = Color.white;
            TimeBatteryDispNum.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        if (lowest == H2OSecondsValue)
        {
            textH2Otime.GetComponent<TextMeshProUGUI>().color = Color.red;
            TimeH2ODispNum.GetComponent<TextMeshProUGUI>().color = Color.red;
            lowestCase = 3;
        }
        else
        {
            textH2Otime.GetComponent<TextMeshProUGUI>().color = Color.white;
            TimeH2ODispNum.GetComponent<TextMeshProUGUI>().color = Color.white;
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
            vitalsList.Add("BATTERY");
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
            vitalsList.Add("PO2");
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
            vitalsList.Add("PO2 RATE");
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
            vitalsList.Add("PSOP");
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
            vitalsList.Add("PSOP RATE");
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
            vitalsList.Add("BPM");
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
            vitalsList.Add("TSUB");
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
        if (currentPSUB < 2 || currentPSUB > 4)
        {
            textPSUB.GetComponent<TextMeshProUGUI>().color = Color.red;
            vitalsList.Add("PSUB");
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
        if (currentPSUIT < 2 || currentPSUIT > 4)
        {
            textPSUIT.GetComponent<TextMeshProUGUI>().color = Color.red;
            vitalsList.Add("PSUIT");
        }
        else
        {
            textPSUIT.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
    private void changePH2Og()
    {
        currentPH2Og = float.Parse(getValues.jsnData.p_h2o_g);
        if (currentPH2Og < 14 || currentPH2Og > 16)
        {
            textPH2Og.GetComponent<TextMeshProUGUI>().color = Color.red;
            vitalsList.Add("PH2Og");
        }
        else
        {
            textPH2Og.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
    private void changePH2OL()
    {
        currentPH2OL = float.Parse(getValues.jsnData.p_h2o_l);
        if (currentPH2OL < 14 || currentPH2OL > 16)
        {
            textPH2OL.GetComponent<TextMeshProUGUI>().color = Color.red;
            vitalsList.Add("PH2OL");
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
        if (currentVFan < 10000 || currentVFan > 40000)
        {
            textVFAN.GetComponent<TextMeshProUGUI>().color = Color.red;
            vitalsList.Add("VFAN");
        }
        else
        {
            textVFAN.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }

    private void writeListToString()
    {
        vitalsListString = string.Join("\n", vitalsList);
    }

    private void changeUIA()
    {
        //EMU1
        if (String.Equals(getValues.jsnUIAData.emu1, "OFF") == true)
        {
            textEMU1.GetComponent<TextMeshProUGUI>().color = Color.gray;
        }
        else
        {
            textEMU1.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        //EMU2
        if (String.Equals(getValues.jsnUIAData.emu2, "OFF") == true)
        {
            textEMU2.GetComponent<TextMeshProUGUI>().color = Color.gray;
        }
        else
        {
            textEMU2.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        //PUMP
        if (String.Equals(getValues.jsnUIAData.depress_pump, "FAULT") == true)
        {
            textPUMP.GetComponent<TextMeshProUGUI>().color = Color.gray;
        }
        else
        {
            textPUMP.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        //O2VENT
        if (String.Equals(getValues.jsnUIAData.O2_vent, "FAULT") == true)
        {
            textO2VENT.GetComponent<TextMeshProUGUI>().color = Color.gray;
        }
        else
        {
            textO2VENT.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        //EV1SUPPLY
        if (String.Equals(getValues.jsnUIAData.ev1_supply, "CLOSE") == true)
        {
            textEV1SUPPLY.GetComponent<TextMeshProUGUI>().color = Color.gray;
        }
        else
        {
            textEV1SUPPLY.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        //EV1OXYGEN
        if (String.Equals(getValues.jsnUIAData.emu1_O2, "CLOSE") == true)
        {
            textEV1OXYGEN.GetComponent<TextMeshProUGUI>().color = Color.gray;
        }
        else
        {
            textEV1OXYGEN.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        //EV1WASTE
        if (String.Equals(getValues.jsnUIAData.ev1_waste, "CLOSE") == true)
        {
            textEV1WASTE.GetComponent<TextMeshProUGUI>().color = Color.gray;
        }
        else
        {
            textEV1WASTE.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        //EV2SUPPLY
        if (String.Equals(getValues.jsnUIAData.ev2_supply, "CLOSE") == true)
        {
            textEV2SUPPLY.GetComponent<TextMeshProUGUI>().color = Color.gray;
        }
        else
        {
            textEV2SUPPLY.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        //EV2OXYGEN
        if (String.Equals(getValues.jsnUIAData.emu2_O2, "CLOSE") == true)
        {
            textEV2OXYGEN.GetComponent<TextMeshProUGUI>().color = Color.gray;
        }
        else
        {
            textEV2OXYGEN.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        //EV2WASTE
        if (String.Equals(getValues.jsnUIAData.ev2_waste, "CLOSE") == true)
        {
            textEV2WASTE.GetComponent<TextMeshProUGUI>().color = Color.gray;
        }
        else
        {
            textEV2WASTE.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        //set EMU pressure values every frame
        currentEMU1O2Value = getValues.jsnUIAData.o2_supply_pressure1;
        currentEMU2O2Value = getValues.jsnUIAData.o2_supply_pressure2;
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
        PH2OgDispNum.GetComponent<TextMeshProUGUI>().text = currentPH2Og.ToString() + " psia";
        PH2OLDispNum.GetComponent<TextMeshProUGUI>().text = currentPH2OL.ToString() + " psia";
        VFanDispNum.GetComponent<Text>().text = currentVFan.ToString() + " RPM";
        textEMU1O2PRESSUREVALUE.GetComponent<TextMeshProUGUI>().text = currentEMU1O2Value.ToString() + " psi";
        textEMU2O2PRESSUREVALUE.GetComponent<TextMeshProUGUI>().text = currentEMU2O2Value.ToString() + " psi";
        TimeO2DispNum.GetComponent<TextMeshProUGUI>().text = getValues.jsnData.t_oxygen;
        TimeBatteryDispNum.GetComponent<TextMeshProUGUI>().text = getValues.jsnData.t_battery;
        TimeH2ODispNum.GetComponent<TextMeshProUGUI>().text = getValues.jsnData.t_water;
    }

}
