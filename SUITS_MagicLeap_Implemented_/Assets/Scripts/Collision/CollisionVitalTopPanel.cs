using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionVitalTopPanel : CollisionVitals
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void isOn()
    {
        mainScreen.SetActive(false);
        topView.SetActive(true);
        vitalMainScreen.enabled = true;
        vitalImage.enabled = false;
    }
}
