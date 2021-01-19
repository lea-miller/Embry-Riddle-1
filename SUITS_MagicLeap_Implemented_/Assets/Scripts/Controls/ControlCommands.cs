﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.MagicLeap;

public abstract class ControlCommands : MonoBehaviour
{
    public abstract void triggerDown();
    public abstract void bumperDown();

    private PlayerController _controllerJoyStick;

    protected virtual void Awake()
    {
        //The Joystick
        _controllerJoyStick = new PlayerController();
        _controllerJoyStick.Selection.MoveUp.performed += ctx => bumperDown();
        _controllerJoyStick.Selection.MoveUp.canceled += ctx => nothing();
        _controllerJoyStick.Selection.MoveDown.performed += ctx => triggerDown();
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
