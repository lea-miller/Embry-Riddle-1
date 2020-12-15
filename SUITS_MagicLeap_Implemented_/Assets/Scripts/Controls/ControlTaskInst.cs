using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlTaskInst : ControlCommands
{

    protected override void Awake()
    {
        base.Awake();
        border = GameObject.FindWithTag("TaskInstruction").GetComponent<Image>();
    }

    public override void nextSelection()
    {
        //Task is open
        if (border.enabled)
        {
            taskScreen.getInstruct().nextInst();
            taskScreen.getDisplay().changePage();
        }
    }

    public override void prevSelection()
    {
        //Task is open
        if (border.enabled)
        {
            taskScreen.getInstruct().prevInst();
            taskScreen.getDisplay().changePage();
        }
    }

}
