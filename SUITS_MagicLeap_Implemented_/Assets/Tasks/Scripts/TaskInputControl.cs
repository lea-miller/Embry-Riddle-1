using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class TaskInputControl : MonoBehaviour
{
    public GameObject taskSelBtn, taskSelBtn1, taskSelBtn2;
    private GameObject instruct, pageText, taskLengthObj, taskRectangle;
    private bool isOnTask, isSelectedNext, curTaskSelected;
    private TextMeshProUGUI textInstruction, textPage, textTaskLength;
    private CSVReader reader;
    private List<List<List<string>>> tasks;
    private int pageCounter, taskCounter, testCounter;
    private static int rectangleLoc = 550;
    private static float waitTime = 0.5f;

    void Awake()
    {
        instruct = GameObject.FindGameObjectWithTag("InstructText");
        pageText = GameObject.FindGameObjectWithTag("PageCounter");
        taskLengthObj = GameObject.FindGameObjectWithTag("TaskCounter");
        taskRectangle = GameObject.FindGameObjectWithTag("Task Selected");

        reader = gameObject.GetComponent<CSVReader>();
        textInstruction = instruct.GetComponent<TextMeshProUGUI>();
        textPage = pageText.GetComponent<TextMeshProUGUI>();
        textTaskLength = taskLengthObj.GetComponent<TextMeshProUGUI>();
        taskCounter = 0;
        pageCounter = 1;
        curTaskSelected = true;
        isOnTask = false;
    }

    void Start()
    {
        tasks = reader.getTask();
        getInstruction();
        displayTaskPanel();
        TriggerTaskView();
    }

    public void TriggerTaskView()
    {
        setTaskBoolean();
        StartCoroutine(currentSelection());
        transitionRectangleMove();
    }

    private bool getTaskBoolean()
    {
        return isOnTask;
    }

    private void setTaskBoolean()
    {
        isOnTask = !isOnTask;
    }

    public void checkTrigger()
    {
        //Task is open
        if(isOnTask)
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
        if (isOnTask)
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
        isSelectedNext = true;
        counterTaskCheck();
        displayTaskPanel();
        transitionRectangleMove();
    }

    private void previousTask()
    {
        taskCounter = taskCounter - 1;
        isSelectedNext = false;
        counterTaskCheck();
        displayTaskPanel();
        transitionRectangleMove();
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
        if (taskCounter > reader.getTaskLength()-1)
        {
           taskCounter = taskCounter - 1;
            
        }
        else if (taskCounter < 0)
        {
            taskCounter = taskCounter + 1;
            
        }
    }

    //Builds the string for the TextMeshPro
    private void getInstruction()
    {
        List<int> list = reader.getInstructionIndex(pageCounter,taskCounter);
        int startIndex = list[0];
        int endIndex = list.Last();
        string joinString = "";
        int stepNum = 0;

        //displays the instruction per the indexs related to that page
        for (int i=endIndex; i>=startIndex; i--)
        {
            string tempInstruct = tasks[taskCounter][1][i];
            stepNum = i + 1;
            joinString = stepNum + " " + tempInstruct + "\n" + "\n" + joinString;
        }

        displayInstructionPanel(joinString);
    }

    //Displays the page information to the GUI
    private void displayInstructionPanel(string joinString)
    {
        textInstruction.text = joinString;
        textPage.text = pageCounter + " out of " + reader.getMaxPages(taskCounter);
    }

    //Displays Task Total
    private void displayTaskPanel()
    {
        textTaskLength.text = ((taskCounter <= reader.getTaskLength()-1) ? taskCounter+1 : taskCounter) 
            + " out of " + reader.getTaskLength();
    }

    private bool canMove()
    {
        if(taskCounter < 0 && !isSelectedNext)
        {
            return false;
        }
        else if (taskCounter > reader.getTaskLength() && isSelectedNext)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //Feedback to the user : the selected task is highlighted
    private void transitionRectangleMove()
    {
        
        if (taskCounter == 0)
        {
            Debug.Log("transitionRect");
            taskSelBtn.SetActive(true);
            taskSelBtn1.SetActive(false);
            taskSelBtn2.SetActive(false);
        }
        else if (taskCounter == 1)
        {
            taskSelBtn1.SetActive(true);
            taskSelBtn.SetActive(false);
            taskSelBtn2.SetActive(false);
        }
        else if (taskCounter == 2)
        {
            taskSelBtn2.SetActive(true);
            taskSelBtn.SetActive(false);
            taskSelBtn1.SetActive(false);
        }
    }

    //Feedback to the user : blink if on task
    private IEnumerator currentSelection()
    {
        Debug.Log("CurrentSelect: " + isOnTask);
        while (isOnTask)
        {
            yield return new WaitForSeconds(waitTime);
            curTaskSelected = !curTaskSelected;
           
            if (taskCounter == 0)
            {
                taskSelBtn.SetActive(curTaskSelected);
            }
            else if (taskCounter == 1)
            {
                taskSelBtn1.SetActive(curTaskSelected);
            }
            else if (taskCounter == 2)
            {
                taskSelBtn2.SetActive(curTaskSelected);
            }
        }
    }

}
