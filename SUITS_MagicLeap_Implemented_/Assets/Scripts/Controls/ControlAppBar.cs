using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlAppBar : ControlCommands
{
    private Image border;
    LinkedList<GameObject> gameObjectList;
    private int triggerCount = 0;
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

        Dictionary<int, System.Action> iconTriggerDict = new Dictionary<int, System.Action>();
        iconTriggerDict.Add(0,MoveFirstToLast);
        iconTriggerDict.Add(1,MoveSecondToFirst);
        iconTriggerDict.Add(2,MoveThirdToSecond);
        iconTriggerDict.Add(3,MoveFourthToThird);
        
        Dictionary<int, System.Action> iconBumperDict = new Dictionary<int, System.Action>();
        iconBumperDict.Add(0,MoveFirstToSecond);
        iconBumperDict.Add(1,MoveSecondToThird);
        iconBumperDict.Add(3,MoveThirdToFourth);
        iconBumperDict.Add(4,MoveLastToFirst);
    }

    public override void triggerDown()
    {   
        Debug.Log("Before");
        display();
        
        //Moves the order of the lists
        var oldFirst = gameObjectList.First.Value;
        gameObjectList.RemoveFirst();
        gameObjectList.AddLast(oldFirst);
        
        Debug.Log("After");
        display();
       // gameObjectList[counter].SetActive(false);
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
                                                                                                                                    
    }
    
    public void MoveSecondToFirst()
    {
                                                                                                                                    
    }
    
    public void MoveThirdToSecond()
    {
                                                                                                                                    
    }

    public void MoveFourthToThird()
    {
                                                                                                                                    
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
