using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalsScreenManager : MonoBehaviour
{   
    private bool isOnVital {get; set;}
    private bool isOnScreen {get; set;} //check if neither
    private Image vitalImage {get;set;}
    
    void Awake()
    {
        userCollider.notifyVitalHit += isOnVitalCheck;
        userCollider.notifyScreenHit += isOnScreenCheck;
        vitalImage = GameObject.FindWithTag("VitalsUI").GetComponent<Image>();
        isOnScreen  = false;
    }

    private void isOnVitalCheck()
    {
        if(isOnVital)
        {
            vitalImage.enabled = true;
            isOnScreen = false; //avoid GUI constantly refreshing
            isOnVital = false;
        }
    }

    //This method also initalizes the boolens b/c on startup the user never starts on taskscreen
    private void isOnScreenCheck()
    {
        if(!isOnScreen)
        {
            vitalImage.enabled = false;
            isOnScreen = true;
            isOnVital = true;
        }
    }

}
