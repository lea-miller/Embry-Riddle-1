using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompObjectControl : MonoBehaviour
{
    //Prepare empty game objects and vectors
    private GameObject torso, map, compass, lander, landerWaypoint;
    private Vector3 torsoPos, northDir, landerPos, landerDir, normalV;
    private Quaternion waypointRot;

    void Start()
    {
        //Define torso and compass objects by tag
        torso = GameObject.FindWithTag("Torso");
        compass = GameObject.FindWithTag("Compass");
        landerWaypoint = GameObject.FindWithTag("LanderWaypoint");

        map = GameObject.FindWithTag("Map");
        lander = GameObject.FindWithTag("Lander");

        //normal vector to the xz plane
        normalV = new Vector3(0, 1, 0);
    }

    void Update ()
    {
        //Move compass system (or any other object this script is attached to) to be centered on torso
        torsoPos = torso.transform.position;
        transform.position = torsoPos;

        //Define north direction from map and normalize the position to ground level
        northDir = map.transform.eulerAngles;
        northDir.x = 0; //parallel to ground
        northDir.z = 0;
        compass.transform.localEulerAngles = northDir; //rotate to match nav mesh orientation

        //Adjust lander waypoint
        landerPos = lander.transform.position;
        landerDir = landerPos - torsoPos;
        landerDir.y = 0;
        waypointRot = Quaternion.LookRotation(landerDir);
        landerWaypoint.transform.rotation = waypointRot;
    }
}
