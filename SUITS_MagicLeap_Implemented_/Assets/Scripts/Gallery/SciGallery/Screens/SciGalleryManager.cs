using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SciGalleryManager : GalleryManager
{
    //private TaskGalleryScreenManager galleryScreenManager;
    private SciFolderSystem sciFolder;
    public TextMeshProUGUI pageText;
    public TextMeshProUGUI directory;
    
    void Awake()
    {
        sciFolder = GameObject.FindGameObjectWithTag("ScienceScreen").GetComponent<SciFolderSystem>();
    }

    void Start()
    {
        limit = galleryListDisplay.Count;
        display();
        directory.text = ("Current Directory: " + "Assets/Resources/SciGallery");
    }

    //Happening in ControlSciGallery
    public void goGetDirectoryTriggered(int positionNumber)
    {
        sciFolder.triggerHeld((pageCounter*limit)+positionNumber);
        pageCounter = 0;
        display();
    }

    //Happening in ControlSciGallery
    public void goGetDirectoryBumper()
    {
        sciFolder.bumperHeld();
        pageCounter = 0;
        display();
    }


    //Happening in ControlSciGalleryPages
    public void triggerNextPage()
    {
        double value = sciFolder.getLength()/limit;
        if(pageCounter+1 < Math.Ceiling(value+1))
        {
            pageCounter = pageCounter + 1;
            sciFolder.updateSciGalleryFolder();
            display();
        }
    }
    
    //Happening in ControlSciGalleryPages
    public void bumperBackPage()
    {
        if(pageCounter !=0)
        {
            pageCounter = pageCounter - 1;
            sciFolder.updateSciGalleryFolder();
            display();
        }
    }

    public void display()
    {
        double value = sciFolder.getLength()/limit;
        pageText.text = ("Page " + (pageCounter+1) + "/" + Math.Ceiling(value+1));
        directory.text = ("Current Directory: " + sciFolder.getDirectory());
    }
}
