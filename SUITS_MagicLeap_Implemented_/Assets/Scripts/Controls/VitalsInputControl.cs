using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalsInputControl: MonoBehaviour
{   
    private Image vitalImage, vitalMainScreen;
    [SerializeField]
    private GameObject mainScreen, topView;
    
    void Awake()
    {
        vitalImage = GameObject.FindWithTag("VitalsUI").GetComponent<Image>();
        vitalMainScreen = GameObject.FindWithTag("VitalTopView").GetComponent<Image>();
    }

    private void isOnVitalCheck()
    {
        mainScreen.SetActive(false);
        topView.SetActive(true);
        vitalMainScreen.enabled = false;
        vitalImage.enabled = true;
    }

    //This method also initalizes the boolens b/c on startup the user never starts on taskscreen
    private void isOnScreenCheck()
    {
        mainScreen.SetActive(true);
        topView.SetActive(false);
        vitalMainScreen.enabled = false;
        vitalImage.enabled = false;
    }

    private void isOnViewTopPanelCheck()
    {
        mainScreen.SetActive(false);
        topView.SetActive(true);
        vitalMainScreen.enabled = true;
        vitalImage.enabled = false;
    }
}
