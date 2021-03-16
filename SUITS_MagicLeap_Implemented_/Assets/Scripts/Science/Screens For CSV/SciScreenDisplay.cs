using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SciScreenDisplay : ScreenDisplay
{
    
    SciScreenManager manager;


   public SciScreenDisplay(SciScreenManager manager)
   {
        this.manager = manager;
        list = manager.getTaskList();
        textInstruction = manager.textInstruction;
        textPage = manager.textPage;
        textTitle = manager.textTitle;
        textDuration = manager.textDuration;
        textNextTitle = manager.textNextTitle;
        textNextDuration = manager.textNextDuration;
        timer = manager.timer;
        mat = Resources.Load<Material>("Materials/Transparent");
        string instructionString = manager.getReader().getInstruction(0);
        // manager.setPageCounter(textInstruction.pageToDisplay);
        // displayInstructionPanel(instructionString,1,0);
        // highlightSelected();
   }


    //Displays the instruction information to the GUI
    private void displayInstructionPanel(string joinString,int pageCounter, int taskCounter)
    {
        //TextMeshProUGUI forceFindTextInstruction = GameObject.FindGameObjectWithTag("TaskInstructionText").GetComponent<TextMeshProUGUI>();
        
        //The task counter text starts at 1, not 0 like the data
        
        //forceFindTextInstruction.text = getInstruction();
        //forceFindTextInstruction.pageToDisplay = pageCounter;
        // manager.setMaxPages(forceFindTextInstruction.textInfo.pageCount);
        // textPage.text = "P. " + forceFindTextInstruction.pageToDisplay + "/" + forceFindTextInstruction.textInfo.pageCount;
    }

    //Displays the page information to the GUI
    private void displayTitlePanel()
    {

        // int counter = manager.getTaskCounter();  
        // textTitle.text = list[counter][0] ;
        // string dur = list[counter][2];
        // string start = list[counter][3] ;
        // string end = list[counter][4];
        // string durText = "Duration: " + dur + "                    " + "Start:" + start + "   End: " + end;
        // textDuration.text = durText;
    }

    private void displayNextTitlePanel()
    {
        // int counter = manager.getTaskCounter();
        
        // if (counter + 1  <= manager.getMaxTasks())
        // {        
        //     textNextTitle.text = "Next: " + list[counter+1][0];
        //     string dur = list[counter + 1][2];
        //     string start = list[counter + 1][3];
        //     string end = list[counter + 1][4];
        //     string durText = "Duration: " + dur  + "                    " + "Start:"  + start  + "   End: "  + end;
        //     textNextDuration.text = durText;  
            
        // }

        // else
        // {
        //     textNextTitle.text = "";
        //     textNextDuration.text = "";
        // }
    }

    private void navShortcutDisplay()
    {
        // int counter = manager.getTaskCounter();
        // if (list[counter][1] == "Navigation")
        // {
        //     manager.navShortcut.SetActive(true);
        //     string headerText = "Navigate to:" + "\n";
        //     string footerText;
        //     Marker marker;

        //     if (list[counter][5] == "$")
        //     {
        //         marker = manager.MarkerManager.landerMarker;
        //         manager.navToMarker = marker;
                
        //     }
        //     else
        //     {
        //         // Finds the marker in Marker list that matches the Specified letter in the Tasks Excel
        //         marker = manager.MarkerManager.markerList.Find(x => x.LetterName.Contains(list[counter][5]));
        //         manager.navToMarker = marker;
        //     }
 
        //     footerText = marker.LetterName + ": " + marker.FullName;

           
        // }
        // else
        // {
   
        // }
    }



    public void changeTask(int task = 0)  //Input 1 to move forward or -1 to move backward
    {
        if (task != 0)
        {
            manager.setTaskCounter(manager.getTaskCounter() + task);
            manager.setPageCounter(1);
            //GameObject.FindGameObjectWithTag("ElapsedDuration").GetComponent<TaskTimer>().resetTimer();
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
        navShortcutDisplay();
    }

    //Updates the impage based on the instruction

    public void changePage(int page = 0)
    {
        if(page != 0)
            {
                manager.setPageCounter(manager.getPageCounter() + page);
            }
    }


    public string getInstruction()
    {
        //List<int> list = getInstructionIndex(pageCounter,taskNumber);
        int startIndex = 5;
        int endIndex = list[manager.taskCounter].Count - 1;
        string joinString = "";

        //displays the instruction per the indexs related to that page
        for (int j = endIndex; j >= startIndex; j--)
        {
            string tempInstruct = list[manager.taskCounter][j];
            if (tempInstruct != "")
            {
                if (tempInstruct.Contains("~"))
                {
                    string pictureName = tempInstruct.Replace("~", "");
                    joinString = "<size=1200%><sprite=" + pictureName + "> <size=100%>" + "\n" + joinString;
                    //joinString = "<indent=8%>" + "<size=1400%><sprite=\"Combo\" " + "index=" + pictureName + "> <size=100%> </indent>" + "\n" + joinString;

                }
                else
                {
                    joinString = j - 4 + "." + "<indent=8%>" + tempInstruct + "</indent>" + "\n" + joinString;
                }

            }
        }
        return joinString;
    }

}
