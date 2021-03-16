using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlGalleryBackBtn : ControlCommands
{

    private GameObject galleryList;
    private GameObject galleryScreen;
    private GameObject galleryBtn;
    private Image border;
    
    void Awake()
    {
        galleryList = GameObject.FindGameObjectWithTag("TaskGallery");
        galleryScreen = GameObject.FindGameObjectWithTag("TaskGalleryInstruction");
        galleryBtn = GameObject.FindGameObjectWithTag("TaskGalleryBtn");
        border = galleryScreen.GetComponent<Image>();
    }

    public override void bumperUp(){}
    public override void bumperHold(){}
    public override void triggerHold(){}
    public override void triggerUp()
    {
            if(border.enabled)
        {
            galleryList.SetActive(true);
            galleryScreen.SetActive(false);
            galleryBtn.SetActive(true);
        }
    }
}
