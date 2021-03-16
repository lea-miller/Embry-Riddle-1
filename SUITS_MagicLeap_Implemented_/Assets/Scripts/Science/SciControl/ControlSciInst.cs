using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ControlSciInst : ControlCommands
{
    private SciScreenManager sciScreen;
    private Image border;
    private TextMeshProUGUI textInstruction;
    [SerializeField]
    private ColorLoad loadingBar;

    protected override void Awake()
    {
        base.Awake();
        sciScreen = GameObject.FindWithTag("ScienceScreen").GetComponent<SciScreenManager>();
        border = GameObject.FindWithTag("SciInstruction").GetComponent<Image>();
    }

    public override void triggerUp()
    {
        //Task is open
        //loadingBar.isClickDown = false;
        if (border.enabled)
        {
            if (sciScreen.getPageCounter() < sciScreen.getMaxPages()) 
            {
                sciScreen.getDisplay().changePage(1);
                //Debug.Log("Trigger Up, approved");
            }
        }
    }

    public override void bumperUp()
    {
        //Task is open
        //loadingBar.isClickDown = false;
        if (border.enabled)
        {
            if (sciScreen.getPageCounter() > 1)
            {
                sciScreen.getDisplay().changePage(-1);
            }
        }
    }
    
    public override void triggerHold(){}
    public override void bumperHold(){}
}
