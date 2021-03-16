using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleTracker : ControlCommands
{

    List<Sprite> sampleList;
    public List<Image> sampleListDisplayed;
    private int count = 0;
    private int imageLimit;
    public Sprite defaultSprite;

    void Awake()
    {
        //Get Sample list
        sampleList = new List<Sprite>();
        sampleListDisplayed = new List<Image>();
        
    }

    void Start()
    {
        imageLimit = sampleListDisplayed.Count;
    }

    public override void bumperHold()
    {
        
    }

    public override void bumperUp()
    {
        removeCount();
    }

      public override void triggerHold()
    {

    }

    public override void triggerUp()
    {
        addCount();
    }

    private void moveSample()
    {
        for(int i = 0; i<imageLimit;i++)
        {
             try
             {
                 sampleListDisplayed[i].sprite = sampleList[count-imageLimit+i];
             }
             catch (System.IndexOutOfRangeException ex)
             {
                 sampleListDisplayed[i].sprite = defaultSprite; //When there is an odd number
             }
             
        }
    }

    private void addCount()
    {
        if(count<=sampleList.Count)
        {
            count = count + imageLimit;
        }
    }

    private void removeCount()
    {
        if(count != 0)
        {
            count = count - imageLimit;
        }
    }

}
