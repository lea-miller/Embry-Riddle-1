using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSciGalleryPages : ControlCommands
{
    protected Image border;
    private SciGalleryManager manager;

    void Awake()
    {
         manager = GameObject.FindGameObjectWithTag("SciGallery").GetComponent<SciGalleryManager>();
         border = GetComponent<Image>();
    }

   public override void triggerUp()
    {
        //Task is open
        if (border.enabled)
        {
            manager.triggerNextPage();
        }
    }

    public override void bumperUp()
    {
        //Task is open
        if (border.enabled)
        {
            manager.bumperBackPage();
        }
    }
    
    //Must happen in the child class!
    public override void triggerHold(){}
    public override void bumperHold(){}
}
