using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionAppBar : GenericCollision
{
    private Image appBorder;
    public GameObject topPanel { get; set; }
    public GameObject mainScreen { get; set; }
    public LinkedList<GameObject> screenObjectList;
    public List<GameObject> iconObjectList;

    //No wake incase list isn't made yet

        void Awake()
        {
            appBorder = GameObject.FindWithTag("AppBar").GetComponent<Image>();
            topPanel = GameObject.FindWithTag("TopLCanvas");
            mainScreen = GameObject.FindWithTag("MainScreenTopPanel"); 
        }
   
    void Start()
    {
        LinkedList<GameObject> screenObjectList = GameObject.FindWithTag("AppBar").GetComponent<ControlAppBar>().screenObjectList;
        iconObjectList = new List<GameObject>();
        iconObjectList.Add(GameObject.FindWithTag("TaskIcon"));
        iconObjectList.Add(GameObject.FindWithTag("NavIcon"));
        iconObjectList.Add(GameObject.FindWithTag("ScienceIcon"));
        iconObjectList.Add(GameObject.FindWithTag("MediaIcon"));    
        isOff();
    }

    public override void isOn()
    {
        appBorder.enabled = true;
        topPanel.SetActive(true);
        mainScreen.SetActive(false);
    }

    public override void isOff()
    {
        appBorder.enabled = false;
        topPanel.SetActive(false);
        mainScreen.SetActive(true);
        //handleIconObjects(); TODO
    }

     private void handleIconObjects()
    {
        var  screen = screenObjectList.First;
        var tempScreen = screen.Value.name;
        
        for(int j = 0; j<screenObjectList.Count-1;j++)
        {
            for(int i = 0; i<screenObjectList.Count-1;i++)
            {
                if(tempScreen == iconObjectList[i].name)
                {    
                    if(j == 0)
                    {
                        iconObjectList[i].SetActive(true);
                    }else
                    {
                        iconObjectList[i].SetActive(false);
                    }
                    screen = screen.Next;
                    tempScreen = screen.Value.name;
                }
           }  
        } 
    }
}
