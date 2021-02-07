using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompObjectControl : MonoBehaviour
{
    public Transform torso;

    void Update ()
    {

        Vector3 newPosition = torso.position;
        transform.position = newPosition;

    }
}
