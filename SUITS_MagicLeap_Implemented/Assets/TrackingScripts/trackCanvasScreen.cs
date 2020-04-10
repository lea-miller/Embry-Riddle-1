<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackCanvasScreen : MonoBehaviour
{
    public GameObject currentScreen;
   // private float rotation = 0.4f;
    private Quaternion currentScreenRotation, torsoRot;
    private GameObject torso, controller;
    void Start()
    {
        controller = GameObject.FindWithTag("MLController");
        torso = GameObject.FindWithTag("Torso");
        distanceFromHead();
    }
       
    // Update is called once per frame
    void Update()
    {
        rotationSync();
        updateTorsoWithRemote();
    }

    //The roation of the camera causes the current canvas to rotate without changing its position
    void rotationSync()
    {
        Vector3 currentScreenForward = Camera.main.transform.forward;
        currentScreen.transform.forward = currentScreenForward;
    }

    /*The pointer of the remote is in the z axis by the MagicLeap Devs
    Therefore to have the remote vertical to mount on torso it must be in the y plane
    */
    public void updateTorsoWithRemote()
    {
        torsoRot = controller.transform.rotation;
        torso.transform.rotation = torsoRot;
    }

    // Since the touchpad of the remote will be facing the chest, the direction facing away from the chest is in the -y plane
    private void distanceFromHead()
    {
        Vector3 canvasDistance = new Vector3(transform.position.x, -20f/100, transform.position.z);
        transform.position = canvasDistance;
    }

}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackCanvasScreen : MonoBehaviour
{
    public GameObject currentScreen;
    private float rotation = 0.4f;
    private Quaternion currentScreenRotation, torsoRot;
    private GameObject torso, controller;
    void Start()
    {
        controller = GameObject.FindWithTag("MLController");
        torso = GameObject.FindWithTag("Torso");
        distanceFromHead();
    }
       
    // Update is called once per frame
    void Update()
    {
        rotationSync();
        updateTorsoWithRemote();
    }

    //The roation of the camera causes the current canvas to rotate without changing its position
    void rotationSync()
    {
        Vector3 currentScreenForward = Camera.main.transform.forward * rotation;
        currentScreen.transform.forward = currentScreenForward;
    }

    /*The pointer of the remote is in the z axis by the MagicLeap Devs
    Therefore to have the remote vertical to mount on torso it must be in the y plane
    Since the touchpad of the remote will be on the chest, the direction is in the -y plane
    */
    public void updateTorsoWithRemote()
    {
        torsoRot = controller.transform.rotation;
        torso.transform.rotation = torsoRot;
    }

    private void distanceFromHead()
    {
        Vector3 canvasDistance = new Vector3(transform.position.x, -50f/100, transform.position.z);
        transform.position = canvasDistance;
    }

}
>>>>>>> master
