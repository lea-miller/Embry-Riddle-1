using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionAppBar : GenericCollision
{
    private Image appBorder;

    void Awake()
    {
        appBorder = GameObject.FindWithTag("AppBar").GetComponent<Image>();
    }

    void Start()
    {
        isOff();
    }

    public override void isOn()
    {
        appBorder.enabled = true;
    }

    public override void isOff()
    {
        appBorder.enabled = false;
    }
}
