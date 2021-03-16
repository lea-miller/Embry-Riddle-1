using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;

public class MarkerSync : RealtimeComponent<TaskModel>
{
    private MeshRenderer _meshRenderer;
    private Vector3 prevPos; 

    private void Awake()
    {
        prevPos = transform.position;
    }

    protected override void OnRealtimeModelReplaced(TaskModel previousModel, TaskModel currentModel)
    {
        //Debug.Log("RealtimeReplaced");
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.markerPosDidChange -= ParamDidChange;
        }

        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current mesh renderer color.
            if (currentModel.isFreshModel)
            {
                currentModel.markerPos = transform.position;
                Debug.Log(transform.position);

            }

            // Update the mesh render to match the new model
            UpdateParam();

            // Register for events so we'll know if the color changes later
            currentModel.markerPosDidChange += ParamDidChange;
        }
    }

    private void ParamDidChange(TaskModel model, Vector3 value)
    {
        // Update the mesh renderer
        Debug.Log("Normcore Update to Marker Detected");
        UpdateParam();
   
    }

    private void UpdateParam()
    {
        transform.position = model.markerPos;

    }

    public void SetParameter(Vector3 pos)
    {
        // Set the color on the model
        // This will fire the colorChanged event on the model, which will update the renderer for both the local player and all remote players.
        model.markerPos = pos;

    }

    private void FixedUpdate()
    {
        if (prevPos != transform.position)
        {
            SetParameter(transform.position);
            prevPos = transform.position;
        }
    }
}
