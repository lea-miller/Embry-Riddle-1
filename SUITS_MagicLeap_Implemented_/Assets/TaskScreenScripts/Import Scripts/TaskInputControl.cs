using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskInputControl : MonoBehaviour
{

    TaskScreenManager _taskScreen;
    private Image taskImage, instructImage;
    
    private bool isOnTask {get; set;}
    private bool isOnInst {get; set;}
    private bool isOnScreen {get; set;} //check if neither

    void Awake()
    {
        userCollider.notifyTaskHit += isOnTaskCheck;
        userCollider.notifyInstHit += isOnInstCheck;
        userCollider.notifyScreenHit += isOnScreenCheck;
        _taskScreen = GameObject.FindWithTag("NotesUI").GetComponent<TaskScreenManager>();
        taskImage = GameObject.FindWithTag("TaskView").GetComponent<Image>();
        instructImage = GameObject.FindWithTag("InstructionView").GetComponent<Image>();
        isOnScreen = false;
    }
    
    private void isOnTaskCheck()
    {
        if(isOnTask)
        {
            instructImage.enabled = false;
            taskImage.enabled = true;
 
            isOnTask = false; //avoid GUI constantly refreshing
            isOnInst = true;
            isOnScreen = false;
        }
    }

    private void isOnInstCheck()
    {
        if(isOnInst)
        {
            taskImage.enabled = false;
            instructImage.enabled = true;
            
            isOnInst = false; //avoid GUI constantly refreshing
            isOnTask = true;
            isOnScreen = false;
        }
    }

    //This method also initalizes the boolens b/c on startup the user never starts on taskscreen
    private void isOnScreenCheck()
    {
        if(!isOnScreen)
        {
            taskImage.enabled = false;
            instructImage.enabled = false;
            isOnTask = true;
            isOnInst = true;
            isOnScreen = true; //avoid GUI constantly refreshing
        }
    }

    //The event would have changed the boolens before the trigger, thats why bool logic seems nonlogical
    public void checkTrigger()
    {
        //Task is open
        if(!isOnTask && !isOnScreen)
        {
            _taskScreen.getTask().nextTask();
            _taskScreen.getDisplay().changeTask();

        }
        else if(!isOnInst && !isOnScreen)
        {
            _taskScreen.getInstruct().nextInst();
            _taskScreen.getDisplay().changePage();
        }
    }
    
    //The event would have changed the boolens before the bumper, thats why bool logic seems nonlogical
    public void checkBumper()
    {
            //Task is open
            if (!isOnTask && !isOnScreen)
            {
                _taskScreen.getTask().prevTask();
                _taskScreen.getDisplay().changeTask();
            }
            else if(!isOnInst && !isOnScreen)
            {
                _taskScreen.getInstruct().prevInst();
                _taskScreen.getDisplay().changePage();
            }
    }
}
