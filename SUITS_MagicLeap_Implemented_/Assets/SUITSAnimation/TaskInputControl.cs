using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskInputControl : MonoBehaviour
{
    private GameObject btn, panel;
    private bool isOpenPanel;

    void Awake()
    {
        btn = gameObject.transform.Find("Grouping Button").gameObject;
        panel = gameObject.transform.Find("Panel Task View").gameObject;
    }

    public void TriggerTaskView()
    {
        if (btn != null && panel != null)
        {
            Animator animPanel = panel.GetComponent<Animator>();
            Animator animBtn = btn.GetComponent<Animator>();
            if (animBtn != null && animBtn != null)
            {
                isOpenPanel = animPanel.GetBool("open");
                animPanel.SetBool("open", !isOpenPanel);
                animBtn.SetBool("open", !isOpenPanel);
            }
        }
    }

    private bool getTaskBoolean()
    {
        return isOpenPanel;
    }

    public void checkTrigger()
    {
        //Its open
        if(isOpenPanel)
        {
            nextTask();
        }
        else //Its closed
        {
            nextInstruct();
        }
    }

    public void checkBumper()
    {
        //Its open
        if (isOpenPanel)
        {
            previousTask();
        }
        else //Its closed
        {
            previousInstruct();
        }
    }


    private void nextTask()
    {
        Debug.Log("Next Task");
    }

    private void previousTask()
    {
        Debug.Log("Prev Task");
    }

    private void nextInstruct()
    {
        Debug.Log("Next Instruct");
    }

    private void previousInstruct()
    {
        Debug.Log("Prev Instruct");
    }
}
