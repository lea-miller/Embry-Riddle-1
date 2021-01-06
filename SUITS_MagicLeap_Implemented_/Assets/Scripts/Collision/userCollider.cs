using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userCollider : MonoBehaviour
{
    RaycastHit hit;
    private GenericCollision collide;

    // Update is called once per frame
    void FixedUpdate()
    {
        check();
    }

    private void check()
    {
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2);
        if (hit.collider != null)
        {
           //Debug.Log("Hit! " + hit.collider);
            //Checks the gameObject if it has a componenet that extends Collision Manager, 
            //if found it will then call the subclass and use the proper function call
            if (hit.transform.gameObject.TryGetComponent(typeof(GenericCollision), out Component component))
            {
                //Avoids repeating function calls
                if (collide != (GenericCollision)hit.transform.gameObject.GetComponent(typeof(GenericCollision)))
                {

                    collide = (GenericCollision)hit.transform.gameObject.GetComponent(typeof(GenericCollision));
                    collide.isOn();
                    //Debug.Log("Hit, calling is on! " + collide);
                }
            }
        }
        else
        {
            //if it is no longer on a gameobject, call the prev gameobject and disable it
            if(collide != null)
            {
                //Debug.Log("Non, collide is off! " + collide);
                collide.isOff();
                collide = null; //so it doesn't repeat again if not on anything
            }
        }
    }
}
