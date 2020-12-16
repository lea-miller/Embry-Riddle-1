using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTaskManager : MonoBehaviour, ICollisionTask
{
    public Image taskTopImage { get; set; }
    public Image taskImage { get; set; }
    public Image instructImage { get; set; }
    public GameObject topPanel { get; set; }
    public GameObject mainScreen { get; set; }

    protected void Awake()
    {
        taskImage = GameObject.FindWithTag("TaskSelection").GetComponent<Image>();
        instructImage = GameObject.FindWithTag("TaskInstruction").GetComponent<Image>();
        topPanel = GameObject.FindWithTag("TopLCanvas");
        taskTopImage = GameObject.FindWithTag("TopLCanvas").GetComponent<Image>();
        mainScreen = GameObject.FindWithTag("MainScreenTopPanel");
    }

    public void Start()
    {
        isOn();
    }

    //Default setup
    public void isOn()
    {
        taskImage.enabled = false;
        instructImage.enabled = false;
        taskTopImage.enabled = false;

        topPanel.SetActive(false);
        mainScreen.SetActive(true);
    }
}
