using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class systemTime : MonoBehaviour
{
    Text text;
    System.DateTime time;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time = System.DateTime.Now;
        text.text = time.ToString("hh:mm:ss");
    }
}
