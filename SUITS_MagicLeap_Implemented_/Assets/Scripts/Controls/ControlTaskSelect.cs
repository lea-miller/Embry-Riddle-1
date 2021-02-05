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
        //taskScreen.getDisplay().refreshTaskScreen();
        {
            if (taskScreen.getTaskCounter() < taskScreen.getMaxTasks())
            {

                taskScreen.getDisplay().changeTask(1);
                Debug.Log("Trigger Down, coutner approved");
            }
        }
    }

    public override void bumperDown()
    {
        //Task is open
        if (border.enabled)
        {
            if (taskScreen.getTaskCounter() > 0)
            {

                taskScreen.getDisplay().changeTask(-1);
                Debug.Log("Trigger Down, coutner approved");
            }
        }
    }
}
