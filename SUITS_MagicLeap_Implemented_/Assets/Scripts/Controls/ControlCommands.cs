using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.MagicLeap;

public abstract class ControlCommands : MonoBehaviour
{
    protected Image border;
    
    protected TaskScreenManager taskScreen;

    public abstract void nextSelection();
    public abstract void prevSelection();

    private PlayerController _controllerJoyStick;

    protected virtual void Awake()
    {
        taskScreen = GameObject.FindWithTag("TaskScreen").GetComponent<TaskScreenManager>();
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

    void nothing() { }

    void onDisable()
    {
        _controllerJoyStick.Selection.Disable();
    }
}
