using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadingController : MonoBehaviour
{
    public Transform headHeading;
    public Transform torsoHeading;
    private Quaternion torsoRot, headRot;
    private GameObject torso, head, controller;

    // Start is called before the first frame update
    void Start()
    {
        torso = GameObject.FindWithTag("Torso");
        head = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        rotateTorsoHeading();
        rotateHeadHeading();
    }

    //Torso Heading update function
    public void rotateTorsoHeading()
    {
        torsoRot = torso.transform.rotation;
        torsoHeading.transform.rotation = torsoRot;
    }

    //Head Heading update function
    public void rotateHeadHeading()
    {
        headRot = torso.transform.rotation;
        headRot.y = head.transform.rotation.y;
        headHeading.transform.rotation = headRot;
    }
}
