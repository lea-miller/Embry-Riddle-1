using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;
    private List<List<string>> groupList;
    private List<string> taskListInstruction;
    private List<string> taskListImage;
    private List<List<List<string>>> tasks;
    private TaskValues tasksInJson;
    
    void Awake()
    {
        tasksInJson = JsonUtility.FromJson<TaskValues>(jsonFile.text);
        tasks = new List<List<List<string>>>();
        initalize();
    }

    private void initalize()
    {
        groupList = new List<List<string>>();
        taskListImage = new List<string>();
        taskListInstruction = new List<string>();
    }

    private void Start()
    {
        /*
         * groupList[task index] [list index] [element in the list];
         * Example: groupList [task one] [instruction list] [instruction one]
         * Example: groupList [task one] [image list] [image one]
         */

        foreach (TaskValue taskValue in tasksInJson.task1)
        {
            addJasonTolist(taskValue);
        }
        addToList();

        foreach (TaskValue taskValue in tasksInJson.task2)
        {
            addJasonTolist(taskValue);
        }
        addToList();
    }

    //Takes the imported data and adds it to a list
    private void addJasonTolist(TaskValue taskValue)
    {
        taskListInstruction.Add(taskValue.instruction);
        taskListImage.Add(taskValue.image);
    }

    //Adds the data to the list to then be able to use for later use
    private void addToList()
    {
        groupList.Add(taskListInstruction);
        groupList.Add(taskListImage);
        tasks.Add(groupList);
        initalize();
    }

    public List<List<List<string>>> getTask()
    {
        return tasks;
    }
}

