using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTaskSelect : CollisionTask
{
    protected override void Start()
    {
        base.Start();
    }

    public override void isOn()
    {
        taskImage.enabled = true;
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }
}
