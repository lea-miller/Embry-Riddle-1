using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class CSVReader : MonoBehaviour
{
  
    private List<List<string>> tasks;
   
    private TextAsset fileData;
  

    /*
  * groupList[task index] [list index] [element in the list];
  * Example: groupList [page one] [instruction list] [instruction one]
  * Example: groupList [page one] [image list] [image one]
  */

    void Awake()
    {
        tasks = new List<List<string>>();
    
       
        loadTasks();
        importTaskList();
    }

  

    public void loadTasks()
    {
        fileData = Resources.Load<TextAsset>("Tasks/MissionTasks");
    }

    public void importTaskList()
    {
        
        string[] data = fileData.text.Split(new char[] { '\n' });
        

        for (int i = 0; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            //Debug.Log("row 1 L = " + row.Length);
            //Debug.Log("row 1 = " + row[0] );

            for (int j = 1; j < row.Length - 1; j++)
            {
                //tasks[j-1][i] = row[j];   
                Debug.Log(row[j]);
                tasks[j].Add(row[j]);
                Debug.Log(tasks[0][0]);
            }
        }
        

    }

    public int getTaskLength()
    {
        return tasks[0].Count;
    }




    //Builds the string for the TextMeshPro

    public string getInstruction(int taskNumber)
    {
        //List<int> list = getInstructionIndex(pageCounter,taskNumber);
        int startIndex = 6;
        int endIndex = tasks[taskNumber].Count;
         string joinString = "";

        //displays the instruction per the indexs related to that page
        for (int j = endIndex; j >= startIndex; j--)
         {
             string tempInstruct = tasks[taskNumber][j];
             joinString = tempInstruct + "\n" + "\n" + joinString;
         }
         return joinString;
     }
    


    //Returns the entire list
    public List<List<string>> getTask()
 {
     return tasks;
 }


}
