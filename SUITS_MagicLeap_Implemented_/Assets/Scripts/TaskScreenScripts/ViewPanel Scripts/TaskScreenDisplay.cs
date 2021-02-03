using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TaskScreenDisplay
{
    private CreateTaskBtn _createBtns;
    public TextMeshProUGUI textInstruction, textPage, textTaskLength, textTitle, textDuration, textNextTitle, textNextDuration;
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
        textTitle = GameObject.FindGameObjectWithTag("TaskTitleText").GetComponent<TextMeshProUGUI>();
        textDuration = GameObject.FindGameObjectWithTag("TaskDurationText").GetComponent<TextMeshProUGUI>();
        textNextTitle = GameObject.FindGameObjectWithTag("NextTaskTitleText").GetComponent<TextMeshProUGUI>();
        textNextDuration = GameObject.FindGameObjectWithTag("NextTaskDurationText").GetComponent<TextMeshProUGUI>();
        //textTaskLength = GameObject.FindGameObjectWithTag("TaskCounter").GetComponent<TextMeshProUGUI>();
        mat = Resources.Load<Material>("Materials/Transparent");
        //instImage = GameObject.FindGameObjectWithTag("Task Image").GetComponent<Image>();

        //displayTaskNames();
        string instructionString = manager.getReader().getInstruction(0);
        manager.setPageCounter(textInstruction.pageToDisplay);
        displayInstructionPanel(instructionString,1,0);
        
        //manager.setMaxPages(3);
        displayTaskPanel(0);
        highlightSelected();
        //refreshTaskScreen();
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
        //textTaskLength.text = "T. " +  (( taskCounter <= manager.getReader().getTaskLength()-1) ? taskCounter + 1 : taskCounter) + "/" + manager.getReader().getTaskLength();
    }

    //Displays the instruction information to the GUI
    private void displayInstructionPanel(string joinString,int pageCounter, int taskCounter)
    {
        //The task counter text starts at 1, not 0 like the data
        textInstruction.text = joinString;
        textInstruction.pageToDisplay = pageCounter;
        manager.setMaxPages(textInstruction.textInfo.pageCount);
        textPage.text = "P. " + textInstruction.pageToDisplay + "/" + textInstruction.textInfo.pageCount;
    }

    //Displays the page information to the GUI
    private void displayTitlePanel()
    {

        int counter = manager.getTaskCounter();
        List<List<string>> list = manager.getTaskList();    
        textTitle.text = "Next: " + list[counter][0] ;
        string dur = list[counter][2];
        dur = dur.Remove(dur.Length-1);
        string start = list[counter][3] ;
        start = start.Remove(start.Length-1);
        string end = list[counter][4];
        end = end.Remove(end.Length-1);
        string durText = "Duration: " + dur + "                    " + "Start:" + start + " End: " + end;
        textDuration.text = durText;
    }

    private void displayNextTitlePanel()
    {
        int counter = manager.getTaskCounter();
        List < List<string>> list = manager.getTaskList();
        //if (counter < list.Count)
        //{        
            textNextTitle.text = "Next: " + list[counter+1][0] + "TEST STRING";
            string dur = list[counter + 1][2];
            dur = dur.Remove(dur.Length-1);
            string start = list[counter + 1][3];
            start = start.Remove(start.Length-1);
            string end = list[counter + 1][4];
            end = end.Remove(end.Length-1);
            string durText = "Duration: " + dur  + "                    " + "Start:"  + start  + " End: "  + end;
            textNextDuration.text = durText;  
            
        //}
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
    //EventSystem.current.SetSelectedGameObject(btns[manager.getTaskCounter()]);

}

public void refreshTaskScreen()
{
    
    string instructionString = manager.getReader().getInstruction(manager.getTaskCounter());
    displayInstructionPanel(instructionString, manager.getPageCounter(), manager.getTaskCounter());
    displayTaskPanel(manager.getTaskCounter());
    displayTitlePanel();
    displayNextTitlePanel();
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

public void changePage(int page = 0)
{
    if(page != 0)
        {
            manager.setPageCounter(manager.getPageCounter() + page);
        }
/*    string instructionString = manager.getReader().getInstruction(manager.getTaskCounter());
    displayInstructionPanel(instructionString, manager.getPageCounter(), manager.getTaskCounter());
    updateImage(manager.getTaskList(),manager.getTaskCounter(),manager.getPageCounter());*/



}

}
