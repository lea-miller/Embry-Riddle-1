using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskInputControl : MonoBehaviour
{
    private bool isOnTask, isSelectedNext;
    private CSVReader reader;
    private List<List<List<string>>> tasks;
    private int pageCounter, taskCounter, testCounter;
    private List<int> taskTracker;
    private TaskDisplay display;
    private string instructionString;
    private bool curTaskSelected;
    private readonly float waitTime = 0.3f;
   
    void Awake()
    {
        reader = gameObject.GetComponent<CSVReader>();
        display = gameObject.GetComponent<TaskDisplay>();
        taskTracker = new List<int>();
        isOnTask = false;
        curTaskSelected = true;
        taskCounter = 0;
        pageCounter = 1;
        instructionString = "";
    }

    void Start()
    {
        tasks = reader.getTask();
        taskTracker.Add(taskCounter);
        TriggerTaskView();
        display.updateImage(tasks,taskCounter,pageCounter);
    }

    private void refreshTaskScreen()
    {
        instructionString = reader.getInstruction(pageCounter,taskCounter);
        display.displayInstructionPanel(instructionString,pageCounter,taskCounter);
        display.displayTaskPanel(taskCounter);
       
        transitionRectangleMove();
        display.updateImage(tasks,taskCounter,pageCounter);
    }

    //Swaps between task selection and instruction selection
    public void TriggerTaskView()
    {
        setTaskBoolean();
        StartCoroutine(currentSelection());
        transitionRectangleMove();
    }

    public void checkTrigger()
    {
        //Task is open
        if(isOnTask)
        {
            taskCounter = taskCounter + 1;
            isSelectedNext = true;
            changeTask();
        }
        else //Task is closed
        {
            pageCounter = pageCounter + 1;
            changePage();
            
        }
    }

    public void checkBumper()
    {
        //Task is open
        if (isOnTask)
        {
            taskCounter = taskCounter - 1;
            isSelectedNext = false;
            changeTask();
        }
        else //Task is closed
        {
            pageCounter = pageCounter - 1;
            changePage();
        }
    }

    private void changeTask()
    {
        counterTaskCheck();
        updateTaskSelected();
    }

    private void changePage()
    {
        pageCounterCheck();
        instructionString = reader.getInstruction(pageCounter,taskCounter);
        display.displayInstructionPanel(instructionString,pageCounter,taskCounter);
        display.updateImage(tasks,taskCounter,pageCounter);
    }

    //Ensures that the user doesn't exceed the instruct page limits
    private void pageCounterCheck()
    {
        if(pageCounter > reader.getMaxPages(taskCounter))
        {
            pageCounter = pageCounter - 1;

        }
        else if (pageCounter <= 0)
        {
            pageCounter = pageCounter + 1;

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

    //If the user selects a new task
    private void updateTaskSelected()
    {
        //check the counter and list : import if it hasn't already
        if (!taskTracker.Contains(taskCounter))
        {
            taskTracker.Add(taskCounter);
            reader.loadTaskName(taskCounter);
            reader.importTaskList();
            tasks = reader.getTask();
        }
        //Display newly update information
        pageCounter = 1;
        refreshTaskScreen();
    }

    //Feedback to the user : the selected task is highlighted
    private void transitionRectangleMove()
    {
        if (taskCounter == 0)
        {
            if (isOnTask)
            {
                display.changeActiceBtnState(true, false, false);
            }
        }
        else if (taskCounter == 1)
        {
            display.changeActiceBtnState(false, true, false);
        }
        else if (taskCounter == 2)
        {
           display.changeActiceBtnState(false, false, true);
        }
    }

   //Feedback to the user : blink if on task
    private IEnumerator currentSelection()
    {
        while (isOnTask)
        {
            yield return new WaitForSeconds(waitTime);
            curTaskSelected = !curTaskSelected;
           
            if (taskCounter == 0)
            {
                display.changeBtnState(curTaskSelected);
            }
            else if (taskCounter == 1)
            {
                display.changeBtn1State(curTaskSelected);
            }
            else if (taskCounter == 2)
            {
                display.changeBtn2State(curTaskSelected);
            }
        }
        yield return new WaitForSeconds(0);
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

    private bool getTaskBoolean()
    {
        return isOnTask;
    }

    private void setTaskBoolean()
    {
        isOnTask = !isOnTask;
    }
}
