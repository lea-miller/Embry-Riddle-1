using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionVitalManager : MonoBehaviour
{
    public Image vitalImage { set; get; }
    public Image vitalMainScreen { set; get; }
    public GameObject mainScreen { set; get; }
    public GameObject topView { set; get; }

    void Awake()
    {
        vitalImage = GameObject.FindWithTag("VitalsUI").GetComponent<Image>();
        vitalMainScreen = GameObject.FindWithTag("VitalTopView").GetComponent<Image>();
        mainScreen = GameObject.FindWithTag("MainScreenTopPanel");
        topView = GameObject.FindWithTag("VitalTopView");
    }

    void Start()
    {
        isOn();
    }

    private void isOn()
    {
        mainScreen.SetActive(true);
        topView.SetActive(false);
        vitalMainScreen.enabled = false;
        vitalImage.enabled = false;
    }

}
