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

    public override void nextSelection()
    {   
       if(border.enabled)
       {
           if(counter <= gameObjectList.Count-1)
           {
               // disableControls();
                gameObjectList[counter].SetActive(false);
                counter = counter + 1;     
                gameObjectList[counter].SetActive(true);  
               // enableControls();
           } 
       }
    }

    public override void prevSelection()
    {
        if(border.enabled)
       {
            if(counter > 0)
           {
                //disableControls();
                gameObjectList[counter].SetActive(false);
                counter = counter - 1;   
                gameObjectList[counter].SetActive(true);   
               // enableControls();
           }
       }
    }

    //Must re-enable what was shut off
    private void enableControls()
    {
        for (int i = 0; i <  gameObjectList[counter].transform.childCount; i++)
        {
            GameObject child = gameObjectList[counter].transform.GetChild(i).gameObject;
            if(child.TryGetComponent<MagicLeapTools.ControlInput>(out var control))
            {
                control.enabled = true;
            }
        }
    }

    //Must shut off controls script from the other components or else an error will happen, regardless if the component is disabled
    private void disableControls()
    {
        for (int i = 0; i <  gameObjectList[counter].transform.childCount; i++)
        {
            GameObject child = gameObjectList[counter].transform.GetChild(i).gameObject;
            if(child.TryGetComponent<MagicLeapTools.ControlInput>(out var control))
            {
                control.enabled = false;
            }
        }
    }

}
