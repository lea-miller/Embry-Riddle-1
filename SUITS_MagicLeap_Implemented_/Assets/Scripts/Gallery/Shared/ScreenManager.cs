using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenManager : MonoBehaviour
{

    //public TaskView _taskView;
    // private InstructView _instrView;
    public bool isOnTask, isSelectedNext;
    public int pageCounter, maxPages, taskCounter, maxTasks;
    public List<int> taskTracker;
    public List<List<string>> tasks;
    public CSVReader _reader;
    
    public TextMeshProUGUI textInstruction, textPage, textTitle, textDuration, textNextTitle, textNextDuration;

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
        //_pageSync.SetPage(pageCounter);
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
