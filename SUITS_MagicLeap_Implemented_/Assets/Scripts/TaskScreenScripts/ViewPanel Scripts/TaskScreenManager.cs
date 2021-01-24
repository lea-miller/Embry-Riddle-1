using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskScreenManager : MonoBehaviour
{
    private TaskView _taskView;
    private InstructView _instrView;
    private TaskScreenDisplay _taskDisplay;
    private CSVReader _reader;
    private bool isOnTask, isSelectedNext;
    public int pageCounter, taskCounter;
    private List<List<List<string>>> tasks;
    private List<int> taskTracker;
    
   void Awake()
   {
        _reader = GetComponent<CSVReader>();
        _taskView = new TaskView(this);
        _instrView = new InstructView(this);
        isOnTask = true;
        taskTracker = new List<int>();
        isOnTask = false;
        taskCounter = 0;
        pageCounter = 1;
        taskTracker.Add(taskCounter);
   }

   void Start()
   {
        tasks = _reader.getTask();
        taskTracker.Add(taskCounter);
        _taskDisplay = new TaskScreenDisplay(this);
        _taskDisplay.updateImage(tasks,taskCounter,pageCounter);
   }

    public bool getIsOnTask()
    {
        return isOnTask;
    }

      public int getPageCounter()
    {
        return pageCounter;
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
    }

    public void setTaskCounter(int taskCounter)
    {
        this.taskCounter = taskCounter;
    }
    
    public void setSelectedTask(bool isSelectedNext)
    {
        this.isSelectedNext = isSelectedNext;
    }

    public bool getSelectedTask()
    {
        return isSelectedNext;
    }
    
    public TaskView getTask()
    {
        return _taskView;
    }
    
    public InstructView getInstruct()
    {
        return _instrView;
    }

    public CSVReader getReader()
    {
        return _reader;
    }

    public TaskScreenDisplay getDisplay()
    {
        return _taskDisplay;
    }

    public List<List<List<string>>> getTaskList()
    {
        return _reader.getTask();
    }

    public void setTaskList(List<List<List<string>>> tasks)
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
