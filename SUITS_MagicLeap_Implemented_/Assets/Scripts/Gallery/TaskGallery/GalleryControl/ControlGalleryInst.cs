using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlGalleryInst : ControlCommands
{
    private GameObject galleryList;
    private GameObject galleryScreen;
    private GameObject galleryBtn;
    private TaskGalleryScreenManager galleryScreenManager;
    private Image border;
    void Awake()
    {
        galleryList = GameObject.FindGameObjectWithTag("TaskGallery");
        galleryScreen = GameObject.FindGameObjectWithTag("TaskGalleryInstruction");
        galleryBtn = GameObject.FindGameObjectWithTag("TaskGalleryBtn");
        galleryScreenManager = GameObject.FindGameObjectWithTag("TaskGalleryInstruction").GetComponent<TaskGalleryScreenManager>();
        border = galleryScreen.GetComponent<Image>();
    }

    public override void bumperHold(){}
    public override void bumperUp()
    {
         if (border.enabled)
        {
            if (galleryScreenManager.getPageCounter() > 1)
            {
                galleryScreenManager.getDisplay().changePage(-1);
            }
        }
    }
    public override void triggerHold(){}
    public override void triggerUp()
    {
           if(border.enabled)
           {
                if (galleryScreenManager.getPageCounter() < galleryScreenManager.getMaxPages()) 
                {
                    galleryScreenManager.getDisplay().changePage(1);
                }
           } 
    }
}
