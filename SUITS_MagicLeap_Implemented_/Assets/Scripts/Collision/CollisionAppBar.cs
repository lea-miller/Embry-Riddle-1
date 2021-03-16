using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionAppBar : GenericCollision
{
    private Image appBorder;
    public GameObject topPanel { get; set; }
    public GameObject mainScreen { get; set; }
    LinkedList<GameObject> screenObjectList;
    
  

    void Awake()
    {
        appBorder = GameObject.FindWithTag("AppBar").GetComponent<Image>();
        topPanel = GameObject.FindWithTag("TopLCanvas");
        mainScreen = GameObject.FindWithTag("MainScreenTopPanel");
        
        screenObjectList = new LinkedList<GameObject>(); 
        screenObjectList.AddLast(GameObject.FindWithTag("TaskIcon"));
        screenObjectList.AddLast(GameObject.FindWithTag("NavIcon"));
        screenObjectList.AddLast(GameObject.FindWithTag("ScienceIcon"));
        screenObjectList.AddLast(GameObject.FindWithTag("MediaIcon"));

        ControlAppBar.GoForwardDelegate += moveScreensForward;
        ControlAppBar.GoForwardDelegate += showIconObjects;
        ControlAppBar.HideIconsDelegate += hideIconObjects;
        ControlAppBar.GoBackwardDelegate += moveScreensBackward;
        //ControlAppBar.ShowIconsDelegate += showIconObjects;

    }
   
    void Start()
    {
        isOff();
    }

    public override void isOn()
    {
        appBorder.enabled = true;
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
        showIconObjects();
    }

    public override void isOff()
    {
        appBorder.enabled = false;
        topPanel.SetActive(false);
        mainScreen.SetActive(true);
        hideIconObjects(); //TODO
    }

    //These methods are handled by delegate event in the ControlAppBar
    private void moveScreensForward()
    {
        var oldFirst = screenObjectList.First.Value;
        screenObjectList.RemoveFirst();
        screenObjectList.AddLast(oldFirst);
    }

    private void moveScreensBackward()
    {
        var oldLast = screenObjectList.Last;
        screenObjectList.RemoveLast();
        screenObjectList.AddFirst(oldLast);
    }


     private void hideIconObjects()
    {
        var  screen = screenObjectList.First;
        var tempScreen = screen.Value;
        tempScreen.SetActive(true);
        
        for(int j = 0; j<screenObjectList.Count-1;j++)
        {
                    screen = screen.Next;
                    tempScreen = screen.Value;
                    tempScreen.SetActive(false); 
        } 
    }

    private void showIconObjects()
    {
        var  screen = screenObjectList.First;
        var tempScreen = screen.Value;
        tempScreen.SetActive(true); 

        for(int j = 0; j<screenObjectList.Count-1;j++)
        {
                    screen = screen.Next;
                    tempScreen = screen.Value;
                    tempScreen.SetActive(true);           
        } 
    }
}
