using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskGalleryInstCollision : GenericCollision
{
    private Image border;
    private GameObject topPanel { get; set; }
    private GameObject mainScreen { get; set;}

   void Awake()
   {
       border = GetComponent<Image>();
   }

   void Start()
   {
        CollisionTaskManager manager = GameObject.FindWithTag("TaskScreen").GetComponent<CollisionTaskManager>();
        mainScreen = manager.mainScreen;
        topPanel = manager.topPanel;
   }

    public override void isOn()
    {
        border.enabled = true;
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }

    public override void isOff()
    {
        border.enabled = false;
        topPanel.SetActive(false);
        mainScreen.SetActive(true);
    }
}
