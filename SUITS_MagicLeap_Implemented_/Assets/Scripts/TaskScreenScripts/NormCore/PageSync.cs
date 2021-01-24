using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PageSync : RealtimeComponent<TaskModel>
{
    private MeshRenderer _meshRenderer;
    private TaskScreenManager _taskScreen;

    private void Awake()
    {
        // Get a reference to the mesh renderer
        _taskScreen = GetComponent<TaskScreenManager>();
        Debug.Log("Got Task manager");
    }

    protected override void OnRealtimeModelReplaced(TaskModel previousModel,TaskModel currentModel)
    {
        Debug.Log("RealtimeReplaced");
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
                currentModel.taskPage = _taskScreen.taskCounter;
                Debug.Log("Model set to page:" + _taskScreen.pageCounter);
            }

            // Update the mesh render to match the new model
            UpdateMeshRendererColor();

            // Register for events so we'll know if the color changes later
            currentModel.taskPageDidChange += PageDidChange;
        }
    }

    private void PageDidChange(TaskModel model, int value)
    {
        // Update the mesh renderer
        UpdateMeshRendererColor();
    }

    private void UpdateMeshRendererColor()
    {
        // Get the color from the model and set it on the mesh renderer.
        _taskScreen.pageCounter = model.taskPage;
        //_taskScreen.getDisplay().refreshTaskScreen();
        Debug.Log("ScreenRefresh");
    }

    public void SetPage(int page)
    {
        // Set the color on the model
        // This will fire the colorChanged event on the model, which will update the renderer for both the local player and all remote players.
        model.taskPage = page;
        
    }
}
