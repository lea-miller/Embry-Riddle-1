using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionVitalDisplay : CollisionVitals
{
    protected override void Start()
    {
        base.Start();
    }

    public override void isOn()
    {
        mainScreen.SetActive(false);
        topView.SetActive(true);
        vitalMainScreen.enabled = false;
        vitalImage.enabled = true;
    }

}
