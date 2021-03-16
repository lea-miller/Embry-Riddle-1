using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TaskGalleryManager : GalleryManager
{

    private TaskGalleryManager galleryManager;
    private TaskFolderSystem taskFolder;
    public TextMeshProUGUI pageText;
    public TextMeshProUGUI directory;

    void Awake()
    {
        galleryManager = GameObject.FindGameObjectWithTag("TaskGallery").GetComponent<TaskGalleryManager>();
        taskFolder = GameObject.FindGameObjectWithTag("TaskScreen").GetComponent<TaskFolderSystem>();
    }

    void Start()
    {
        limit = galleryListDisplay.Count;
        display();
        directory.text = ("Current Directory: " + "Assets/Resources/TaskGallery");
    }

    //Happening in ControlTaskGallery
    public void goGetDirectoryTriggered(int positionNumber)
    {
        taskFolder.triggerHeld((pageCounter*limit)+positionNumber);
        pageCounter = 0;
        display();
    }

    //Happening in ControlTaskGallery
    public void goGetDirectoryBumper()
    {
        pageCounter = 0;
        taskFolder.bumperHeld();
        display();
    }


    //Happening in ControlTaskGalleryPages
    public void triggerNextPage()
    {
        double value;
        if(taskFolder.getIsFile())
        {
            value = galleryList.Count/limit;
        }
        else
        {
            value = taskFolder.getLength()/limit;
        }
        
        if(pageCounter+1 < Math.Ceiling(value+1))
        {
            if(taskFolder.getIsFile())
            {
                pageCounter = pageCounter + 1;
                updateGallery(galleryList);
            }
            else
            {
                pageCounter = pageCounter + 1;
                taskFolder.updateTaskGalleryFolder();
                display();
            }
        }
    }
    
    //Happening in ControlTaskGalleryPages
    public void bumperBackPage()
    {
        if(pageCounter !=0)
        {
            if(taskFolder.getIsFile())
            {
                pageCounter = pageCounter - 1;
                updateGallery(galleryList);
            }
            else
            {
                pageCounter = pageCounter - 1;
                taskFolder.updateTaskGalleryFolder();
                display();
            }
         
        }
    }

    public void display()
    {
        double value;
        if(taskFolder.getIsFile())
        {
            value = galleryList.Count/limit;
        }
        else
        {
            value = taskFolder.getLength()/limit;
        }
        pageText.text = ("Page " + (pageCounter+1) + "/" + Math.Ceiling(value+1));
        directory.text = ("Directory: " + taskFolder.getDirectory());
    }
}
