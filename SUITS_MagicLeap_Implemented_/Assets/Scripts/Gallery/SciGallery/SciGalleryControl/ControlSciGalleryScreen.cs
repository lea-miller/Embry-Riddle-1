using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlSciGalleryScreen : ControlCommands
{
  
    private SciFolderSystem sciFolder;
    private GameObject sciGallery;
    private GameObject sciGalleryScreen;
    private Image border;
    public SpriteRenderer spriteR;
    public TextMeshProUGUI titleBox;

    void Awake()
    {
            sciFolder = GameObject.FindGameObjectWithTag("ScienceScreen").GetComponent<SciFolderSystem>();
            sciGallery = GameObject.FindGameObjectWithTag("SciGallery");
            sciGalleryScreen = GameObject.FindGameObjectWithTag("SciGalleryInstruction");
            border = GetComponent<Image>();
    }
  
    public override void triggerUp(){}
    public override void bumperUp()
    {
        if(border.enabled)
        {
            sciGallery.SetActive(true);
            sciGalleryScreen.SetActive(false);
        }
    }
    public override void triggerHold(){}
    public override void bumperHold(){}
    
    public void displayImage(int clicked,List<string> foldersName)
    {
        Sprite sprite = Resources.Load<Sprite>(foldersName[clicked]);
        List<string> list = new List<string>();
        
        list = sciFolder.trimNameStringFromForwardSlash(foldersName);
        titleBox.text = list[clicked];
        spriteR.sprite=sprite;
    }
}
