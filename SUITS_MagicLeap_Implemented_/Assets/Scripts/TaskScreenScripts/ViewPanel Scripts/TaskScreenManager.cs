using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskScreenManager : ScreenManager 
{
    public TaskScreenDisplay _taskDisplay;
    private bool upCalled = false;
    public TaskTimer timer;
    public GameObject navShortcut;
    public Marker navToMarker;
    public MarkerManager MarkerManager;
    void Awake()
   {
       //Task Counter ,Page Counter
        _reader = GetComponent<CSVReader>();
        //_taskView = new TaskView(this);
        isOnTask = true;
        taskTracker = new List<int>();
        isOnTask = false;
        taskCounter = 0;
        pageCounter = 1;
        taskTracker.Add(taskCounter);

        textInstruction = GameObject.FindGameObjectWithTag("TaskInstructionText").GetComponent<TextMeshProUGUI>();
        timer = GameObject.FindGameObjectWithTag("ElapsedDuration").GetComponent<TaskTimer>();
        navShortcut = GameObject.FindGameObjectWithTag("NavShortcut");
        MarkerManager = GameObject.FindGameObjectWithTag("MiniMapSys").GetComponent<MarkerManager>();
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

       public TaskScreenDisplay getDisplay()
    {
        return _taskDisplay;
    }
}
