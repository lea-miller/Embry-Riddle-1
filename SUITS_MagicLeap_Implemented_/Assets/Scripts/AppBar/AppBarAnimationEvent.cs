using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppBarAnimationEvent : MonoBehaviour
{
    public GameObject appIcon;
    public Animator animateControl;
    // Start is called before the first frame update
    void Start()
    {
        if(appIcon == null)
        {
            Debug.Log("NULL ERROR for APP ICON: One of the app bar icons are null please check the inspector! " + 
            "Certain functionalities will not work if this is not fixed, script thrown: " + 
            "AppBarAnimationEvent");
        }
        if(animateControl == null)
        {
            Debug.Log("NULL ERROR for APP ICON ANIMATION:One of the app bar icons are null please check the inspector! " + 
            "Certain functionalities will not work if this is not fixed, script thrown: " + 
            "AppBarAnimationEvent");
        }
    }
    
    public void MoveFirstToLast()
    {
        idleResetTrigger();
        animateControl.SetTrigger("MoveFirstToLast");                                                                                                         
    }
    
    public void MoveSecondToFirst()
    {
        idleResetTrigger();
        animateControl.SetTrigger("MoveSecondToFirst");                                                                               
    }
    
    public void MoveThirdToSecond()
    {
        idleResetTrigger();
        animateControl.SetTrigger("MoveThirdToSecond");                                                                                                                              
    }

    public void MoveFourthToThird()
    {
        idleResetTrigger();
        animateControl.SetTrigger("MoveFourthToThird");                                                                                                                    
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

    public void resetTriggers()
    {
        animateControl.ResetTrigger("MoveFirstToLast");
        animateControl.ResetTrigger("MoveSecondToFirst");
        // animateControl.ResetTrigger("MoveThirdToSecond");
        // animateControl.ResetTrigger("MoveFourthToThird");
        animateControl.SetTrigger("Idle"); 
    }

    private void idleResetTrigger()
    {
        animateControl.ResetTrigger("Idle");
    }
}
