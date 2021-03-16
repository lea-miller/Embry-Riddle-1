using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskG1Control : ControlCommands
{
    Image border;
    TaskGalleryManager manager;
    private int count;
    
    public int positionNumber; //Must be defined in the inspector, it is the postion on in the hiearchy

    private TaskGalleryScreenManager galleryScreenManager;
    
    // private GameObject galleryScreen;
    // private GameObject galleryList;
    // private GameObject galleryBtn;

 
    
    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("TaskGallery").GetComponent<TaskGalleryManager>();
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

   // void Awake()
    // {
    //     border = GetComponent<Image>();
    //     manager = GameObject.FindGameObjectWithTag("TaskGallery").GetComponent<TaskGalleryManager>();
    //     galleryScreen = GameObject.FindGameObjectWithTag("TaskGalleryInstruction");
    //     galleryScreenManager = GameObject.FindGameObjectWithTag("TaskGalleryInstruction").GetComponent<TaskGalleryScreenManager>();
    //     galleryList = GameObject.FindGameObjectWithTag("TaskGallery");
    //     galleryBtn = GameObject.FindGameObjectWithTag("TaskGalleryBtn");
    // }
    
//     void Start()
//     {
//         if(positionNumber == null)
//         {
//             Debug.Log("Position Number is null! Defaulting to 0 please fix or the gallery won't work!");
//             positionNumber = 0;
//         }
//     }

//    public override void triggerUp()
//     {
//         //Task is open
//         if (border.enabled)
//         {
//             GoForwardDelegate();  
//         }
//     }

//     public override void bumperUp()
//     {
//         //Task is open
//         if (border.enabled)
//         {
//             GoBackwardDelegate();
//         }
//     }
    
//     public override void triggerHold()
//     {
//         //The name Taks# is based on how many are displayed at a time in the gallery per page
//         //It does not correllate to the actual amount of tasks
//         count = manager.getCount() + positionNumber;
//         galleryScreen.SetActive(true);
//             if (count < galleryScreenManager.getMaxTasks())
//             {
//                 galleryScreenManager.getDisplay().changeTask(count);
//                 galleryScreenManager.getDisplay().refreshTaskScreen();
//             }
//         galleryList.SetActive(false);
//         galleryBtn.SetActive(false);

//     }

//     public override void bumperHold(){}
    
}
