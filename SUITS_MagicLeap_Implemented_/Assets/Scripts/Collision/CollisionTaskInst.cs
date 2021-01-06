using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTaskInst : CollisionTask
{
    protected override void Start()
    {
        base.Start();
    }

    public override void isOn()
    {
        taskImage.enabled = false;
        taskTopImage.enabled = false;
        instructImage.enabled = true;

        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }
}
