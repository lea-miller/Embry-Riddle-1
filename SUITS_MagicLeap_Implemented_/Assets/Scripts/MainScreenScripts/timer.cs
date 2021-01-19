using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    Text text;
    float theTime;
    string hours, minutes, seconds;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (text == null)
        {
            text = GetComponent<Text>();
            changeTime();
        }

    }

    // Update is called once per frame
    void Update()
    {
        changeTime();
    }

    private void changeTime()
    {
            text = GetComponent<Text>();
            theTime += Time.deltaTime * speed;
            hours = Mathf.Floor((theTime % 216000) / 3600).ToString("00");
            minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
            seconds = Mathf.Floor(theTime % 60).ToString("00");
            text.text = "T+" + hours + ":" + minutes + ":" + seconds;
    }

}
