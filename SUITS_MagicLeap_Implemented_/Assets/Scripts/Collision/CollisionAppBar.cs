using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionAppBar : GenericCollision
{
    private Image appBorder;
    public GameObject topPanel { get; set; }
    public GameObject mainScreen { get; set; }

    void Awake()
    {
        appBorder = GameObject.FindWithTag("AppBar").GetComponent<Image>();
        topPanel = GameObject.FindWithTag("TopLCanvas");
        mainScreen = GameObject.FindWithTag("MainScreenTopPanel");
    }

    void Start()
    {
        isOff();
    }

    public override void isOn()
    {
        appBorder.enabled = true;
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }

    public override void isOff()
    {
        appBorder.enabled = false;
        topPanel.SetActive(false);
        mainScreen.SetActive(true);
    }
}
