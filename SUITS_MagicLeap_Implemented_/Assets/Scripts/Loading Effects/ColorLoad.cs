using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorLoad : MonoBehaviour
{
    [SerializeField]
    private Image  myRenderer;
    [SerializeField]
    private Color defColor;
    [SerializeField]
    private Color complete;
    [SerializeField] 
    private Color skip;
    [SerializeField] 
    private Color incomplete;

    private bool isComplete = false;
    private bool isSkip = false;
    private bool isIncomplete = false;

    [SerializeField]
    private float lerp;

    void Update()
    {
        if(myRenderer.color == complete  || myRenderer.color == skip || 
            myRenderer.color == incomplete)
        {
            resetColor();
        }
        else if(isComplete)
        {
            changeColorToComplete();
        }
        else if (isSkip)
        {
            changeColorToSkip();
        }
        else if(isIncomplete)
        {
            changeColorToIncomplete();
        }
    }

    public void changeColorToComplete()
    {
        //Debug.Log("Change method! " + myRenderer.material.color + " equal to ? " + complete);
        isComplete = true;
        myRenderer.color = Color.Lerp(myRenderer.color, complete, lerp);
    }

    public void changeColorToSkip()
    {
        isSkip = true;
        myRenderer.color = Color.Lerp(myRenderer.color, skip, lerp);
    }

    public void changeColorToIncomplete()
    {
        isIncomplete = true;
        myRenderer.color = Color.Lerp(myRenderer.color, incomplete, lerp);
    }

    public void resetColor()
    {
        isComplete = false;
        isSkip = false;
        isIncomplete = false;
        myRenderer.color = Color.Lerp(myRenderer.color, defColor, 100);
    }
}
