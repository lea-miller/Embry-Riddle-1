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
        Debug.Log("Hello! I am in AnimationEvent! 1");                                                                                                               
    }
    
    public void MoveSecondToFirst()
    {
        Debug.Log("Hello! I am in AnimationEvent! 2");                                                                                        
    }
    
    public void MoveThirdToSecond()
    {
        Debug.Log("Hello! I am in AnimationEvent! 3");                                                                                                                              
    }

    public void MoveFourthToThird()
    {
       Debug.Log("Hello! I am in AnimationEvent! 4");                                                                                                                       
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
