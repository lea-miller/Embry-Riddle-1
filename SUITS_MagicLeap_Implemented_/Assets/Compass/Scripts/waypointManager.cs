using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointManager : MonoBehaviour
{
    private GameObject compSys;
    private MarkerManager markerManager;
    private List<Marker> markerList;

    void Start()
    {
        markerManager = GameObject.FindWithTag("MiniMapSys").GetComponent<MarkerManager>();
        markerList = markerManager.markerList;

        compSys = GameObject.FindWithTag("CompSys");

        ImportAllWaypoints();
    }


    void Update()
    {
    }

    void ImportAllWaypoints()
    {
        foreach (Marker i in markerList)
        {

            GameObject newWaypoint = Instantiate(Resources.Load("MiniMapSys/Waypoint")) as GameObject;
            newWaypoint.transform.SetParent(compSys.transform);
            newWaypoint.name = "Waypoint " + i;
            //newWaypoint.GetComponentInChildren<Renderer>().material.color = Marker.color;
        }
    }

}
/*
 * for each marker, a new waypoint is initiated in compass
 * 
 * foreach(Marker marker in MiniMapSys)
 * instantiate()
 * 
 * waypoint assigned ID
 * 
 * ***Within waypoint controller?***
 * retrieves ID number/letter, color, position
 * 
 * directional vector calculated
 * 
 * waypoint marker is rotated to face along directional vector
 * 
 * waypoint color changed
 * 
 * display ID num/let
 */