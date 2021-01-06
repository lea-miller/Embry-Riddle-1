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
        instructImage.enabled = true;
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }
}
