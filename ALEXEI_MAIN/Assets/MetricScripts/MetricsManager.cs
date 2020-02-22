using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetricsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxOxygen , currentOxygen, maxBattery, currentBattery;
    
    public SuitMetricBar oxygenStatusBar, batteryStatusBar;
    
    void Start()
    {
        currentOxygen = currentBattery = maxOxygen;
        batteryStatusBar.setMaxMetricValue(maxBattery);
        oxygenStatusBar.setMaxMetricValue(maxOxygen);
    }

    // Update is called once per frame
    void Update()
    {
        currentOxygen = currentOxygen - 20;
        currentBattery = currentBattery - 10;
        
        batteryStatusBar.setMetricValue(currentBattery);
        oxygenStatusBar.setMetricValue(currentOxygen);
    }
}
