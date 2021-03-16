using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class torsoScript : MonoBehaviour
{
   
    public Camera mainCamera;
    private Vector3 cameraPos;
    public float smoothTime = 1F;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        cameraPos = mainCamera.transform.position;
        transform.position = Vector3.SmoothDamp(transform.position, cameraPos, ref velocity, smoothTime);
    }
}
