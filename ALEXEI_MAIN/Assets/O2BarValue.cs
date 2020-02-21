using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class O2BarValue : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private float o2BarValue;

    // Update is called once per frame
    void Update()
    {
        GameObject vitalsStreamObject = GameObject.Find("VitalsStreamObject");
        VitalsInput vitalsInput = vitalsStreamObject.GetComponent<VitalsInput>();

        textMesh = GetComponent<TextMeshProUGUI>();
        o2BarValue = vitalsInput.getOxygen();
        textMesh.text = o2BarValue.ToString() + "/950 psia";
    }
}
