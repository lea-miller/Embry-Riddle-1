using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTaskTopPanel : CollisionManager
{ 

    protected override void Awake()
    {
        base.Awake();
        userCollider.notifyMainTaskHit += isOn;
    }

    protected override void isOn()
    {
        taskImage.enabled = false;
        taskTopImage.enabled = true;
        instructImage.enabled = false;

        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }
}
