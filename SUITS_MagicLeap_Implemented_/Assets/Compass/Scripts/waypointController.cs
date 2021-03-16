using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointController : MonoBehaviour
{
    private GameObject torso;
    public GameObject target;
    private Vector3 pos, targetPos, targetDir;

    void Start()
    {
        //targetPos = GetComponentInChildren<Transform>().Find("targetPos").position;
        torso = GameObject.FindWithTag("Torso");
    }

    void Update()
    {
        targetPos = target.transform.position;
        pos = torso.transform.position;
        targetDir = targetPos - pos;

        transform.rotation = Quaternion.LookRotation(targetDir);
    }
}
/*
 * retrieves number/letter, color, position based on ID
 * 
 * directional vector calculated to marker
 * 
 * 
 * waypoint marker is rotated to face along directional vector
 * 
 * waypoint color changed
 * 
 * display ID num/let
 */