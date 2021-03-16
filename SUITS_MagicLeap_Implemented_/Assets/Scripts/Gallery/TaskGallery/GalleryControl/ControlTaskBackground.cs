using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlTaskBackground : ControlCommands
{
    private TaskGalleryManager manager;
    private Image border;
    
    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("TaskGallery").GetComponent<TaskGalleryManager>();
        border = GetComponent<Image>();
    }
    
    public override void triggerUp() {}

    public override void bumperUp()
    {
        if(border.enabled)
        {
            manager.goGetDirectoryBumper();
        }
    }

    public override void triggerHold(){}
    public override void bumperHold(){}
}
