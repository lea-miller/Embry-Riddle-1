﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTask : GenericCollision, ICollisionTask
{
    public Image taskTopImage { get; set; }
    public Image taskImage { get; set; }
    public Image instructImage { get; set; }
    public GameObject topPanel { get; set; }
    public GameObject mainScreen { get; set; }

    protected virtual void Start()
    {
        CollisionTaskManager manager = GameObject.FindWithTag("TaskScreen").GetComponent<CollisionTaskManager>();
        taskImage = manager.taskImage;
        instructImage = manager.instructImage;
        topPanel = manager.topPanel;
        taskTopImage = manager.taskTopImage;
        mainScreen = manager.mainScreen;
    }

    public override void isOn() { }
    public override void isOff()
    {
        taskImage.enabled = false;
        instructImage.enabled = false;
        taskTopImage.enabled = false;

        topPanel.SetActive(false);
        mainScreen.SetActive(true);
    }
}
