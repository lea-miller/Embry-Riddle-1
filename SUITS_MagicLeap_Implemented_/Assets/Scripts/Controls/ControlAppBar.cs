using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlAppBar : ControlCommands
{
    private Image border;
    private List <GameObject> gameObjectList;
    private int counter = 0;
    
    void Awake()
    {
        base.Awake();
        Image appImage = GameObject.FindWithTag("AppBar").GetComponent<Image>();
        border = appImage;
        gameObjectList = new List<GameObject>();
        gameObjectList.Add(GameObject.FindWithTag("TaskScreen"));
        gameObjectList.Add(GameObject.FindWithTag("ScienceScreen"));
        gameObjectList.Add(GameObject.FindWithTag("NavigationScreen"));
    }

    public override void triggerDown()
    {   
       if(border.enabled)
       {
           if(counter <= gameObjectList.Count-1)
           {
                gameObjectList[counter].SetActive(false);
                counter = counter + 1;     
                gameObjectList[counter].SetActive(true);  
           } 
       }
    }

    public override void bumperDown()
    {
        if(border.enabled)
       {
            if(counter > 0)
           {
                gameObjectList[counter].SetActive(false);
                counter = counter - 1;   
                gameObjectList[counter].SetActive(true);   
           }
       }
    }
}
