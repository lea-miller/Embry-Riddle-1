using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskViewOpen : MonoBehaviour
{
    public GameObject Button;

    public void MoveButton()
    {
        Debug.Log("Hello1!");
        if (Button != null)
        {
            Debug.Log("Hello!");
            Animator animator = Button.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("open");
                animator.SetBool("open", !isOpen);
            }
        }
    }
}
