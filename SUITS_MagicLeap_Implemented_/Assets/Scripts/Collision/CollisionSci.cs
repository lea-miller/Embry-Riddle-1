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
        isOff();
    }

     void Start()
    {
        Debug.Log("Start: ", topPanel);
        
    }

    public override void isOn()
    {
        border.enabled = true;
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }

    public override void isOff()
    {
        Debug.Log(topPanel);
        border.enabled = false; 
        mainScreen.SetActive(true);

        
    }
}
