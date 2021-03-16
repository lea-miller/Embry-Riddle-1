using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMap : ControlCommands
{
    private Image border;
    private GameObject miniMapScreen;
    private GameObject fullMapScreen;
    private NavPlayer navPlayer;
    public int zoomLevel;
    private int maxZoomLevel;
    public float maxZoomMini;
    public float maxZoomFull;

    protected override void Awake()
    {
        base.Awake();
        border = GetComponent<Image>();
        miniMapScreen = GameObject.FindGameObjectWithTag("MiniMapScreen");
        fullMapScreen = GameObject.FindGameObjectWithTag("FullMapScreen");
        navPlayer = GameObject.FindGameObjectWithTag("NavPlayer").GetComponent<NavPlayer>();
        fullMapScreen.SetActive(false);
        zoomLevel = 2;
        maxZoomLevel = 3;
        maxZoomMini = 30;
        navPlayer.miniMapZoom = maxZoomMini * ((float) zoomLevel / (float)maxZoomLevel);
        Debug.Log(maxZoomMini * (zoomLevel / maxZoomLevel));

    }


    public override void triggerUp()
    {
        if (zoomLevel > 1)
        {
            zoomLevel--;
            navPlayer.miniMapZoom = maxZoomMini * ((float)zoomLevel / (float)maxZoomLevel);

        }

    }

    public override void bumperUp()
    {
       

        if (zoomLevel < maxZoomLevel)
        {
            zoomLevel++;
            navPlayer.miniMapZoom = maxZoomMini * ((float)zoomLevel / (float)maxZoomLevel);
            Debug.Log(maxZoomMini * (zoomLevel / maxZoomLevel));

        }
    }

    public override void triggerHold()
    {
        if (miniMapScreen.activeSelf)
        {
            fullMapScreen.SetActive(true);
            miniMapScreen.SetActive(false);
        }
        else
        {
            fullMapScreen.SetActive(false);
            miniMapScreen.SetActive(true);
        }
    }
    public override void bumperHold() { }
}
