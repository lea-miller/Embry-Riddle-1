using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public Transform torso;

    void Update()
    {

        Vector3 newPosition = torso.position;
        transform.position = newPosition;

        transform.eulerAngles = new Vector3(0, torso.eulerAngles.y, 45);

    }
}
