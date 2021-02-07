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
        if (border.enabled)
        {
            //taskScreen.getInstruct().nextInst();
            //taskScreen.getDisplay().changePage();

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
        if (border.enabled)
        {
            //taskScreen.getInstruct().prevInst();
            //taskScreen.getDisplay().changePage();
            if (taskScreen.getPageCounter() > 1)
            {
                taskScreen.getDisplay().changePage(-1);
            }
        }
    }
    
    public override void triggerHold()
    {
        loadingBar.changeColorToComplete();
        //Debug.Log("Trigger Hold, approved");
    }

    public override void bumperHold()
    {
        loadingBar.changeColorToSkip();
    }
}
