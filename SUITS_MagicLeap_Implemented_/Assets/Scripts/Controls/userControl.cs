using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userControl : MonoBehaviour
{
    RaycastHit hit;
    private ControlCommands collide;

    // Update is called once per frame
    void FixedUpdate()
    {
        check();
    }

    public void triggerDown()
    {
        if(collide != null)
        {
            collide.triggerDown();
            Debug.Log("Trigger");
        }
    }

    public void bumperDown()
    {
        if(collide !=null)
        {
            collide.bumperDown();
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
