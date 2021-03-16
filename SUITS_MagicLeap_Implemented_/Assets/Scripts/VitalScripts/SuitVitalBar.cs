using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SuitVitalBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image vitalStatusBar;

    public void setMaxVitalsValue(float vitalStatus)
    {
       slider.maxValue = vitalStatus;
       slider.value = vitalStatus;
       vitalStatusBar.color =  gradient.Evaluate(1f);
    }

    public void setVitalsValue(float vitalStatus)
    {
        slider.value = vitalStatus;
        vitalStatusBar.color = gradient.Evaluate(slider.normalizedValue);
    }

}
