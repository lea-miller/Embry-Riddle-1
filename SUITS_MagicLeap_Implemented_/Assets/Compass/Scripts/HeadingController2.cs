using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadingController2 : MonoBehaviour
{
    public Transform heading;
    public Transform direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = direction.transform.forward;
        forward.y = 0;

        //heading.transform.rotation = forward;
    }
}
