using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userCollider : MonoBehaviour
{
    RaycastHit hit;
    private int counter = 1;
    public delegate void ScreenHitNotify();
    public static event ScreenHitNotify notifyScreenHit;

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
            //Checks the gameObject if it has a componenet that extends Collision Manager, if found it will then call the subclass and use the proper function call
            if (hit.transform.gameObject.TryGetComponent(typeof(CollisionManager), out Component component))
            {
                CollisionManager collide = (CollisionManager)hit.transform.gameObject.GetComponent(typeof(CollisionManager));
                collide.isOn();
                counter = 1;
            }
        }
        else
        {
            if(counter == 1) //Avoids unneeded callings
            {
                notifyScreenHit();
                counter = 0;
            }
        }
    }
}
