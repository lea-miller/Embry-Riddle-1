using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.MagicLeap;

public abstract class ControlCommands : MonoBehaviour
{
    public abstract void triggerUp();
    public abstract void triggerHold();
    public abstract void bumperUp();
    public abstract void bumperHold();
    public virtual void bumperDown(){}
    public virtual void triggerDown(){}

    private PlayerController _controllerJoyStick;

    protected virtual void Awake()
    {
        //The Joystick
        _controllerJoyStick = new PlayerController();
        _controllerJoyStick.Selection.MoveUp.performed += ctx => bumperUp();
        _controllerJoyStick.Selection.MoveUp.canceled += ctx => nothing();
        _controllerJoyStick.Selection.MoveUp.performed += ctx => triggerUp();
        _controllerJoyStick.Selection.MoveDown.canceled += ctx => nothing();
        _controllerJoyStick.Selection.MoveDown.performed += ctx => bumperHold();
        _controllerJoyStick.Selection.MoveDown.performed += ctx => triggerHold();
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
