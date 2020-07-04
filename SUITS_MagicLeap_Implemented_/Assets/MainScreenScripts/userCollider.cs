using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userCollider : MonoBehaviour
{
    RaycastHit hit;
    public delegate void TaskHitNotify();
    public static event TaskHitNotify notifyTaskHit;

    public delegate void InstHitNotify();
    public static event InstHitNotify notifyInstHit;

    public delegate void VitalHitNotify();
    public static event VitalHitNotify notifyVitalHit;  
  
    public delegate void ScreenHitNotify();
    public static event ScreenHitNotify notifyScreenHit;



    // Update is called once per frame
    void FixedUpdate()
    {
        checkCollision();
    }

    private void checkCollision()
    {
          Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,2);
          //Debug.DrawRay(transform.position, hit.transform.TransformDirection(Vector3.forward) * 2, Color.green);
          if(hit.collider != null)
          {
            if (hit.transform.gameObject.tag == "TaskView") 
            {
                notifyTaskHit();
            } 
            else if (hit.transform.gameObject.tag == "InstructionView")
            {
                notifyInstHit();
            }
            else if (hit.transform.gameObject.tag == "VitalsUI")
            {
                notifyVitalHit();
            }
          }
          else
          {
                notifyScreenHit();
          }
    }
}
