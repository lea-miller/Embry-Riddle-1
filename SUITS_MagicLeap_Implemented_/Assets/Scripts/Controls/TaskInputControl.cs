using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskInputControl : MonoBehaviour
{

    TaskScreenManager _taskScreen;
    private Image taskImage, instructImage,taskTopImage;
    [SerializeField ]
    private GameObject topPanel, mainScreen;

    void Awake()
    {
        userCollider.notifyTaskHit += isOnTaskCheck;
        userCollider.notifyInstHit += isOnInstCheck;
        userCollider.notifyScreenHit += isOnScreenCheck;
        userCollider.notifyMainTaskHit += isOnMainTaskCheck;
        
        _taskScreen = GameObject.FindWithTag("NotesUI").GetComponent<TaskScreenManager>();
        taskImage = GameObject.FindWithTag("TaskView").GetComponent<Image>();
        instructImage = GameObject.FindWithTag("InstructionView").GetComponent<Image>();
        taskTopImage = GameObject.FindWithTag("TaskTopView").GetComponent<Image>();
    }
    
    private void isOnTaskCheck()
    {
        instructImage.enabled = false;
        taskImage.enabled = true;
        taskTopImage.enabled = false;
            
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }

    private void isOnInstCheck()
    {
        taskImage.enabled = false;
        taskTopImage.enabled = false;
        instructImage.enabled = true;
            
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }

    private void isOnMainTaskCheck()
    {
        taskImage.enabled = false;
        taskTopImage.enabled = true;
        instructImage.enabled = false;
            
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }

    //This method also initalizes the boolens b/c on startup the user never starts on taskscreen
    private void isOnScreenCheck()
    {
        taskImage.enabled = false;
        instructImage.enabled = false;
        taskTopImage.enabled = false;
            
        topPanel.SetActive(false);
        mainScreen.SetActive(true);
    }

    //The event would have changed the boolens before the trigger, thats why bool logic seems nonlogical
    public void checkTrigger()
    {
        //Task is open
        if(taskImage.enabled)
        {
            _taskScreen.getTask().nextTask();
            _taskScreen.getDisplay().changeTask();
        }
        else if(instructImage.enabled)
        {
            _taskScreen.getInstruct().nextInst();
            _taskScreen.getDisplay().changePage();
        }
    }
    
    //The event would have changed the boolens before the bumper, thats why bool logic seems nonlogical
    public void checkBumper()
    {
        //Task is open
        if (taskImage.enabled)
        {
            _taskScreen.getTask().prevTask();
            _taskScreen.getDisplay().changeTask();
        }
        else if(instructImage.enabled)
        {
            _taskScreen.getInstruct().prevInst();
            _taskScreen.getDisplay().changePage();
        }
    }
}
