using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlTaskSelect : ControlCommands
{
    private TaskScreenManager taskScreen;
    private Image border;

    protected override void Awake()
    {
        base.Awake();
        taskScreen = GameObject.FindWithTag("TaskScreen").GetComponent<TaskScreenManager>();
        border = GameObject.FindWithTag("TaskSelection").GetComponent<Image>();
    }

    public override void triggerDown()
    {
        //Task is open
        if (border.enabled)
        {
            taskScreen.getTask().nextTask();
            taskScreen.getDisplay().changeTask();
        }
    }

    public override void bumperDown()
    {
        //Task is open
        if (border.enabled)
        {
            taskScreen.getTask().prevTask();
            taskScreen.getDisplay().changeTask();
        }
    }
}
