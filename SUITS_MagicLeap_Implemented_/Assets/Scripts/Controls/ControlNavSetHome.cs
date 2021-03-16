using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlNavSetHome : ControlCommands
{
    private Image border;
    private NavManager NavManager;
    private GameObject navPlayer;
    private MarkerManager markManager;
    private float tempx = 70f;
    private GameObject miniMapScreen;
    private GameObject fullMapScreen;
    

    protected override void Awake()
    {
        base.Awake();
       

    }
    private void Start()
    {
        border = GetComponent<Image>();
        GameObject mapSys = GameObject.FindGameObjectWithTag("MiniMapSys");
        navPlayer = GameObject.FindGameObjectWithTag("NavPlayer");
        miniMapScreen = GameObject.FindGameObjectWithTag("MiniMapScreen");
        fullMapScreen = GameObject.FindGameObjectWithTag("FullMapScreen");
        markManager = mapSys.GetComponent<MarkerManager>();
        NavManager = mapSys.GetComponent<NavManager>();
    }

    public override void triggerUp()
    {
        NavManager.setCurrentTargetHome();
        
    }

    public override void bumperUp()
    {
        //Task is open
        if (border.enabled)
        {


            if (NavManager.CurrentTarget == null || NavManager.CurrentTarget.Index + 1 == markManager.markerList.Count )
            {
                NavManager.setCurrentTarget(markManager.markerList[0]);
            }
            else 
            {
                NavManager.setCurrentTarget(markManager.markerList[NavManager.CurrentTarget.Index +1]);
            }
            
        }
    }

    public override void triggerHold() 
    {
        navPlayer.GetComponent<NavPlayer>().CalibrateMap();
    }
    public override void bumperHold() { }
}
