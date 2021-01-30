using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlAppBar : ControlCommands
{
    private Image border;
    LinkedList<GameObject> screenObjectList,iconObjectList;
    List<System.Action> iconTriggerDict;
    List<System.Action> iconBumperDict;
    private float seconds = 1f;
    //sadly this is globalized in the code, not sure how to pass parameters in system actions
    private GameObject tempScreen; 
    private GameObject currIconAnimation;

    void Awake()
    {
        base.Awake();
        Image appImage = GameObject.FindWithTag("AppBar").GetComponent<Image>();
        border = appImage;
        
        //Orders the screens that would have to be activated or deactivated on the list
        screenObjectList = new LinkedList<GameObject>();
        screenObjectList.AddLast(GameObject.FindWithTag("TaskScreen"));
        screenObjectList.AddLast(GameObject.FindWithTag("ScienceScreen"));
        screenObjectList.AddLast(GameObject.FindWithTag("NavigationScreen"));
        screenObjectList.AddLast(GameObject.FindWithTag("MediaScreen"));
        handleScreenDisplay();

        //Orders the icons on the list
        iconObjectList = new LinkedList<GameObject>();
        iconObjectList.AddLast(GameObject.FindWithTag("TaskIcon"));
        iconObjectList.AddLast(GameObject.FindWithTag("ScienceIcon"));
        iconObjectList.AddLast(GameObject.FindWithTag("NavIcon"));
        iconObjectList.AddLast(GameObject.FindWithTag("MediaIcon"));

        //Trigger States
        iconTriggerDict = new List<System.Action>();
        iconTriggerDict.Add(MoveFirstToLast);
        iconTriggerDict.Add(MoveSecondToFirst);
        iconTriggerDict.Add(MoveThirdToSecond);
        iconTriggerDict.Add(MoveFourthToThird);
        //Bumper States
        // iconBumperDict = new List<System.Action>();
        // iconBumperDict.Add(MoveFirstToSecond);
        // iconBumperDict.Add(MoveSecondToThird);
        // iconBumperDict.Add(MoveThirdToFourth);
        // iconBumperDict.Add(MoveLastToFirst);
    }

    public override void triggerDown()
    {   
        moveIconsForward();
        moveScreensForward();
    }
    
     public override void bumperDown()
    {
       
    }

    //Moves the order of the screens by having the first one go to the last one
    private void moveScreensForward()
    {
        var oldFirst = screenObjectList.First.Value;
        screenObjectList.RemoveFirst();
        screenObjectList.AddLast(oldFirst);
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


    //Moves the orders of the icons by having the first one go to the last one
    private void moveIconsForward()
    {
        handleIconDisplay();
        var oldFirst = iconObjectList.First.Value;
        iconObjectList.RemoveFirst();
        iconObjectList.AddLast(oldFirst);
    }


    //Moves the orders of the icons by having the first one go to the last one
    private void handleIconDisplay()
    {
        var  icon = iconObjectList.First;
        int i = 0;
        iconTriggerDict.ForEach(delegate(System.Action currAnimation)
        {
            currIconAnimation = icon.Value;
            currAnimation.Invoke();
            icon = icon.Next;  
        }); 
    }

    /*
        Below are the methods that act like event handlers for the animation of that particular gameobject
    */
    public void MoveFirstToLast()
    {
        StartCoroutine(MoveFirstToLastRoutine());                                                                                       
    }

    IEnumerator MoveFirstToLastRoutine()
    {
        var  animateControl = currIconAnimation.GetComponent<Animator>();
        idleResetTrigger(animateControl);
        animateControl.SetTrigger("MoveFirstToLast");  
        yield return new WaitForSeconds(seconds);
        resetTriggers(animateControl);  
    }
    
    public void MoveSecondToFirst()
    {
       StartCoroutine(MoveSecondToFirstRoutine());                                                     
    }

    IEnumerator MoveSecondToFirstRoutine()
    {
        var  animateControl = currIconAnimation.GetComponent<Animator>();
        idleResetTrigger(animateControl);
        animateControl.SetTrigger("MoveSecondToFirst");       
        yield return new WaitForSeconds(seconds);
        resetTriggers(animateControl);    
    }
    
    public void MoveThirdToSecond()
    {
        StartCoroutine(MoveThirdToSecondRoutine());                                                                                                                   
    }

    IEnumerator MoveThirdToSecondRoutine()
    {
        var  animateControl = currIconAnimation.GetComponent<Animator>();
        idleResetTrigger(animateControl);
        animateControl.SetTrigger("MoveThirdToSecond");         
        yield return new WaitForSeconds(seconds);
        resetTriggers(animateControl);  
    }

    public void MoveFourthToThird()
    {
        StartCoroutine(MoveFourthToThirdRoutine());                                                                                                    
    }

    IEnumerator MoveFourthToThirdRoutine()
    {
        var  animateControl = currIconAnimation.GetComponent<Animator>();
        idleResetTrigger(animateControl);
        animateControl.SetTrigger("MoveFourthToThird"); 
        yield return new WaitForSeconds(seconds);
        resetTriggers(animateControl);  
    }
    
    // public void MoveFirstToSecond()
    // {
    //     var  m_Animator = currIconAnimation.GetComponent<AppBarAnimationEvent>();
    //     m_Animator.MoveFirstToSecond();                                                                                                                             
    // }
    
    // public void MoveSecondToThird()
    // {
    //     var  m_Animator = currIconAnimation.GetComponent<AppBarAnimationEvent>();
    //     m_Animator.MoveSecondToThird();                                                                                                                              
    // }

    // public void MoveThirdToFourth()
    // {
    //     var  m_Animator = currIconAnimation.GetComponent<AppBarAnimationEvent>();
    //     m_Animator.MoveThirdToFourth();                                                                                                                              
    // }

    // public void MoveLastToFirst()
    // {
    //     var  m_Animator = currIconAnimation.GetComponent<AppBarAnimationEvent>();
    //     m_Animator.MoveLastToFirst();                                                                                                                          
    // }

    //For testing purposes
    private void display()
    { 
        var innerNode =  screenObjectList.First;
        for(int i = 0; i<screenObjectList.Count;i++)
        {
            Debug.Log(innerNode.Value);
            innerNode = innerNode.Next;
        }
    }

    private void resetTriggers(Animator animateControl)
    {
        animateControl.ResetTrigger("MoveFirstToLast");
        animateControl.ResetTrigger("MoveSecondToFirst");
        animateControl.ResetTrigger("MoveThirdToSecond");
        animateControl.ResetTrigger("MoveFourthToThird");
        animateControl.SetTrigger("Idle"); 
    }

    private void idleResetTrigger(Animator animateControl)
    {
        animateControl.ResetTrigger("Idle");
    }

}
