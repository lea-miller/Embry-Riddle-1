using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagicLeapTools;
using MagicLeap;
using UnityEngine.XR.MagicLeap;

public class userControl : MonoBehaviour
{
    public ControlInput controlInput;

    RaycastHit hit;
    private ControlCommands collide;
    private bool isTrigger = false;
    private bool isTriggerHold = false;
    private int count = 0;
    private bool isBump = false;
    private bool isBumperHold = false;
    private int countBump = 0;
    MLInput.Controller control;

    private void Awake()
    {
        MLInput.Start();
        control = MLInput.GetController(MLInput.Hand.Left);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        check();
        checkTrigHold();
        checkBumpHold();
    }

    public void checkTrigHold()
    {
        if(hit.collider != null && collide != null)
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
                    
                    control.StartFeedbackPatternVibe(MLInput.Controller.FeedbackPatternVibe.Click, MLInput.Controller.FeedbackIntensity.Medium);
                    
                   //Debug.Log("Triggered");
                }
                else if(count >= 50)
                {
                    isTriggerHold = false;
                    collide.triggerHold();
                    control.StartFeedbackPatternVibe(MLInput.Controller.FeedbackPatternVibe.ForceDown, MLInput.Controller.FeedbackIntensity.High);
                    //Debug.Log("Trigger Held");
                }
            }   
        }
    }

    public void triggerUp()
    {
        if(hit.collider != null && collide != null)
        {
            if(count >= 50)
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
        if(hit.collider != null && collide != null)
        {
            isTriggerHold = true;
            collide.triggerDown();
        }
    }

    public void checkBumpHold()
    {
        if(hit.collider != null && collide != null)
        {
            if(isBumperHold)
            {
                countBump = countBump + 1;
                if(isBump)
                {
                    countBump = 0;
                    isBumperHold = false;
                    isBump = false; //have this a synchronous precaution although unlikely an out of synch error would occur
                    //Debug.Log("Bumper");
                    collide.bumperUp();
                    control.StartFeedbackPatternVibe(MLInput.Controller.FeedbackPatternVibe.Bump, MLInput.Controller.FeedbackIntensity.Medium);
                }
                else if(countBump >= 50)
                {
                    isBumperHold = false;
                    //Debug.Log("Bumper Held");
                    collide.bumperHold();
                    control.StartFeedbackPatternVibe(MLInput.Controller.FeedbackPatternVibe.ForceDown, MLInput.Controller.FeedbackIntensity.High);
                }
            }   
        }
    }

      public void bumperDown()
    {
        if(hit.collider !=null && collide != null)
        {
            isBumperHold = true;
            collide.bumperDown();
        }
    }

    public void bumperUp()
    {
        if(hit.collider != null && collide != null)
        {
            if(countBump >= 50)
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
                    control.StartFeedbackPatternVibe(MLInput.Controller.FeedbackPatternVibe.Tick, MLInput.Controller.FeedbackIntensity.Low);
                    collide = (ControlCommands)hit.transform.gameObject.GetComponent(typeof(ControlCommands));
                }
            }
        }
    }
}
