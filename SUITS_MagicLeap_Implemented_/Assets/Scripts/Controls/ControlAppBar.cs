using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlAppBar : ControlCommands
{
    private Image border;
    LinkedList<GameObject> screenObjectList;
    List<Lerp> iconObjectList;
    private GameObject tempScreen; 
    private bool animationIsActive = false;
    private float lerpValue = 1f/3f;

    void Awake()
    {
        base.Awake();
        Image appImage = GameObject.FindWithTag("AppBar").GetComponent<Image>();
        border = appImage;
        
        //Orders the screens that would have to be activated or deactivated on the list
        screenObjectList = new LinkedList<GameObject>();
        screenObjectList.AddLast(GameObject.FindWithTag("TaskScreen"));
        screenObjectList.AddLast(GameObject.FindWithTag("ScienceScreen"));
        screenObjectList.AddLast(GameObject.FindWithTag("Navigation Screen"));
        screenObjectList.AddLast(GameObject.FindWithTag("MediaScreen"));
        handleScreenDisplay();

        //Orders the icons on the list
        iconObjectList = new List<Lerp>();
        iconObjectList.Add(GameObject.FindWithTag("TaskIcon").GetComponent<Lerp>());
        iconObjectList.Add(GameObject.FindWithTag("ScienceIcon").GetComponent<Lerp>());
        iconObjectList.Add(GameObject.FindWithTag("NavIcon").GetComponent<Lerp>());
        iconObjectList.Add(GameObject.FindWithTag("MediaIcon").GetComponent<Lerp>());      
    }

    public override void triggerUp()
    {   
        if(!animationIsActive && border.enabled)
        {
            animationIsActive = true;
            moveIconsForward();
            moveScreensForward();
            animationIsActive = false;
        }
    }
    
     public override void bumperUp()
    {
        if(!animationIsActive && border.enabled)
        {
            animationIsActive = true;
            moveIconsBackward();
            moveScreensBackward();
            animationIsActive = false;
        }
    }

    public override void triggerHold(){}
    public override void bumperHold(){}

    //Moves the order of the screens by having the first one go to the last one
    private void moveScreensForward()
    {
        var oldFirst = screenObjectList.First.Value;
        screenObjectList.RemoveFirst();
        screenObjectList.AddLast(oldFirst);
        handleScreenDisplay();
    }

    private void moveScreensBackward()
    {
        var oldLast = screenObjectList.Last;
        screenObjectList.RemoveLast();
        screenObjectList.AddFirst(oldLast);
        handleScreenDisplay();
    }

    //Handles the enable and disable of each screen
    private void handleScreenDisplay()
    {
        var  screen = screenObjectList.First;
        tempScreen = screen.Value;
        tempScreen.SetActive(true);
        
        for(int i = 0; i<screenObjectList.Count-1;i++)
        {
            screen = screen.Next;  
            tempScreen = screen.Value;
            tempScreen.SetActive(false); 
        };  
    }

    private void moveIconsBackward()
    {
        
        for(int i = 0; i<iconObjectList.Count;i++)
        {
            if(iconObjectList[i].getLerpPos()== 3)
            {
                iconObjectList[i].instantLerp(false);
            }
            else
            {
                iconObjectList[i].setLerp(false); 
            }
        }
    }

    //Moves the orders of the icons by having the first one go to the last one
    private void moveIconsForward()
    {
        for(int i = 0; i<iconObjectList.Count;i++)
        {
            if(iconObjectList[i].getLerpPos()==0)
            {
                iconObjectList[i].instantLerp(true);
            }
            else
            {
                iconObjectList[i].setLerp(true); 
            }
           
        }
    }

}
