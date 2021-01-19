using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTaskCollider : GenericCollision
{
    
    public GameObject topPanel { get; set; }
    public GameObject mainScreen { get; set; }

    protected void Start()
    {
        

        topPanel = GameObject.FindWithTag("TopLCanvas");
        mainScreen = GameObject.FindWithTag("MainScreenTopPanel");
    }

    public override void isOn()
    {
        
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }

    public override void isOff()
    {
      
        topPanel.SetActive(false);
        mainScreen.SetActive(true);
    }
}
