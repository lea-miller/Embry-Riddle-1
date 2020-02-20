using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2Bar : MonoBehaviour
{
    private const float MAX_O2 = 950f;
    private Image o2Bar;

    void Start()
    {
        o2Bar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject vitalsStreamObject = GameObject.Find("VitalsStreamObject");
        VitalsInput vitalsInput = vitalsStreamObject.GetComponent<VitalsInput>();
        o2Bar.fillAmount = vitalsInput.O2 / MAX_O2;

        if (vitalsInput.O2 >= 0 && vitalsInput.O2 < 350)
        {
            o2Bar.color = Color.red;
        }
        else if (vitalsInput.O2 >= 350 && vitalsInput.O2 < 650)
        {
            o2Bar.color = Color.yellow;
        }
        else if (vitalsInput.O2 >= 650 && vitalsInput.O2 < 950)
        {
            o2Bar.color = Color.green;
        }
        
    }
}
