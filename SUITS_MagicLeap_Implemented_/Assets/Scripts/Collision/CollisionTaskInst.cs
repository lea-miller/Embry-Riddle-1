using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTaskInst : CollisionManager
{ 
    protected override void Awake()
    {
        base.Awake();
        userCollider.notifyInstHit += isOn;
    }


    protected override void isOn()
    {
        taskImage.enabled = false;
        taskTopImage.enabled = false;
        instructImage.enabled = true;

        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }

}
