using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionSci : GenericCollision
{
    private Image border;
    public  GameObject mainScreen { get; set; }
    public  GameObject topPanel { get; set; }
    // Start is called before the first frame update
    void Awake()
    {
        border = GameObject.FindWithTag("ScienceScreen").GetComponent<Image>();
        mainScreen = GameObject.FindWithTag("MainScreenTopPanel");
        topPanel = GameObject.FindWithTag("TopLCanvas");
    }

     void Start()
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
