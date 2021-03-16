using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSciGallery : ControlCommands
{
    private SciGalleryManager manager;
    private Image border;

    public int positionNumber; //Must be defined in the inspector, it is the postion on in the hiearchy
    
    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("SciGallery").GetComponent<SciGalleryManager>();
        border = GetComponent<Image>();
    }
    
    public override void triggerUp() //Selected the item!
    {
        if(border.enabled)
        {
            manager.goGetDirectoryTriggered(positionNumber);
        }
        
    }

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
