using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlGalleryBtn : ControlCommands
{
    private Image border;
    private GameObject taskScreen,sciScreen;
    private GameObject galleryTaskScreen,gallerySciScreen;
    private GameObject galleryTaskInst, gallerySciInst;
    private GameObject galleryScreenTaskScreen;
    private GameObject taskScreenInst;
    private SciFolderSystem sciFolder;
    private GameObject taskScreenSelc { get; set; }
    private GameObject sciInstruction;
    private GameObject sciProcedure;
    private TaskFolderSystem taskFolder;
    bool isTrigger = true;

    protected override void Awake()
    {
        border = this.GetComponent<Image>();

        taskScreen = GameObject.FindGameObjectWithTag("TaskScreen");
        sciScreen = GameObject.FindGameObjectWithTag("ScienceScreen");

        galleryTaskInst =  GameObject.FindGameObjectWithTag("TaskGalleryInstruction");
        galleryTaskScreen = GameObject.FindGameObjectWithTag("TaskGallery");
        taskScreenInst = GameObject.FindGameObjectWithTag("TaskInstruction");
        taskScreenSelc = GameObject.FindGameObjectWithTag("TaskSelection");
        galleryScreenTaskScreen = GameObject.FindGameObjectWithTag("TaskGalleryScreen");
        taskFolder = taskScreen.GetComponent<TaskFolderSystem>();

        gallerySciInst = GameObject.FindGameObjectWithTag("SciGalleryInstruction");
        sciProcedure = GameObject.FindGameObjectWithTag("SciProcedure");
        gallerySciScreen = GameObject.FindGameObjectWithTag("SciGallery");
        sciFolder = sciScreen.GetComponent<SciFolderSystem>();
    }

    void Start()
    {
        galleryScreenTaskScreen.SetActive(false);
        galleryTaskInst.SetActive(false);
        galleryTaskScreen.SetActive(false); 
        gallerySciInst.SetActive(false);
        gallerySciScreen.SetActive(false);
    }

    public override void triggerUp()
    {
        checkGalleryType();
    }

    private void checkGalleryType()
    {
        if(taskScreen.activeSelf)
        {
            TaskGalleryTriggered();
        }
        else if(sciScreen.activeSelf)
        {
            SciGalleryTriggered();
        }
    }

    private void TaskGalleryTriggered()
    {
        if(border.enabled && isTrigger)
        {
            taskFolder.updateTaskGalleryFolder();
            galleryTaskScreen.SetActive(true); 
            taskScreenInst.SetActive(false); 
            taskScreenSelc.SetActive(false);
            isTrigger = false;    
        }
        else if(border.enabled && isTrigger == false)
        {
            galleryTaskScreen.SetActive(false); 
            taskScreenInst.SetActive(true); 
            taskScreenSelc.SetActive(true);
            isTrigger = true;
        }
    }

    private void SciGalleryTriggered()
    {
        if(border.enabled && isTrigger)
        {
            sciFolder.updateSciGalleryFolder();
            gallerySciScreen.SetActive(true);;
            sciProcedure.SetActive(false);  
            isTrigger = false;    
        }
        else if(border.enabled && isTrigger == false)
        {
            gallerySciScreen.SetActive(false);
            sciProcedure.SetActive(true); 
            isTrigger = true;
        }
    }

    public override void bumperUp(){}
    public override void triggerHold(){}
    public override void bumperHold(){}
}
