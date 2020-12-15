using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTaskTopPanel : MonoBehaviour, ICollisionTask
{
    public Image taskTopImage { get; set; }
    public Image taskImage { get; set; }
    public Image instructImage { get; set; }
    public GameObject topPanel { get; set; }
    public GameObject mainScreen { get; set; }

    protected void Awake()
    {
        userCollider.notifyMainTaskHit += isOn;

        CollisionTaskManager manager = GameObject.FindWithTag("TaskScreen").GetComponent<CollisionTaskManager>();
        taskImage = manager.taskImage;
        instructImage = manager.instructImage;
        topPanel = manager.topPanel;
        taskTopImage = manager.taskTopImage;
        mainScreen = manager.mainScreen;
    }

    protected void isOn()
    {
        taskImage.enabled = false;
        taskTopImage.enabled = true;
        instructImage.enabled = false;

        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }

}
