using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationPointer : MonoBehaviour
{
    private Vector3 targetPosition;
    private Transform pointerTransform;
    public float destinationX, destinationY,destinationZ;

    
    public GameObject currentScreen;
    private float rotation = 0.4f;
    private Quaternion currentScreenRotation, torsoRot;
    private GameObject torso, controller;
    Vector3 target;

    private void Awake()
    {
        pointerTransform = this.transform;
    }
    void Start()
    {
        distanceFromHead();
    }
    private void Update()
    {
        torso = GameObject.FindWithTag("Torso");
        target = GameObject.Find("Target").transform.position;;
        targetPosition = new Vector3(target.x,target.y,target.z);
       
        rotationSync();
        
        Vector3 toTarget = targetPosition;
        Vector3 currPosition = torso.GetComponent<Transform>().position;
        Vector3 dir = (toTarget - currPosition).normalized;
        float angle =  (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) % 360;
        pointerTransform.localEulerAngles = new Vector3(0,0,angle);
    }

    private void distanceFromHead()
    {
        Vector3 canvasDistance = new Vector3(transform.position.x, -50f/100, -20f/100);
        transform.position = canvasDistance;
    }

    //The roation of the camera causes the current canvas to rotate without changing its position
    void rotationSync()
    {
        Vector3 currentScreenForward = Camera.main.transform.forward * rotation;
        currentScreen.transform.forward = currentScreenForward;
    }

}
