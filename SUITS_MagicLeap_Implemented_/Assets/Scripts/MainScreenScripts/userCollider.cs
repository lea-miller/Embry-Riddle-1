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

    public delegate void VitalTopViewHitNotify();
    public static event VitalTopViewHitNotify notifyVitalTopViewHit; 
  
    public delegate void ScreenHitNotify();
    public static event ScreenHitNotify notifyScreenHit;

    public delegate void MainTaskHitNotify();
    public static event MainTaskHitNotify notifyMainTaskHit;

    private bool isOnScreen; //check if neither
    private bool isOnMainTask;
    private bool isOnTask;
    private bool isOnInst;
    private bool isOnVital;
    private bool isOnMainVital;

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
            if (hit.transform.gameObject.tag == "TaskTopView")
            {
                if(isOnMainTask)
                {
                    notifyMainTaskHit();
                    isOnMainTask = false;
                    isOnInst = true;
                    isOnTask = true;
                    isOnVital = true;
                }
            }
            else if (hit.transform.gameObject.tag == "TaskView") 
            {
                if(isOnTask)
                {
                    notifyTaskHit();
                    isOnMainTask = true;
                    isOnInst = true;
                    isOnTask = false;
                    isOnVital = true;
                }
            } 
            else if (hit.transform.gameObject.tag == "InstructionView")
            {
                if(isOnInst)
                {
                    notifyInstHit();
                    isOnMainTask = true;
                    isOnInst = false;
                    isOnTask = true;
                    isOnVital = true;
                }
            }
            else if (hit.transform.gameObject.tag == "VitalsUI")
            {
                if(isOnVital)
                {
                    notifyVitalHit();
                    isOnMainVital = true;
                    isOnVital = false;
                }
            }
            else if (hit.transform.gameObject.tag == "VitalTopView")
            {
                if(isOnMainVital)
                {
                    notifyVitalTopViewHit();
                    isOnMainVital = false;
                    isOnVital = true;
                }
            }
          }
        else
        {
             notifyScreenHit();
                isOnMainTask = true;
                isOnInst = true;
                isOnTask = true;
                isOnVital = true;
        }
    }
}
