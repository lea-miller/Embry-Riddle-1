using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionVitals : GenericCollision, ICollisionVital
{
    public Image vitalImage { set; get; }
    public Image vitalMainScreen { set; get; }
    public GameObject mainScreen { set; get; }
    public GameObject topView { set; get; }

    protected virtual void Awake()
    {
        CollisionVitalManager manager = GameObject.FindWithTag("VitalsUI").GetComponent<CollisionVitalManager>();
        vitalImage = manager.vitalImage;
        vitalMainScreen = manager.vitalMainScreen;
        mainScreen = manager.mainScreen;
        topView = manager.topView;
    }

    public override void isOn() { }
    public override void isOff()
    {
        mainScreen.SetActive(true);
        topView.SetActive(false);
        vitalMainScreen.enabled = false;
        vitalImage.enabled = false;
    }
}
