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

    public bool isClickDown = false;
    private bool isComplete = false;
    private bool isSkip = false;
    private bool isIncomplete = false;

    private Color finalColor;

    [SerializeField]
    private float lerp;

    public float speed = 1.0f;


    //Lerp Direction
    bool LerpedUp = false;
    //Lerp time value
    public float LerpTime;

    void Update()
    {

        //If Hold,Move Lerp forward  
        if (isClickDown)
        {
            if (!LerpedUp)
            {
                //Reset LerpTime
                lerp = 0.0f;
                //State Lerping Up(A to B)
                LerpedUp = true;
            }
            else if (lerp < 1.0f)
            {
                myRenderer.color = Color.Lerp(myRenderer.color, finalColor, lerp);
                lerp += Time.deltaTime / LerpTime;
            }

        }
        else//If released, Move backward
        {
            if (LerpedUp)
            {
                //Reset LerpTime
                lerp = 0.0f;
                //State Lerping Down(B to A)
                LerpedUp = false;
                resetColor();
            }
            else if (lerp < 1.0f)
            {
                resetColor();
                lerp += Time.deltaTime / LerpTime;
            }

        }
    }

    public void changeColorToComplete()
    {
        
        isComplete = true;
        finalColor = complete;
        //myRenderer.color = Color.Lerp(myRenderer.color, complete, lerp);
    }

    public void changeColorToSkip()
    {
        isSkip = true;
        finalColor = skip;
        //myRenderer.color = Color.Lerp(myRenderer.color, skip, lerp);
    }

    public void changeColorToIncomplete()
    {
        isIncomplete = true;
        finalColor = incomplete;
        //myRenderer.color = Color.Lerp(myRenderer.color, incomplete, lerp);
    }

    public void resetColor()
    {
        isComplete = false;
        isSkip = false;
        isIncomplete = false;
        myRenderer.color = Color.Lerp(myRenderer.color, defColor, .1f);
    }
}
