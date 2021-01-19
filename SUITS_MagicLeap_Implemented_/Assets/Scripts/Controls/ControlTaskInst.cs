using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlTaskInst : ControlCommands
{
    private TaskScreenManager taskScreen;
    private Image border;

    protected override void Awake()
    {
        base.Awake();
        taskScreen = GameObject.FindWithTag("TaskScreen").GetComponent<TaskScreenManager>();
        border = GameObject.FindWithTag("TaskInstruction").GetComponent<Image>();
    }

    public override void triggerDown()
    {
        //Task is open
        if (border.enabled)
        {
            taskScreen.getInstruct().nextInst();
            taskScreen.getDisplay().changePage();
        }
    }

    public override void bumperDown()
    {
        //Task is open
        if (border.enabled)
        {
            taskScreen.getInstruct().prevInst();
            taskScreen.getDisplay().changePage();
        }
    }

}
