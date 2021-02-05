using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LerpDemo : MonoBehaviour
{
    [SerializeField]
    private Transform start;
    [SerializeField]
    private Transform end;

    [SerializeField]
    [Range (0f,1f)]
    private float lerp;
    private Transform localstart;

   
    private void Update()
    {
        transform.position = Vector3.Lerp(start.position,end.position,lerp);
        //transform.rotation = Quaternion.Lerp(start.rotation,end.rotation,lerp);
    }
}
