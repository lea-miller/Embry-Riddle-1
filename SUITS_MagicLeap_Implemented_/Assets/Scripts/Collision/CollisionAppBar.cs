using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionAppBar : GenericCollision
{
    private CollisionTask colTask;
    private Image appBorder;

    void Awake()
    {
        appBorder = GameObject.FindWithTag("AppBar").GetComponent<Image>();
        colTask = GameObject.FindWithTag("TaskInstruction").GetComponent<CollisionTaskInst>();
    }

    public override void isOn()
    {
        appBorder.enabled = true;
        //colTask.isOff();
    }

    public override void isOff()
    {
        appBorder.enabled = false;
    }
}
