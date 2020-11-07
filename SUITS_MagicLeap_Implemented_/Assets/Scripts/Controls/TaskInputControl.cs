using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.MagicLeap;

public class TaskInputControl : MonoBehaviour
{
    TaskScreenManager _taskScreen;
    private Image taskImage, instructImage,taskTopImage;
    [SerializeField ]
    private GameObject topPanel, mainScreen;
    private PlayerController _controllerJoyStick;

    void Awake()
    {
        _taskScreen = GameObject.FindWithTag("NotesUI").GetComponent<TaskScreenManager>();
        taskImage = GameObject.FindWithTag("TaskSelection").GetComponent<Image>();
        instructImage = GameObject.FindWithTag("InstructionView").GetComponent<Image>();
        taskTopImage = GameObject.FindWithTag("TopLCanvas").GetComponent<Image>();

        //Focus Indicators
        userCollider.notifyTaskHit += isOnTaskCheck;
        userCollider.notifyInstHit += isOnInstCheck;
        userCollider.notifyScreenHit += isOnScreenCheck;
        userCollider.notifyMainTaskHit += isOnMainTaskCheck;

        //The Joystick
        _controllerJoyStick = new PlayerController();
        _controllerJoyStick.Selection.MoveUp.performed += ctx => prevSelection();
        _controllerJoyStick.Selection.MoveUp.canceled += ctx => nothing();
        _controllerJoyStick.Selection.MoveDown.performed += ctx => nextSelection();
        _controllerJoyStick.Selection.MoveDown.canceled += ctx => nothing();
    }
    
    void onEnable()
    {
        _controllerJoyStick.Selection.Enable();
    }

    void nothing(){}

    void onDisable()
    {
        _controllerJoyStick.Selection.Disable();
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

    public void nextSelection()
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
    
    public void prevSelection()
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
