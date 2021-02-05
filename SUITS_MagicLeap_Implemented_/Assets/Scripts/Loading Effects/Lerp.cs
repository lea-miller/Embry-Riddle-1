using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    [SerializeField]
    private float lerp;
    [SerializeField]
    private float increment = 1f/300f;
    [SerializeField]
    private Transform start;
    [SerializeField]
    private Transform end;
    private float targetLerp = 2f;
    private float[] targetLerps = {0f,1f/3f,2f/3f,1f};
    [SerializeField]
    private int targetLerpPosition;
    private bool isClicked = false;
    private bool isForward = false;


    public float getLerpPos()
    {
        return targetLerpPosition;
    }
    
    public void Update()
    {
        if(isClicked)
        {
            if(this.lerp>targetLerp && isForward)
            {
                this.lerp = this.lerp - increment;
                transform.position = Vector3.Lerp(start.position,end.position, this.lerp);
            }
            else if(this.lerp<targetLerp && !isForward)
            {        
                this.lerp = this.lerp + increment;
                transform.position = Vector3.Lerp(start.position,end.position, this.lerp);
            }
        }
    }

    public void setLerp(bool isForward)
    {
        isClicked = true;
        this.isForward = isForward;
        if(isForward)
        {
            targetLerpPosition = (targetLerpPosition - 1)% targetLerps.Length; 
        }
        else
        {
            targetLerpPosition = (targetLerpPosition + 1)% targetLerps.Length;
        }
        targetLerp = targetLerps[targetLerpPosition];
    }

    //Occurs on the rest values for the first object to last object, vise versa
    public void instantLerp(bool isForward)
    {
        if(isForward)
        {
            targetLerpPosition = 3;
        }
        else
        {
            targetLerpPosition = 0;
        }

        targetLerp = targetLerps[targetLerpPosition];
        this.isForward = isForward;
        this.lerp = targetLerp;
        transform.position = Vector3.Lerp(start.position,end.position, this.lerp);
    }
}
