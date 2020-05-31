using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskInputControl : MonoBehaviour
{
    public GameObject taskSelBtn, taskSelBtn1, taskSelBtn2;
    private GameObject instruct, pageText, taskLengthObj, taskRectangle, instImageObj;
    public Image instImage;
    private Material mat;
    private bool isOnTask, isSelectedNext, curTaskSelected;
    private TextMeshProUGUI textInstruction, textPage, textTaskLength;
    private CSVReader reader;
    private List<List<List<string>>> tasks;
    private int pageCounter, taskCounter, testCounter;
    private static int rectangleLoc = 550;
    private static float waitTime = 0.3f;
    private List<int> taskTracker;
   
    void Awake()
    {
        instruct = GameObject.FindGameObjectWithTag("InstructText");
        pageText = GameObject.FindGameObjectWithTag("PageCounter");
        taskLengthObj = GameObject.FindGameObjectWithTag("TaskCounter");
        taskRectangle = GameObject.FindGameObjectWithTag("Task Selected");
        instImageObj = GameObject.FindGameObjectWithTag("Task Image");
        mat = Resources.Load<Material>("Materials/Transparent");

        instImage = instImage.GetComponent<Image>();
        reader = gameObject.GetComponent<CSVReader>();
        textInstruction = instruct.GetComponent<TextMeshProUGUI>();
        textPage = pageText.GetComponent<TextMeshProUGUI>();
        textTaskLength = taskLengthObj.GetComponent<TextMeshProUGUI>();
      
        taskTracker = new List<int>();
        curTaskSelected = true;
        isOnTask = false;
        taskCounter = 0;
        pageCounter = 1;
    }

    void Start()
    {
        tasks = reader.getTask();
        taskTracker.Add(taskCounter);
        getInstruction();
        displayTaskPanel();
        TriggerTaskView();
        updateImage();
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
        }
        else //Task is closed
        {
            nextPage();
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
        updateTaskSelected();
    }

    private void previousTask()
    {
        taskCounter = taskCounter - 1;
        isSelectedNext = false;
        counterTaskCheck();
        updateTaskSelected();
    }

    private void nextPage()
    {
        pageCounter = pageCounter + 1;
        pageCounterCheck();
        getInstruction();
        updateImage();
    }

    private void prevPage()
    {
        pageCounter = pageCounter - 1;
        pageCounterCheck();
        getInstruction();
        updateImage();
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

    //Builds the string for the TextMeshPro
    private void getInstruction()
    {
        List<int> list = reader.getInstructionIndex(pageCounter,taskCounter);
        int startIndex = list[0];
        int endIndex = list.Last();
        string joinString = "";

        //displays the instruction per the indexs related to that page
        for (int i=endIndex; i>=startIndex; i--)
        {
            string tempInstruct = tasks[taskCounter][1][i];
            joinString = tempInstruct + "\n" + "\n" + joinString;
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
            if (isOnTask)
            {
                taskSelBtn.SetActive(true);
                taskSelBtn1.SetActive(false);
                taskSelBtn2.SetActive(false);
            }
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
        yield return new WaitForSeconds(0);
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
        getInstruction();
        displayTaskPanel();
        transitionRectangleMove();
        updateImage();
    }

    //Updates the impage based on the instruction
    private void updateImage()
    {
        //Only need to pull the first index of the instImage for the page
        List<int> list = reader.getInstructionIndex(pageCounter,taskCounter);
        int startIndex = list[0];
        string currImage = tasks[taskCounter][2][startIndex];
            //Trim is needed to remove the white spaces that are in the list
            string path = "Sprites/" + currImage.Trim();
            Sprite currSprite = Resources.Load<Sprite>(path);
            if(currSprite == null)
            {
                mat = Resources.Load<Material>("Materials/Transparent");
            }
            else
            {
                instImage.sprite = currSprite;
                mat = Resources.Load<Material>("Materials/White");
            }
            instImage.material = mat;
    }
}
