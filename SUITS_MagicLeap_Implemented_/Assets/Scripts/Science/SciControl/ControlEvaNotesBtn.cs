using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlEvaNotesBtn : ControlCommands
{
    
    private Image border;

    protected override void Awake()
    {
        base.Awake();
        border = GameObject.FindWithTag("EvaToolBtn").GetComponent<Image>();
    }

    public override void triggerUp()
    {
        //Task is open
        if (border.enabled)
        {

        }
    }

    public override void bumperUp()
    {
        //Task is open
        if (border.enabled)
        {
            
        }
    }
    
    public override void triggerHold()
    {
        //Task is open
        if (border.enabled)
        {
            
        }
    }
    public override void bumperHold()
    {
           //Task is open
        if (border.enabled)
        {
            
        }
    }
}
