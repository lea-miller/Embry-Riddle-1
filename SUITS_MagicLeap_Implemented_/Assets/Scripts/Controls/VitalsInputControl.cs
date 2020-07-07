using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalsInputControl: MonoBehaviour
{   
    private Image vitalImage {get;set;}
    
    void Awake()
    {
        userCollider.notifyVitalHit += isOnVitalCheck;
        userCollider.notifyScreenHit += isOnScreenCheck;
        vitalImage = GameObject.FindWithTag("VitalsUI").GetComponent<Image>();
    }

    private void isOnVitalCheck()
    {
        vitalImage.enabled = true;
    }

    //This method also initalizes the boolens b/c on startup the user never starts on taskscreen
    private void isOnScreenCheck()
    {
        vitalImage.enabled = false;
    }

}
