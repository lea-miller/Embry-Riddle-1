﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SciGalleryScreenManager : ScreenManager
{
    SciGalleryScreenDisplay _taskDisplay;
    private bool upCalled = false;

      void Awake()
   {
       //Task Counter ,Page Counter
        _reader = GetComponent<CSVReader>();
        //_taskView = new TaskView(this);
        isOnTask = true;
        taskTracker = new List<int>();
        isOnTask = false;
        taskTracker.Add(taskCounter);
   }

    // Start is called before the first frame update
    void Start()
    {
        tasks = _reader.getTask();
        taskTracker.Add(taskCounter);
        _taskDisplay = new SciGalleryScreenDisplay(this);
        setMaxTasks();
    }

       public SciGalleryScreenDisplay getDisplay()
    {
        return _taskDisplay;
    }

        void Update()
    {
        _taskDisplay.refreshTaskScreen();
        if (!upCalled)
        {
            _taskDisplay.refreshTaskScreen();
            upCalled = true;
        }
    }

    
}
