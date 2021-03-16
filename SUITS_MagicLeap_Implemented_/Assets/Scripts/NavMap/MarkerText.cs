using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerText : MonoBehaviour
{
    public Transform torso;

    void Update()
    {

        transform.eulerAngles = new Vector3(90, torso.eulerAngles.y, 0);


    }
}
