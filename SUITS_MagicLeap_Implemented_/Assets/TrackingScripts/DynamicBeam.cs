using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class DynamicBeam : MonoBehaviour
{
    public GameObject controller;
    private LineRenderer beamLine;
    public Color colorStart, colorEnd;
    // Start is called before the first frame update
    void Start()
    {
        beamLine = GetComponent<LineRenderer>();
        colorStart.a = 255;
        colorEnd.a = 255;
        beamLine.startColor = colorStart;
        beamLine.endColor = colorEnd;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = controller.transform.position;
        transform.rotation = controller.transform.rotation;

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward,out hit))
        {
            beamLine.useWorldSpace = true;
            beamLine.SetPosition(0, transform.position);
            beamLine.SetPosition(1, hit.point);

        }
        else
        {
            beamLine.SetPosition(0, transform.position);
            beamLine.SetPosition(1, Vector3.forward*5);
        }
    }

}


