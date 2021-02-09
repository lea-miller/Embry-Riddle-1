using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderProperties : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image statusBar;

    public void setMaxSliderValue(float status)
    {
       slider.maxValue = status;
       slider.value = status;
       statusBar.color =  gradient.Evaluate(1f);
    }

    public void setSliderValue(float status)
    {
        slider.value = status;
        statusBar.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void beginLoad()
    {
        StartCoroutine("loadingForComplete");
    }

    IEnumerator loadingForComplete()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f) 
        {
            //Deduct the status
            yield return new WaitForSeconds(.1f);
        }
    }
}

