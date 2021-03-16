using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskG1Collision : GenericCollision
{
    GameObject topPanel;
    GameObject mainScreen;
    Image border;

    protected void Awake()
    {
        topPanel = GameObject.FindWithTag("TopLCanvas");
        mainScreen = GameObject.FindWithTag("MainScreenTopPanel");
        border = GetComponent<Image>();
    }

    void Start()
    {
        isborderOff();
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

    private void isborderOff()
    {
        border.enabled = false;
    }

}
