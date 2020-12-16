using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTaskTopPanel : CollisionTask
{ 

    protected override void Awake()
    {
        base.Awake();
    }

    public override void isOn()
    {
        taskImage.enabled = false;
        taskTopImage.enabled = true;
        instructImage.enabled = false;

        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }
}
