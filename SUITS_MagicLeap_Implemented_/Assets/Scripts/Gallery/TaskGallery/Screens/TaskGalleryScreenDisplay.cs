using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class TaskGalleryScreenDisplay : ScreenDisplay
{

    TaskGalleryScreenManager manager;

    public  TaskGalleryScreenDisplay(TaskGalleryScreenManager manager)
   {
        this.manager = manager;
        list = manager.getTaskList();
        textInstruction = manager.textInstruction;
        textPage = manager.textPage;
        textTitle = manager.textTitle;
        textDuration = manager.textDuration;
        textNextTitle = manager.textNextTitle;
        textNextDuration = manager.textNextDuration;
        //timer = manager.timer;
        mat = Resources.Load<Material>("Materials/Transparent");
        setDeafault();
   }


   public void setDeafault()
   {
        string instructionString = manager.getReader().getInstruction(0);
        manager.setPageCounter(textInstruction.pageToDisplay);
        displayInstructionPanel(instructionString,1,0);
        highlightSelected();
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
        textTitle.text = list[counter][0] ;
        string dur = list[counter][2];
        string start = list[counter][3] ;
        string end = list[counter][4];
        string durText = "Duration: " + dur;
        textDuration.text = durText;
    }

    private void displayNextTitlePanel()
    {
        int counter = manager.getTaskCounter();
        
        if (counter + 1  <= manager.getMaxTasks())
        {        
            textNextTitle.text = "Next: " + list[counter+1][0];
            string dur = list[counter + 1][2];
            string start = list[counter + 1][3];
            string end = list[counter + 1][4];
            string durText = "Duration: " + dur  + "                    " + "Start:"  + start  + "   End: "  + end;
           // textNextDuration.text = durText;  
            
        }

        else
        {
            textNextTitle.text = "";
            textNextDuration.text = "";
        }
    }

    public void changeTask(int task = 0)
    {
        if (task != 0)
        {
            manager.setTaskCounter(manager.getTaskCounter() + task);
            manager.setPageCounter(1);
            //timer.resetTimer();
        }
    
    }


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
    displayTitlePanel();
    displayNextTitlePanel();
}


public void changePage(int page = 0)
{
    if(page != 0)
        {
            manager.setPageCounter(manager.getPageCounter() + page);
        }
}

}
