using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlAppBar : ControlCommands
{
    private Image border;
    public LinkedList<GameObject> screenObjectList;
    public List<Lerp> iconObjectList;
    private LinkedList<string> nameList;
    private GameObject tempScreen;
    private TextMeshPro appNameText;
    private bool animationIsActive = false;
    private float lerpValue = 1f/3f;
    
    public delegate void HideIconsNotify();
    public static event HideIconsNotify HideIconsDelegate;
    public delegate void GoForwardNotify();
    public static event GoForwardNotify GoForwardDelegate;
    public delegate void GoBackwardNotify();
    public static event GoBackwardNotify GoBackwardDelegate;

    void Awake()
    {
        base.Awake();
        Image appImage = GameObject.FindWithTag("AppBar").GetComponent<Image>();
        border = appImage;
        appNameText = GameObject.FindWithTag("AppNameText").GetComponent<TextMeshPro>();
        
        //Orders the screens that would have to be activated or deactivated on the list
        screenObjectList = new LinkedList<GameObject>();
        screenObjectList.AddLast(GameObject.FindWithTag("TaskScreen"));
        screenObjectList.AddLast(GameObject.FindWithTag("NavigationScreen"));
        screenObjectList.AddLast(GameObject.FindWithTag("ScienceScreen"));
        screenObjectList.AddLast(GameObject.FindWithTag("MediaScreen"));

        //Orders the icons on the list
        iconObjectList = new List<Lerp>();
        iconObjectList.Add(GameObject.FindWithTag("TaskIcon").GetComponent<Lerp>());
        iconObjectList.Add(GameObject.FindWithTag("NavIcon").GetComponent<Lerp>());
        iconObjectList.Add(GameObject.FindWithTag("ScienceIcon").GetComponent<Lerp>());
        iconObjectList.Add(GameObject.FindWithTag("MediaIcon").GetComponent<Lerp>());      

        //Orders Names of Apps on list
        nameList = new LinkedList<string>();
        nameList.AddLast("Tasks");
        nameList.AddLast("Navigation");
        nameList.AddLast("Science");
        nameList.AddLast("Media");
    }

    void Start()
    {
        
        //Refresh the display by moving forward through all
        foreach (Lerp i in iconObjectList)
        {
            moveIconsForward();
        }
        handleScreenDisplay();
    }


    public override void triggerUp()
    {   
        if(!animationIsActive && border.enabled )
        {
            animationIsActive = true;
            moveIconsForward();
            moveScreensForward();
            animationIsActive = false;
            GoForwardDelegate();
        }
    }

    public void simulateTriggerUp()
    {
        
        animationIsActive = true;
        moveIconsForward();
        moveScreensForward();
        animationIsActive = false;
        GoForwardDelegate();
        HideIconsDelegate();
        
    }


    public override void bumperUp()
    {
        if(!animationIsActive && border.enabled)
        {
            animationIsActive = true;
            moveIconsBackward();
            moveScreensBackward();
            animationIsActive = false;
            GoBackwardDelegate();
            handleScreenDisplay();
        }
    }

    public void simulateBumperUp()
    {
        
        animationIsActive = true;
        moveIconsBackward();
        moveScreensBackward();
        animationIsActive = false;
        GoBackwardDelegate();
        
    }

    public override void triggerHold(){}
    public override void bumperHold(){}

    //Moves the order of the screens by having the first one go to the last one
    private void moveScreensForward()
    {
        var oldFirst = screenObjectList.First.Value;
        screenObjectList.RemoveFirst();
        screenObjectList.AddLast(oldFirst);

        var oldFirstName = nameList.First.Value;
        nameList.RemoveFirst();
        nameList.AddLast(oldFirstName);
        handleScreenDisplay();
    }

    private void moveScreensBackward()
    {
        var oldLast = screenObjectList.Last;
        screenObjectList.RemoveLast();
        screenObjectList.AddFirst(oldLast);

        var oldLastName = nameList.Last.Value;
        nameList.RemoveLast();
        nameList.AddFirst(oldLastName);
        handleScreenDisplay();
    }

    //Handles the enable and disable of each screen
    private void handleScreenDisplay()
    {
        var  screen = screenObjectList.First;
        var name = nameList.First.Value;
        appNameText.text = name;
        tempScreen = screen.Value;
        tempScreen.SetActive(true);
        

        for (int i = 0; i<screenObjectList.Count-1;i++)
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
