using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionVitalDisplay : GenericCollision
{
    public Image vitalImage { set; get; }
    public Image vitalMainScreen { set; get; }
    public GameObject mainScreen { set; get; }
    public GameObject topView { set; get; }

    protected void Start()
    {
        CollisionVitalManager manager = GameObject.FindWithTag("VitalsUI").GetComponent<CollisionVitalManager>();
        vitalImage = manager.vitalImage;
        vitalMainScreen = manager.vitalMainScreen;
        mainScreen = manager.mainScreen;
        topView = manager.topView;
    }

    public override void isOn()
    {
        mainScreen.SetActive(false);
        topView.SetActive(true);
        vitalMainScreen.enabled = false;
        vitalImage.enabled = true;
    }
    
    public override void isOff()
    {
        mainScreen.SetActive(true);
        topView.SetActive(false);
        vitalMainScreen.enabled = false;
        vitalImage.enabled = false;
    }

}
