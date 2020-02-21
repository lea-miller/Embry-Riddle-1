using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2Bar : MonoBehaviour
{
    private const float MAX_O2 = 950f;
    private Image o2Bar;
    GameObject vitalsStreamObject;
    VitalsInput vitalsInput;

    void Start()
    {
        o2Bar = GetComponent<Image>();
        vitalsStreamObject = GameObject.Find("VitalsStreamObject");
    }

    // Update is called once per frame
    void Update()
    {
        vitalsInput = vitalsStreamObject.GetComponent<VitalsInput>();
        o2Bar.fillAmount = vitalsInput.getOxygen() / MAX_O2;

        if (vitalsInput.getOxygen() >= 0 && vitalsInput.getOxygen() < 350)
        {
            o2Bar.color = Color.red;
        }
        else if (vitalsInput.getOxygen() >= 350 && vitalsInput.getOxygen() < 650)
        {
            o2Bar.color = Color.yellow;
        }
        else if (vitalsInput.getOxygen() >= 650 && vitalsInput.getOxygen() < 950)
        {
            o2Bar.color = Color.green;
        }
        
    }
}
