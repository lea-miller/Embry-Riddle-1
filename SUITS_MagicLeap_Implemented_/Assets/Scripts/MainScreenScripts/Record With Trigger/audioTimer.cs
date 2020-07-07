using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class audioTimer
{
    private float startCounter;
    private readonly float endCount = 300; //seconds
    
    public float getEndCount()
    {
        return endCount;
    }

    public float getStartCount()
    {
        return startCounter;
    }

    public void setStartCount(float startCounter)
    {
        this.startCounter = startCounter + Time.deltaTime;
    }

}
