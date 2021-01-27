using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlAppBar : ControlCommands
{
    private Image border;
    LinkedList<GameObject> gameObjectList;
    List<System.Action> iconTriggerDict;
    List<System.Action> iconBumperDict;
    private int triggerCount = 0;
    private GameObject tempIconAnimation; //sadly this is globalized in the code, not sure how to pass parameters in system actions
    public bool isTrigger = false;

    
    void Awake()
    {
        base.Awake();
        Image appImage = GameObject.FindWithTag("AppBar").GetComponent<Image>();
        border = appImage;
        gameObjectList = new LinkedList<GameObject>();
        gameObjectList.AddLast(GameObject.FindWithTag("TaskScreen"));
        gameObjectList.AddLast(GameObject.FindWithTag("ScienceScreen"));
        gameObjectList.AddLast(GameObject.FindWithTag("NavigationScreen"));
        gameObjectList.AddLast(GameObject.FindWithTag("MediaScreen"));
        
        var innerNode =  gameObjectList.First;
        for(int i = 0; i<gameObjectList.Count-1;i++)
        {
            innerNode.Value.SetActive(false);
            innerNode = innerNode.Next;
        }
        
        gameObjectList.First.Value.SetActive(true);

        iconTriggerDict = new List<System.Action>();
        iconTriggerDict.Add(MoveFirstToLast);
        iconTriggerDict.Add(MoveSecondToFirst);
        iconTriggerDict.Add(MoveThirdToSecond);
        iconTriggerDict.Add(MoveFourthToThird);
        
        iconBumperDict = new List<System.Action>();
        iconBumperDict.Add(MoveFirstToSecond);
        iconBumperDict.Add(MoveSecondToThird);
        iconBumperDict.Add(MoveThirdToFourth);
        iconBumperDict.Add(MoveLastToFirst);
    }

    public override void triggerDown()
    {   
        moveIconAnimationForward();
        moveIconsForward();
    }

    private void moveIconsForward()
    {
      //Moves the order of the lists by having the first one go to the last one
        var oldFirst = gameObjectList.First.Value;
        gameObjectList.RemoveFirst();
        gameObjectList.AddLast(oldFirst);
    }

    private void moveIconAnimationForward()
    {
        var  icon = gameObjectList.First;
        iconTriggerDict.ForEach(delegate(System.Action currAnimation)
        {
            tempIconAnimation = icon.Value;
            currAnimation.Invoke();
            icon = icon.Next;  
        });   
    }

    //For testing purposes
    private void display()
    { 
        var innerNode =  gameObjectList.First;
        for(int i = 0; i<gameObjectList.Count;i++)
        {
            Debug.Log(innerNode.Value);
            innerNode = innerNode.Next;
        }
    }

    public override void bumperDown()
    {
        isTrigger = false;
    }
    
    public void MoveFirstToLast()
    {
        Debug.Log("MoveFirstToLast: " + tempIconAnimation);                                                                                                                     
    }
    
    public void MoveSecondToFirst()
    {
        Debug.Log("Move2ndTo1st" + tempIconAnimation);                                                                                        
    }
    
    public void MoveThirdToSecond()
    {
        Debug.Log("Move3rdTo2nd" + tempIconAnimation);                                                                                                                               
    }

    public void MoveFourthToThird()
    {
        Debug.Log("Move4thTo3rd" + tempIconAnimation);                                                                                                                    
    }
    
    public void MoveFirstToSecond()
    {
                                                                                                                                    
    }
    
    public void MoveSecondToThird()
    {
                                                                                                                                    
    }

    public void MoveThirdToFourth()
    {
                                                                                                                                    
    }

    public void MoveLastToFirst()
    {
                                                                                                                                    
    }

}
