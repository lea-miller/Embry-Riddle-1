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
        cameraPos.x = mainCamera.transform.position.x;
        cameraPos.z = mainCamera.transform.position.z;
        cameraPos.y = mainCamera.transform.position.y;
        transform.position = cameraPos;
    }
}
