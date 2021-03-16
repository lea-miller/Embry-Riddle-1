using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ControlTaskGalleryScreen : ControlCommands
{
    private TaskFolderSystem taskFolder;
    private GameObject taskGallery;
    private GameObject taskGalleryScreen;
    private Image border;
    public SpriteRenderer spriteR;
    public TextMeshProUGUI titleBox;

    void Awake()
    {
            taskFolder = GameObject.FindGameObjectWithTag("TaskScreen").GetComponent<TaskFolderSystem>();
            taskGallery = GameObject.FindGameObjectWithTag("TaskGallery");
            taskGalleryScreen = GameObject.FindGameObjectWithTag("TaskGalleryScreen");
            border = GetComponent<Image>();
    }
  
    public override void triggerUp(){}
    public override void bumperUp()
    {
        if(border.enabled)
        {
            taskGallery.SetActive(true);
            taskGalleryScreen.SetActive(false);
        }
    }
    public override void triggerHold(){}
    public override void bumperHold(){}
    
    public void displayImage(int clicked,List<string> foldersName)
    {
        Sprite sprite = Resources.Load<Sprite>(foldersName[clicked]);
        List<string> list = new List<string>();

        list = taskFolder.trimNameStringFromForwardSlash(foldersName);
        titleBox.text = list[clicked];
        spriteR.sprite=sprite;
    }
}
