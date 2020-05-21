using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    private List<List<string>> groupList;
    private List<string> taskListPage;
    private List<string> taskListInstruction;
    private List<string> taskListImage;
    private List<List<List<string>>> tasks;
    private int maxPages, instructLength;

    /*
  * groupList[task index] [list index] [element in the list];
  * Example: groupList [page one] [instruction list] [instruction one]
  * Example: groupList [page one] [image list] [image one]
  */

    void Start()
    {
        tasks = new List<List<List<string>>>();
        importTaskList();
    }
    
    private void importTaskList()
    {
        TextAsset questdata = Resources.Load<TextAsset>("task1");
        taskListPage = new List<string>();
        taskListInstruction = new List<string>();
        taskListImage = new List<string>();
        groupList = new List<List<string>>();

        string[] data = questdata.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });

            if (row[1] != "")
            {
                TaskValuePair q = new TaskValuePair();
                q.pages = row[0];
                q.instructions = row[1];
                q.images = row[2];
                taskListPage.Add(q.pages);
                taskListInstruction.Add(q.instructions);
                taskListImage.Add(q.images);
            }
        }
        groupList.Add(taskListPage);
        groupList.Add(taskListInstruction);
        groupList.Add(taskListImage);
        tasks.Add(groupList);
    }

    //Returns the max number of pages
    public int getMaxPages()
    {
        int length = groupList[0].Count;
        string maxInt = tasks[0][0][length-1];
        maxPages = Int32.Parse(maxInt);
        return maxPages;
    }

    //Returns the instruction index's per the page
    public List<int> getInstructionIndex(int pageNumber)
    {
        string pageNum = Convert.ToString(pageNumber);
        List<int> indexList = new List<int>();
        
        for(int i = 0; i<groupList[1].Count; i++)
        {
            if (string.Equals(groupList[0][i],pageNum))
            {
                indexList.Add(i);
            }
        }
        return indexList;
    }

    //Returns the entire list
    public List<List<List<string>>> getTask()
    {
        return tasks;
    }
}
