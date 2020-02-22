using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SuitMetricBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image metricStatusBar;

    public void setMaxMetricValue(int metricStatus)
    {
       slider.maxValue = metricStatus;
       slider.value = metricStatus;
       metricStatusBar.color =  gradient.Evaluate(1f);
    }

    public void setMetricValue(int metricStatus)
    {
        slider.value = metricStatus;
        metricStatusBar.color = gradient.Evaluate(slider.normalizedValue);
    }

}
