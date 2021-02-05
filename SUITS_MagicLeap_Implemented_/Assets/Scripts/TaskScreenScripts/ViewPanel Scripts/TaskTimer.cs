using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskTimer : MonoBehaviour
{
    public TextMeshProUGUI text;
    float theTime;
    string hours, minutes, seconds;
    public float speed = 1;
    private int nextTask;
    private bool overTime;
    TaskScreenManager taskScreen;


    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        taskScreen = GameObject.FindWithTag("TaskScreen").GetComponent<TaskScreenManager>();
        nextTask = taskScreen.getTaskCounter() + 1;
        text = GameObject.FindGameObjectWithTag("ElapsedDuration").GetComponent<TextMeshProUGUI>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (hours + ":" + minutes == taskScreen.getCurrentTask()[2])
        {
            text.color = Color.red;
            overTime = true;
        }
        changeTime();
    }

    private void changeTime()
    {
        
        theTime += Time.deltaTime * speed;
        hours = Mathf.Floor((theTime % 216000) / 3600).ToString("0");
        minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
        //seconds = Mathf.Floor(theTime % 60).ToString("00");
        string sign = "-";
        if(overTime)
        {
            sign = "+";
        }
        if(Mathf.Floor(theTime % 60)%2 == 0)
        { 
        text.text = sign + hours + ":" + minutes; //+ ":" + seconds;
        }
        else
        {
        text.text = sign + hours + " " + minutes; //+ ":" + seconds;
        }
    }

     public void resetTimer() //reset task timer on next Task
        {
            
            theTime = 0;
            text.color = Color.green; 
            nextTask = taskScreen.getTaskCounter() + 1;
            overTime = false;

        }

}
