using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;

public class PageSync : RealtimeComponent<TaskModel>
{
    private MeshRenderer _meshRenderer;
    private TaskScreenManager _taskScreenManager;

    private void Awake()
    {
        // Get a reference to the manager
        _taskScreenManager = GetComponent<TaskScreenManager>();
        //Debug.Log("Got Task manager");
    }

    protected override void OnRealtimeModelReplaced(TaskModel previousModel,TaskModel currentModel)
    {
        //Debug.Log("RealtimeReplaced");
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.taskPageDidChange -= PageDidChange;
        }
        
        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current mesh renderer color.
            if (currentModel.isFreshModel)
            {
                currentModel.taskPage = _taskScreenManager.taskCounter;
                //Debug.Log("Model set to page:" + _taskScreenManager.pageCounter);
            }

            // Update the mesh render to match the new model
            UpdatePageCount();

            // Register for events so we'll know if the color changes later
            currentModel.taskPageDidChange += PageDidChange;
        }
    }

    private void PageDidChange(TaskModel model, int value)
    {
        // Update the mesh renderer
        UpdatePageCount();
    }

    private void UpdatePageCount()
    {
        // Get the page from the model and set it on the manager.
        try
        {
            _taskScreenManager.pageCounter = model.taskPage;
            _taskScreenManager.getDisplay().refreshTaskScreen();  //auto refreshes the task screen
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
        //Debug.Log("ScreenRefresh");
    }

    public void SetPage(int page)
    {
        // Set the color on the model
        // This will fire the colorChanged event on the model, which will update the renderer for both the local player and all remote players.
        model.taskPage = page;
        
    }
}
