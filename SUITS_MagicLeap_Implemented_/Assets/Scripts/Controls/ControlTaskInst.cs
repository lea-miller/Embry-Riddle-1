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
            //taskScreen.getInstruct().nextInst();
            //taskScreen.getDisplay().changePage();
            textInstruction = taskScreen.getDisplay().textInstruction;
            

            if (textInstruction.pageToDisplay < textInstruction.textInfo.pageCount) 
            { 
                textInstruction.pageToDisplay = (textInstruction.pageToDisplay + 1);
            }

        }
    }

    public override void bumperDown()
    {
        //Task is open
        if (border.enabled)
        {
            //taskScreen.getInstruct().prevInst();
            //taskScreen.getDisplay().changePage();
            if (textInstruction.pageToDisplay > 1)
            {
                textInstruction.pageToDisplay = (textInstruction.pageToDisplay - 1);
            }
        }
    }

}
