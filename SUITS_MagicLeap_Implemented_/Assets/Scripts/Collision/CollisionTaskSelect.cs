using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTaskSelect : CollisionManager
{

    protected override void Awake()
    {
        base.Awake();
        userCollider.notifyTaskHit += isOn;
    }

    protected override void isOn()
    {
        instructImage.enabled = false;
        taskImage.enabled = true;
        taskTopImage.enabled = false;

        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }
}
