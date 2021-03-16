using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalleryManager : MonoBehaviour
{
    public List<TextMeshProUGUI> galleryListDisplay; //Must be set-up in the inspector!!!
    protected List<List<string>> galleryList;
    public List<SpriteRenderer> galleryImageDisplay; //Must be set-up in the inspector!!!
    public List<GameObject> btns;
    protected int pageCounter = 0;
    protected int limit = 0;

    //TODO: Must check index issue after trying to re-open a 2nd time
    public void updateGallery(List<List<string>> galleryList)
    {
        this.galleryList = galleryList;
        for(int i = 0; i<limit;i++)
        {
                if(((pageCounter*limit)+i) <= galleryList.Count-1)
                {
                    btns[i].SetActive(true);
                    galleryListDisplay[i].text = galleryList[(pageCounter*limit)+i][0];
                }
                else
                {
                    btns[i].SetActive(false); 
                    galleryListDisplay[i].text = ""; //When there is an index out of bounds   
                }
        }
    }

    public int getCount()
    {
        return pageCounter;
    }

    public List<List<string>> getGalleryList()
    {
        return galleryList;
    }

    //Default Image with the folder names
    public void updateGalleryFolder( List<string> list)
    {
        for(int i = 0; i<limit;i++)
        {
                if(((pageCounter*limit)+i) <= list.Count-1)
                {
                    btns[i].SetActive(true);
                    galleryListDisplay[i].text = list[i];
                    Sprite sprite = Resources.Load<Sprite>("Sprites/ui-open");
                    galleryImageDisplay[i].sprite = sprite;
                }
                else
                {
                    //galleryListDisplay[i].text = ""; //When there is an index out of bounds
                    btns[i].SetActive(false);    
                }
        }
    }

    //Update the images
    public void updateGalleryImage(List<string> list)
    {
        int end = list.Count-1;
        if(list.Count == 0){end = 0;}

         for(int i = 0; i<limit;i++)
        {
                if(((pageCounter*limit)+i) <= end)
                {
                    btns[i].SetActive(true);
                    Sprite sprite = Resources.Load<Sprite>(list[i]);
                    galleryImageDisplay[i].sprite = sprite;
                     
                    //Debug.Log(list[i]);
                }
                else
                {
                    //galleryImageDisplay[i].sprite = null; //When there is an index out of bounds
                    btns[i].SetActive(false);   
                }

                //galleryImageDisplay[i].sprite = Resources.Load<Sprite>("SciGallery/TaskInstructions/Task1");
        }
    }
}
