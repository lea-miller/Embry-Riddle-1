using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;
    private List<List<string>> resources;
    private List<string> taskList;
    private TaskValues tasksInJson;


    void Awake()
    {
        tasksInJson = JsonUtility.FromJson<TaskValues>(jsonFile.text);
        initalize();
    }

    private void initalize()
    {
        resources = new List<List<string>>();
        taskList = new List<string>();
    }

    private void Start()
    {
        foreach (TaskValue taskValue in tasksInJson.taskNames)
        {
            taskList.Add(taskValue.task);
        }
        resources.Add(taskList);
    }

    public List<List<string>> getResources()
    {
        return resources;
    }
}

