using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ControlTaskInst : ControlCommands
{
    private TaskScreenManager taskScreen;
    private Image border;
    private TextMeshProUGUI textInstruction;
    [SerializeField]
    private ColorLoad loadingBar;

    protected override void Awake()
    {
        base.Awake();
        taskScreen = GameObject.FindWithTag("TaskScreen").GetComponent<TaskScreenManager>();
        border = GameObject.FindWithTag("TaskInstruction").GetComponent<Image>();
    }

    public override void triggerUp()
    {
        //Task is open
        loadingBar.isClickDown = false;
        if (border.enabled)
        {
            if (taskScreen.getPageCounter() < taskScreen.getMaxPages()) 
            {
                taskScreen.getDisplay().changePage(1);
                //Debug.Log("Trigger Up, approved");
            }
        }
    }

    public override void bumperUp()
    {
        //Task is open
        loadingBar.isClickDown = false;
        if (border.enabled)
        {
            if (taskScreen.getPageCounter() > 1)
            {
                taskScreen.getDisplay().changePage(-1);
            }
        }
    }

    public override void triggerDown()
    {
        if (taskScreen.getTaskCounter() < taskScreen.getMaxTasks())
        {
            
            loadingBar.changeColorToComplete();
            loadingBar.isClickDown = true;
        }

    }

    public override void bumperDown()
    {
        if (taskScreen.getTaskCounter() < taskScreen.getMaxTasks())
        {

            loadingBar.changeColorToIncomplete();
            loadingBar.isClickDown = true;
        }

    }

    public override void triggerHold()
    {
        if(taskScreen.getTaskCounter() < taskScreen.getMaxTasks())
        {
            taskScreen.getDisplay().changeTask(1);
            loadingBar.isClickDown = false;
            //loadingBar.changeColorToComplete();
        }
        

        //Debug.Log("Trigger Hold, approved");
    }

    public override void bumperHold()
    {
        if (taskScreen.getTaskCounter() < taskScreen.getMaxTasks())
        {
            taskScreen.getDisplay().changeTask(1);
            loadingBar.isClickDown = false;
            //loadingBar.changeColorToIncomplete();
        }
        
    }
}
