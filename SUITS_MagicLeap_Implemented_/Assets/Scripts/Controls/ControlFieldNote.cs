using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ControlFieldNote : ControlCommands
{

    private Image border;
    private TextMeshProUGUI textInstruction;
    [SerializeField]
    private bool isRecording;
    private MarkerManager markerManager;
    private LiveCamera liveCam;

    protected override void Awake()
    {
        base.Awake();
        liveCam = GameObject.FindGameObjectWithTag("MLCam").GetComponent<LiveCamera>();



    }
    private void Start()
    {

        markerManager = GameObject.FindGameObjectWithTag("MiniMapSys").GetComponent<MarkerManager>();
    }

    public override void triggerUp()
    {
        if (isRecording)
        {
            GetComponent<audioRecord>().endRecording();
            liveCam.stopFeed();
            liveCam.displayImage.enabled = false;
            isRecording = false;
        }
        else
        {
            markerManager.NewSampleMarkerPrefab();
            GetComponent<audioRecord>().recording();
            liveCam.displayImage.enabled = true;
            liveCam.startFeed();
            isRecording = true;
            
        }

    }

    public override void bumperUp()
    {

    }

    public override void triggerDown()
    {


    }

    public override void bumperDown()
    {


    }

    public override void triggerHold()
    {



    }

    public override void bumperHold()
    {


    }
}