﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlTaskSelect : ControlCommands
{
    protected override void Awake()
    {
        base.Awake();
        Image taskImage = GameObject.FindWithTag("TaskSelection").GetComponent<Image>();
        border = taskImage;
    }


    public override void nextSelection()
    {
        //Task is open
        if (border.enabled)
        {
            taskScreen.getTask().nextTask();
            taskScreen.getDisplay().changeTask();
        }
    }

    public override void prevSelection()
    {
        //Task is open
        if (border.enabled)
        {
            taskScreen.getTask().prevTask();
            taskScreen.getDisplay().changeTask();
        }
    }
}
