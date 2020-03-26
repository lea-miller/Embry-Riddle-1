using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalsManager : MonoBehaviour
{

    public int maxOxygen, maxBattery = 5000000;
    public int currentBattery, currentOxygen;
    public SuitVitalBar oxygenStatusBar, batteryStatusBar;

    void start()
    {
        currentOxygen = maxOxygen;
        currentBattery = maxBattery;
        oxygenStatusBar.setMaxVitalsValue(maxOxygen);
        batteryStatusBar.setMaxVitalsValue(maxBattery);
    }

    // Update is called once per frame
    void Update()
    {
        changeBattery();
        changeOxygen();
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

}
