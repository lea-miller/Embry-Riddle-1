using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollisionTaskGalleryPages : GenericCollision
{
    // Start is called before the first frame update
    private Image border;
    public GameObject topPanel { get; set; }
    public GameObject mainScreen { get; set; }
    void Awake()
    {
        topPanel = GameObject.FindWithTag("TopLCanvas");
        mainScreen = GameObject.FindWithTag("MainScreenTopPanel");
        border = GetComponent<Image>();
    }

    void Start()
    {
        isOff();
    }

    public override void isOn()
    {
    
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
        border.enabled = true;

    }

    public override void isOff()
    {
        topPanel.SetActive(false);
        mainScreen.SetActive(true);
        border.enabled = false;
    }
}
