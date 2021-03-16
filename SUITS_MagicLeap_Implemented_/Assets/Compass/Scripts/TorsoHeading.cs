using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoHeading : MonoBehaviour
{
    private Quaternion torsoRot;
    private GameObject torso, torsoHeading;

    void Awake()
    {
        torso = GameObject.FindWithTag("Torso");
        torsoHeading = GameObject.FindWithTag("TorsoHeadingIndicator");
    }

    void Update()
    {
        rotateTorsoHeading();
    }

    //Torso Heading update function
    public void rotateTorsoHeading()
    {
        torsoRot = torso.transform.rotation;
        torsoHeading.transform.rotation = torsoRot;
    }
}
