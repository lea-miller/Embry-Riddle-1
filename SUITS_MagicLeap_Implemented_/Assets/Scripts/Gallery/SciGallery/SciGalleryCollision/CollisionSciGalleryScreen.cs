using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionSciGalleryScreen : GenericCollision
{
    private Image border;
    public GameObject topPanel { get; set; }
    public GameObject mainScreen { get; set; }

    void Awake()
    {
        border = GetComponent<Image>();
        topPanel = GameObject.FindWithTag("TopLCanvas");
        mainScreen = GameObject.FindWithTag("MainScreenTopPanel");
    }
     
     public override void isOn()
    {
    
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
        border.enabled = true;

    }

    public override void isOff()
    {
        topPanel.SetActive(false);
        mainScreen.SetActive(true);
        border.enabled = false;
    }
}
