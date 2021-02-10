using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userControl : MonoBehaviour
{
    RaycastHit hit;
    private ControlCommands collide;
    private bool isTrigger = false;
    private bool isTriggerHold = false;
    private int count = 0;
    private bool isBump = false;
    private bool isBumperHold = false;
    private int countBump = 0;


    // Update is called once per frame
    void FixedUpdate()
    {
        check();
        checkTrigHold();
        checkBumpHold();
    }

    public void checkTrigHold()
    {
        if(collide != null)
        {
            if(isTriggerHold)
            {
                count = count + 1;
                if(isTrigger)
                {
                    count = 0;
                    isTriggerHold = false;
                    isTrigger = false; //have this a synchronous precaution although unlikely an out of synch error would occur
                    collide.triggerUp();
                    Debug.Log("Triggered");
                }
                else if(count >= 70)
                {
                    isTriggerHold = false;
                    collide.triggerHold();
                    Debug.Log("Trigger Held");
                }
            }   
        }
    }

    public void triggerUp()
    {
        if(collide != null)
        {
            if(count >= 30)
            {
                count = 0;
                isTrigger = false;
            }else
            {
                isTrigger = true;
            }
            
        }
    }

    public void triggerDown()
    {
        if(collide != null)
        {
            isTriggerHold = true;
        }
    }

    public void checkBumpHold()
    {
        if(collide != null)
        {
            if(isBumperHold)
            {
                countBump = countBump + 1;
                if(isBump)
                {
                    countBump = 0;
                    isBumperHold = false;
                    isBump = false; //have this a synchronous precaution although unlikely an out of synch error would occur
                    Debug.Log("Bumper");
                    collide.bumperUp();
                }
                else if(countBump >= 70)
                {
                    isBumperHold = false;
                    Debug.Log("Bumper Held");
                    collide.bumperHold();
                }
            }   
        }
    }

      public void bumperDown()
    {
        if(collide !=null)
        {
            isBumperHold = true;
        }
    }

    public void bumperUp()
    {
        if(collide !=null)
        {
            if(countBump >= 30)
            {
                countBump = 0;
                isBump = false;
            }else
            {
                isBump = true;
            }
        }
    }

    private void check()
    {
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2);
        if (hit.collider != null)
        {
            //Checks the gameObject if it has a componenet that extends ControlCommands, 
            //if found it will then call the subclass and use the proper function call
            if (hit.transform.gameObject.TryGetComponent(typeof(ControlCommands), out Component component))
            {
                //Avoids repeating function calls
                if (collide != (ControlCommands)hit.transform.gameObject.GetComponent(typeof(ControlCommands)))
                { 
                    collide = (ControlCommands)hit.transform.gameObject.GetComponent(typeof(ControlCommands));
                }
            }
        }
    }
}
