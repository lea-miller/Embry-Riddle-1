using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SciFolderSystem : FolderSystem
{
    // Start is called before the first frame update
    private SciGalleryScreenManager galleryScreenManager;
    private SciGalleryManager galleryManager;
    private GameObject sciGallery;
    private CSVReader reader;
    private GameObject sciGalleryScreen;
    private ControlSciGalleryScreen controlScienceGalleryScreen;
    private string prevSciPath;

    void Awake()
    {
        galleryScreenManager = GameObject.FindGameObjectWithTag("SciGalleryInstruction").GetComponent<SciGalleryScreenManager>();  
        galleryManager = GameObject.FindGameObjectWithTag("SciGallery").GetComponent<SciGalleryManager>();
        sciGallery = GameObject.FindGameObjectWithTag("SciGallery");
        sciGalleryScreen = GameObject.FindGameObjectWithTag("SciGalleryInstruction");
        controlScienceGalleryScreen = sciGalleryScreen.GetComponent<ControlSciGalleryScreen>();
        reader = GetComponent<CSVReader>();
    }

    void Start()
    {
        inializeMain("Assets/Resources/SciGallery");
        //updateSciGalleryFolder();
    }

    public void updateSciGalleryFolder()
    {
        galleryManager.updateGalleryFolder(trimNameStringFromBackSlash(foldersPath));
    }

    public void bumperHeld() //Called from SciGalleryManager
    {
        directoryGoback();
        updateSciGalleryFolder();
    }

        //The folder has been selected
       public void triggerHeld(int clicked) //Called from SciGalleryManager
    {
        if(isImage) //Image was selected
        {
            sciGalleryScreen.SetActive(true);
            controlScienceGalleryScreen.displayImage(clicked,foldersName);
            sciGallery.SetActive(false);
        }
        else
        {
            this.clicked = clicked;
            string targetDirectory = foldersPath[clicked];
            prevSciPath = targetDirectory; //Folderpath gets set to null if there is no folder, meaning it will be null with images so prev is needed
            collectFoldersPath(targetDirectory);
            collectFoldersName(targetDirectory);

            if(isFolder)
            {
                updateSciGalleryFolder();
            }
            else if(isFile) //csv
            {

            }else if(isImage)
            {
                cleanFolderPathForImages(targetDirectory,"SciGallery\\");
                galleryManager.updateGalleryFolder(trimNameStringFromForwardSlash(foldersName));
                galleryManager.updateGalleryImage(foldersName);  
            }
            else
            {
                //Nothing
            }
        } 
    }
}
