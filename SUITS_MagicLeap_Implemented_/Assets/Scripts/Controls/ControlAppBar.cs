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
        //Add the gamebojects to the list
    }

    public override void nextSelection()
    {   
       if(border.enabled)
       {
           if(counter < gameObjectList.Count)
           {
                gameObjectList[counter].SetActive(false);
                counter++;    
                gameObjectList[counter].SetActive(true);  
           } 
       }
    }

    public override void prevSelection()
    {
         if(border.enabled)
       {
            if(counter > 0)
           {
                gameObjectList[counter].SetActive(false);
                counter--;   
                gameObjectList[counter].SetActive(true);   
           }
       }
    }
}
