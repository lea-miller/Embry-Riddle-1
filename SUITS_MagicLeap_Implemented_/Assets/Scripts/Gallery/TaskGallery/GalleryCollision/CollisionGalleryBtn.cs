using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionGalleryBtn : GenericCollision
{
    public GameObject topPanel { get; set; }
    public GameObject mainScreen { get; set; }
    public Image border;

    void Awake()
    {
        border = this.GetComponent<Image>();
        topPanel = GameObject.FindWithTag("TopLCanvas");
        mainScreen = GameObject.FindWithTag("MainScreenTopPanel");
    }
    protected void Start()
    {
        isOff();
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
