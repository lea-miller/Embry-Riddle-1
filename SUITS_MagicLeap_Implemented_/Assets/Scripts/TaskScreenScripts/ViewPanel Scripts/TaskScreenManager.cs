﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskScreenManager : MonoBehaviour
{
    private TaskView _taskView;
   // private InstructView _instrView;
    private TaskScreenDisplay _taskDisplay;
    private bool isOnTask, isSelectedNext;
    public int pageCounter, maxPages, taskCounter, maxTasks;
    
    private List<int> taskTracker;

    private List<List<string>> tasks;
    private CSVReader _reader;

    private PageSync _pageSync;

    private bool upCalled = false;

    void Awake()
   {
        _reader = GetComponent<CSVReader>();
        _taskView = new TaskView(this);
       // _instrView = new InstructView(this);
        isOnTask = true;
        taskTracker = new List<int>();
        isOnTask = false;
        taskCounter = 0;
        pageCounter = 1;
        taskTracker.Add(taskCounter);
        _pageSync = GetComponent<PageSync>();

    }

   void Start()
   {
        tasks = _reader.getTask();
        taskTracker.Add(taskCounter);
        _taskDisplay = new TaskScreenDisplay(this);
        setMaxTasks();
    }

    void Update()
    {
        _taskDisplay.refreshTaskScreen();
        if (!upCalled)
        {
            _taskDisplay.refreshTaskScreen();
            upCalled = true;
            //Debug.Log("Update single run");
        }
    
    
    }

    public bool getIsOnTask()
    {
        return isOnTask;
    }

      public int getPageCounter()
    {
        return pageCounter;
    }

    public int getMaxPages()
    {
        return maxPages;
    }

    public int getMaxTasks()
    {
        return maxTasks;
    }

    public int getTaskCounter()
    {
        return taskCounter;
    }

    public void setIsOnTask(bool isOnTask)
    {
        this.isOnTask = isOnTask;
    }

    public void setPageCounter(int pageCounter)
    {
        this.pageCounter = pageCounter;
        _pageSync.SetPage(pageCounter);
        //Debug.Log("SetPage");
    }

    public void setMaxPages(int maxPages)
    {
        this.maxPages = maxPages;
    }

    public void setMaxTasks()
    {
        maxTasks = tasks.Count - 1;
    }

    public void setTaskCounter(int taskCounter)
    {
        this.taskCounter = taskCounter;
        //Debug.Log("Task set to: " + taskCounter);
    }
    
    public void setSelectedTask(bool isSelectedNext)
    {
        this.isSelectedNext = isSelectedNext;
    }

    public bool getSelectedTask()
    {
        return isSelectedNext;
    }
    
    public List<string> getCurrentTask()
    {
        return tasks[taskCounter];
    }
    
    
    /*public InstructView getInstruct()
    {
        return _instrView;
    }*/
    

    public CSVReader getReader()
    {
        return _reader;
    }

    public TaskScreenDisplay getDisplay()
    {
        return _taskDisplay;
    }

    public List<List<string>> getTaskList()
    {
        return _reader.getTask();
    }

    public void setTaskList(List<List<string>> tasks)
    {
        this.tasks = tasks;
    } 

    public List<int> getTaskTracker()
    {
        return taskTracker;
    }

    public void setTaskTracker(List<int> taskTracker)
    {
        this.taskTracker = taskTracker;
    }
}
