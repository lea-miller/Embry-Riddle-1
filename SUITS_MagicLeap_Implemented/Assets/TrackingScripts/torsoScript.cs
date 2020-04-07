using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torsoScript : MonoBehaviour
{

    public Camera mainCamera;
    private Vector3 cameraPos;

    // Update is called once per frame
    void Update()
    {
        cameraPos = mainCamera.transform.position;
        transform.position = cameraPos;
    }
}
