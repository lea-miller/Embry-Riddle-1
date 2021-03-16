using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public Transform torso;
    public float camHeight;

    private void Awake()
    {
    
    }
    void Update()
    {

        Vector3 newPosition = torso.position + new Vector3(0, camHeight, 0);

        transform.position = newPosition;

        transform.eulerAngles = new Vector3(90, torso.eulerAngles.y, 0);


    }
}
