using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackCanvasScreen : MonoBehaviour
{
    public GameObject currentScreen;
    private float rotation = 0.4f;
    private Quaternion currentScreenRotation, torsoRot;
    private GameObject torso, controller;

    public float smoothTime;
    private Vector3 velocity = Vector3.zero;
    private float AngularVelocity = 0.0f;
    private float VelocityScreen = 0.0f;
    private Quaternion rot;
    void Start()
    {
        controller = GameObject.FindWithTag("MLController");
        torso = GameObject.FindWithTag("Torso");
        distanceFromHead();
    }

    // Update is called once per frame
    void Update()
    {
        
        updateTorsoWithRemote();
        rotationSync();
    }

    //The roation of the camera causes the current canvas to rotate without changing its position
    void rotationSync()
    {
        Vector3 currentScreenForward = Camera.main.transform.forward * rotation;
        currentScreen.transform.forward = currentScreenForward;
        //Debug.Log(torso.transform.rotation.x);
        
        if (torso.transform.rotation.x > -.5)
        {
            float zrot = Camera.main.transform.rotation.eulerAngles.z;
            Vector3 tempRot = currentScreen.transform.rotation.eulerAngles;
            tempRot.z = zrot;
            rot.eulerAngles = tempRot;
            currentScreen.transform.rotation = rot;
        }
        

    }

    /*The pointer of the remote is in the z axis by the MagicLeap Devs
    Therefore to have the remote vertical to mount on torso it must be in the y plane
    Since the touchpad of the remote will be on the chest, the direction is in the -y plane
    */
    public void updateTorsoWithRemote()
    {
        torsoRot = controller.transform.rotation;
        float delta = Quaternion.Angle(torso.transform.rotation, torsoRot);
        if (delta > 1f)
        {
            float t = Mathf.SmoothDampAngle(delta, 0.0f, ref AngularVelocity, smoothTime);
            t = 1.0f - (t / delta);
            torso.transform.rotation = Quaternion.Slerp(torso.transform.rotation, torsoRot, t);
        }
    }

    private void distanceFromHead()
    {
        Vector3 canvasDistance = new Vector3(transform.position.x, -50f / 100, transform.position.z);
        transform.position = canvasDistance;
    }

}
