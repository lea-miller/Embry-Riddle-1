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

    public delegate void MainTaskHitNotify();
    public static event MainTaskHitNotify notifyMainTaskHit;

    bool isOnScreen{set;get;} //check if neither
    bool isOnMainTask{set;get;}
    bool isOnTask{set;get;}
    bool isOnInst{set;get;}
    bool isOnVital{set;get;}

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
                    isOnMainTask = true;
                    isOnInst = true;
                    isOnTask = true;
                    isOnVital = false;
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
