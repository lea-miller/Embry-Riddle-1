using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class TaskInputControl : MonoBehaviour
{
    private GameObject instruct, pageText, taskLengthObj;
    private bool isOpenPanel;
    private TextMeshProUGUI textInstruction, textPage, textTaskLength;
    private CSVReader reader;
    private List<List<List<string>>> tasks;
    private int pageCounter, taskCounter;

    void Awake()
    {
        instruct = GameObject.FindGameObjectWithTag("InstructText");
        pageText = GameObject.FindGameObjectWithTag("PageCounter");
        taskLengthObj = GameObject.FindGameObjectWithTag("TaskCounter");
        reader = gameObject.GetComponent<CSVReader>();
        textInstruction = instruct.GetComponent<TextMeshProUGUI>();
        textPage = pageText.GetComponent<TextMeshProUGUI>();
        textTaskLength = taskLengthObj.GetComponent<TextMeshProUGUI>();
        taskCounter = 0;
    }
 
    void Start()
    {
        tasks = reader.getTask();
        pageCounter = 1;
        getInstruction();
        displayInstruct();
    }

    public void TriggerTaskView()
    {
        setTaskBoolean();
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
            Debug.Log("Prev Task");
        }
        else //Task is closed
        {
            prevPage();
            Debug.Log("Prev Page");
        }
    }

    private void nextTask()
    {
        taskCounter = taskCounter + 1;
        counterTaskCheck();
    }

    private void previousTask()
    {
        taskCounter = taskCounter - 1;
        counterTaskCheck();
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
        if(pageCounter > reader.getMaxPages(taskCounter))
        {
            pageCounter = pageCounter - 1;
            getInstruction();
        }
        else if (pageCounter <= 0)
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
    private void counterTaskCheck()
    {
        if (taskCounter > reader.getTaskLength())
        {
           taskCounter = taskCounter - 1;
            displayInstruct();
        }
        else if (taskCounter < 0)
        {
            taskCounter = taskCounter + 1;
            displayInstruct();
        }
        else
        {
            displayInstruct();
        }
    }

    //Builds the string for the TextMeshPro
    private void getInstruction()
    {
        List<int> list = reader.getInstructionIndex(pageCounter,taskCounter);
        int startIndex = list[0];
        int endIndex = list.Last();
        string joinString = "";
        int stepNum;

        //displays the instruction per the indexs related to that page
        for (int i=endIndex; i>=startIndex; i--)
        {
            string tempInstruct = tasks[taskCounter][1][i];
            stepNum = i + 1;
            joinString = stepNum + " " + tempInstruct + "\n" + "\n" + joinString;
        }

        displayInstructCanvas(joinString);
    }

    //Displays the page information to the GUI
    private void displayInstructCanvas(string joinString)
    {
        textInstruction.text = joinString;
        textPage.text = pageCounter + " out of " + reader.getMaxPages(taskCounter);
    }

    //Displays Task Total
    private void displayInstruct()
    {
 
        textTaskLength.text = ((taskCounter < reader.getTaskLength()-1) ? taskCounter+1 : taskCounter) 
            + " out of " + reader.getTaskLength();

        Debug.Log("TaskCounter: " + taskCounter);
    }
}
