using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFolderSystem : FolderSystem
{
// Start is called before the first frame update
    private TaskGalleryScreenManager galleryScreenManager;
    private TaskGalleryManager galleryManager;
    private GameObject taskGallery;
    private CSVReader reader;
    private GameObject taskGalleryScreen, taskGalleryInstr;
    private ControlTaskGalleryScreen controlTaskGalleryScreen;

    void Awake()
    {
        //galleryScreenManager = GameObject.FindGameObjectWithTag("TaskGallery").GetComponent<TaskGalleryScreenManager>();  
        galleryManager = GameObject.FindGameObjectWithTag("TaskGallery").GetComponent<TaskGalleryManager>();
        taskGallery = GameObject.FindGameObjectWithTag("TaskGallery");
        taskGalleryScreen = GameObject.FindGameObjectWithTag("TaskGalleryScreen");
        controlTaskGalleryScreen = taskGalleryScreen.GetComponent<ControlTaskGalleryScreen>();
        taskGalleryInstr = GameObject.FindGameObjectWithTag("TaskGalleryInstruction");
        reader = GetComponent<CSVReader>();
    }

    void Start()
    {
        inializeMain("Assets/Resources/TaskGallery");
        //updateTaskGalleryFolder();
    }

    public void updateTaskGalleryFolder()
    {
        galleryManager.updateGalleryFolder(trimNameStringFromBackSlash(foldersPath));
    }

   public void bumperHeld() //Called from TaskGalleryManager
    {
        if(isFile)
        {
            directoryFileGoBack(foldersPath[0]);
           //No longer in the file, reset the values
            isFile = false;
            isFolder = true;
        }
        else
        {
            directoryGoback();
        }
        updateTaskGalleryFolder();
    }


        //The folder has been selected
       public void triggerHeld(int clicked) //Called from TaskGalleryManager
    {
        if(isImage) //Image was selected
        {
            taskGalleryScreen.SetActive(true);
            controlTaskGalleryScreen.displayImage(clicked,foldersName);
            taskGallery.SetActive(false);
        }
        else if(isFile) //Task was selected
        {
            //Todo
            taskGalleryInstr.SetActive(true);
            var instManger = taskGalleryInstr.GetComponent<TaskGalleryScreenManager>();
            instManger.taskCounter = clicked;
            taskGallery.SetActive(false);
        }
        else
        {
            this.clicked = clicked;
            string targetDirectory = foldersPath[clicked];
            
            collectFoldersName(targetDirectory);

            if(isFolder)
            {
                collectFoldersPath(targetDirectory);
                updateTaskGalleryFolder(); 
            }
            else if(isFile) //csv
            {
                galleryManager.updateGallery(reader.getTask()); //For Tasks
            }
            else if(isImage)
            {
                collectFoldersPath(targetDirectory);
                cleanFolderPathForImages(targetDirectory,"TaskGallery\\");
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
