using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TaskScreenDisplay
{
    private CreateTaskBtn _createBtns;
    public TextMeshProUGUI textInstruction, textPage, textTaskLength;
    private Material mat;
    private Image instImage;
    private List<string> taskNames;
    private GameObject[] btns;

    TaskScreenManager manager;

   public TaskScreenDisplay(TaskScreenManager manager)
   {
        this.manager = manager;
        textInstruction = GameObject.FindGameObjectWithTag("TaskInstructionText").GetComponent<TextMeshProUGUI>();
        textPage = GameObject.FindGameObjectWithTag("PageCounter").GetComponent<TextMeshProUGUI>();
        //textTaskLength = GameObject.FindGameObjectWithTag("TaskCounter").GetComponent<TextMeshProUGUI>();
        mat = Resources.Load<Material>("Materials/Transparent");
        //instImage = GameObject.FindGameObjectWithTag("Task Image").GetComponent<Image>();

        //displayTaskNames();
        string instructionString = manager.getReader().getInstruction(0);
        displayInstructionPanel(instructionString,1,0);
        displayTaskPanel(0);
        highlightSelected();
   }

    /*
    private void displayTaskNames()
    {
        btns = new GameObject[3];
        btns[0]  = GameObject.Find("Button");
        btns[1] = GameObject.Find("Button1");
        btns[2] = GameObject.Find("Button2");

       List<string> taskNames = manager.getReader().getTaskNames();
       for(int i = 0; i<3; i++)
       {
        btns[i].GetComponentInChildren<TextMeshProUGUI>().text = taskNames[i];
       }
    }
     */

     //Displays Current Task out of the Total Task
    private void displayTaskPanel(int taskCounter)
    {
        textTaskLength.text = "T. " +  (( taskCounter <= manager.getReader().getTaskLength()-1) ? taskCounter + 1 : taskCounter) 
            + "/" + manager.getReader().getTaskLength();
    }

    //Displays the page information to the GUI
    private void displayInstructionPanel(string joinString,int pageCounter, int taskCounter)
    {
        //The task counter text starts at 1, not 0 like the data
        textInstruction.text = joinString;
        textPage.text = "P. " + textInstruction.pageToDisplay + "/" + textInstruction.textInfo.pageCount;
    }

    //If the user selects a new task
/*
public void changeTask()
{
    //check the counter and list : import if it hasn't already
    List<int> taskTracker = manager.getTaskTracker();
    if (!taskTracker.Contains(manager.getTaskCounter()))
    {
        taskTracker.Add(manager.getTaskCounter());
        manager.setTaskTracker(taskTracker);
        manager.getReader().loadTaskName(manager.getTaskCounter());
        manager.getReader().importTaskList();
        manager.setTaskList(manager.getReader().getTask());
    }
    //Display newly update information
    manager.setPageCounter(1);
    highlightSelected();
    refreshTaskScreen();
}
*/

//Feedback to the user : the selected task is highlighted
private void highlightSelected()
{  
    EventSystem.current.SetSelectedGameObject(null);
    EventSystem.current.SetSelectedGameObject(btns[manager.getTaskCounter()]);

}

public void refreshTaskScreen()
{
    string instructionString = manager.getReader().getInstruction(manager.getTaskCounter());
    displayInstructionPanel(instructionString, manager.getPageCounter(), manager.getTaskCounter());
    displayTaskPanel(manager.getTaskCounter());
    updateImage(manager.getTaskList(),manager.getTaskCounter(),manager.getPageCounter());
}

//Updates the impage based on the instruction

public void updateImage(List<List<string>> tasks, int taskCounter, int pageCounter)
{
    //Only need to pull the first index of the instImage for the page
    /*
    List<int> list = manager.getReader().getInstructionIndex(pageCounter,taskCounter);
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
    */
}

public void changePage()
{
    string instructionString = manager.getReader().getInstruction(manager.getTaskCounter());
    displayInstructionPanel(instructionString, manager.getPageCounter(), manager.getTaskCounter());
    updateImage(manager.getTaskList(),manager.getTaskCounter(),manager.getPageCounter());
}

}
