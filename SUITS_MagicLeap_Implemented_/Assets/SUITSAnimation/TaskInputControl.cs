using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class TaskInputControl : MonoBehaviour
{
    private GameObject btn, panel, instruct, pageText;
    private bool isOpenPanel;
    private TextMeshProUGUI textInstruction, textPage;
    private CSVReader reader;
    private List<List<List<string>>> tasks;
    private int pageCounter, taskCounter;

    void Awake()
    {
        btn = gameObject.transform.Find("Grouping Button").gameObject;
        panel = gameObject.transform.Find("Panel Task View").gameObject;
        instruct = GameObject.FindGameObjectWithTag("InstructText");
        pageText = GameObject.FindGameObjectWithTag("PageCounter");
        reader = gameObject.GetComponent<CSVReader>();
        textInstruction = instruct.GetComponent<TextMeshProUGUI>();
        textPage = pageText.GetComponent<TextMeshProUGUI>();
        pageCounter = 0;
        taskCounter = 0;
    }

    void Start()
    {
        tasks = reader.getTask();
        pageCounter = 1;
        getInstruction();
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
                setTaskBoolean();
                animPanel.SetBool("open", getTaskBoolean());
                animBtn.SetBool("open", getTaskBoolean());
            }
        }
    }

    private bool getTaskBoolean()
    {
        return isOpenPanel;
    }

    private void setTaskBoolean()
    {
        isOpenPanel = !isOpenPanel;
    }

    public void checkTrigger()
    {
        //Task is open
        if(!isOpenPanel)
        {
            nextTask();
            Debug.Log("Next Task");
        }
        else //Task is closed
        {
            nextPage();
            Debug.Log("Next Page");
        }
    }

    public void checkBumper()
    {
        //Task is open
        if (!isOpenPanel)
        {
            previousTask();
        }
        else //Task is closed
        {
            prevPage();
        }
    }

    private void nextTask()
    {
        taskCounter = taskCounter + 1;
    }

    private void previousTask()
    {
        taskCounter = taskCounter - 1;
    }

    private void nextPage()
    {
        pageCounter = pageCounter + 1;
        pageCounterCheck();
    }

    private void prevPage()
    {
        pageCounter = pageCounter - 1;
        pageCounterCheck();
    }

    //Ensures that the user doesn't exceed the instruct page limits
    private void pageCounterCheck()
    {
        if(pageCounter > reader.getMaxPages())
        {
            pageCounter = pageCounter - 1;
            getInstruction();
        }
        else if (pageCounter < 0)
        {
            pageCounter = pageCounter + 1;
            getInstruction();
        }
        else
        {
            getInstruction();
        }
    }

    //Ensures that the user doesn't exceed the task limits
    private int counterTaskCheck()
    {
        if (taskCounter > 1)
        {
            return taskCounter = taskCounter - 1;
        }
        else if (pageCounter < 0)
        {
            return taskCounter = taskCounter + 1;
        }
        else
        {
            return taskCounter;
        }
    }

    //Builds the string for the TextMeshPro
    private void getInstruction()
    {
        List<int> list = reader.getInstructionIndex(pageCounter);
        int startIndex = list[0];
        int endIndex = list.Last();
        string joinString = "";
        int stepNum;

        //displays the instruction per the indexs related to that page
        for (int i=endIndex; i>=startIndex; i--)
        {
            string tempInstruct = tasks[0][1][i];
            stepNum = i + 1;
            joinString = stepNum + " " + tempInstruct + "\n" + "\n" + joinString;
        }

        displayInstructCanvas(joinString);
    }

    //Displays the page information to the GUI
    private void displayInstructCanvas(string joinString)
    {
        textInstruction.text = joinString;
        textPage.text = pageCounter + " out of " + reader.getMaxPages();
    }
}
