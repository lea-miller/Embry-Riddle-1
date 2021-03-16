using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionButton : GenericCollision
{
    public Image border { get; set; }
    public GameObject topPanel { get; set; }
    public GameObject mainScreen { get; set; }

    protected void Awake()
    {
        border = GetComponent<Image>();
        border.enabled = false;
        topPanel = GameObject.FindWithTag("TopLCanvas");
        mainScreen = GameObject.FindWithTag("MainScreenTopPanel");
    }

    public override void isOn()
    {
        border.enabled = true;
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }

    public override void isOff()
    {
        border.enabled = false;
        topPanel.SetActive(false);
        mainScreen.SetActive(true);
    }
}
