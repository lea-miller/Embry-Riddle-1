using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTaskSelect : CollisionTask
{

    protected override void Awake()
    {
        base.Awake();
    }

    public override void isOn()
    {
        instructImage.enabled = false;
        taskImage.enabled = true;
        taskTopImage.enabled = false;

        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }
}
