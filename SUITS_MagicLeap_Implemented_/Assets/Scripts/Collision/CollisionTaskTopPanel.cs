using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTaskTopPanel : CollisionTask
{ 
    protected override void Start()
    {
        base.Start();
    }

    public override void isOn()
    {
        taskTopImage.enabled = true;
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }
}
