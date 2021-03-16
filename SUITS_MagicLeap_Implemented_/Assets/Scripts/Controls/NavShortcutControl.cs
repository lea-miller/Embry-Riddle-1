using UnityEngine;
using UnityEngine.UI;

public class NavShortcutControl : ControlCommands
{
    private Image border;
 
    private NavManager navManager;
    private TaskScreenManager taskManager;
    private ControlAppBar appBar;
    

    protected override void Awake()
    {
        base.Awake();
        navManager = GameObject.FindGameObjectWithTag("MiniMapSys").GetComponent<NavManager>();
        taskManager = GameObject.FindGameObjectWithTag("TaskScreen").GetComponent<TaskScreenManager>();
        appBar =  GameObject.FindGameObjectWithTag("AppBar").GetComponent<ControlAppBar>();


    }


    public override void triggerUp()
    {
        Marker marker = taskManager.navToMarker;
        navManager.setCurrentTarget(marker);
        appBar.simulateTriggerUp();
        

    }

    public override void bumperUp()
    {


       
    }

    public override void triggerHold()
    {
     
    }
    public override void bumperHold() { }
}