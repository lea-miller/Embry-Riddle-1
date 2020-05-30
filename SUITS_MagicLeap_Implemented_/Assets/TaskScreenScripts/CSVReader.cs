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
    private List<List<string>> jsonList;
    private int maxPages, instructLength;
    private TextAsset fileData;
    public TextAsset jsonFile;
    private List<string> jsonNameList;
    private TaskValues tasksInJson;

    /*
  * groupList[task index] [list index] [element in the list];
  * Example: groupList [page one] [instruction list] [instruction one]
  * Example: groupList [page one] [image list] [image one]
  */

    void Awake()
    {
        tasks = new List<List<List<string>>>();
        jsonList = new List<List<string>>();
        jsonNameList = jsonNameList = new List<string>();
        tasksInJson = JsonUtility.FromJson<TaskValues>(jsonFile.text);
        loadJson();
        loadTaskName(0);
        importTaskList();
    }

    private void loadJson()
    {
        foreach (TaskValue taskValue in tasksInJson.taskNames)
        {
            jsonNameList.Add(taskValue.task);
        }
        jsonList.Add(jsonNameList);
    }

    public void loadTaskName(int taskNumber)
    {
        fileData = Resources.Load<TextAsset>("Tasks/"+jsonList[0][taskNumber]);
    }

    public void importTaskList()
    {
        taskListPage = new List<string>();
        taskListInstruction = new List<string>();
        taskListImage = new List<string>();
        groupList = new List<List<string>>();

        string[] data = fileData.text.Split(new char[] { '\n' });

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
    public int getMaxPages(int taskNumber)
    { 
        int length = tasks[taskNumber][0].Count;
        string maxInt = tasks[taskNumber][0][length-1];
        maxPages = Int32.Parse(maxInt);
        return maxPages;
    }

    //Returns the instruction index's per the page
    public List<int> getInstructionIndex(int pageNumber, int taskNumber)
    {
        string pageNum = Convert.ToString(pageNumber);
        List<int> indexList = new List<int>();
        
        for(int i = 0; i<tasks[taskNumber][1].Count; i++)
        {
            if (string.Equals(tasks[taskNumber][0][i],pageNum))
            {
                indexList.Add(i);
            }
        }
        return indexList;
    }

    //Returns the list length
    public int getTaskLength()
    {
        return jsonList[0].Count;
    }


    //Returns the entire list
    public List<List<List<string>>> getTask()
    {
        return tasks;
    }
}
