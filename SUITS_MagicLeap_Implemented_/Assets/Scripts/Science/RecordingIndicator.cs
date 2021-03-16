using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordingIndicator : MonoBehaviour
{
    
    private audioRecord audioRecord;
    private float theTime;
    private SpriteRenderer indicator;

    // Start is called before the first frame update
    void Awake()
    {
        audioRecord = GameObject.FindGameObjectWithTag("FieldNote").GetComponent<audioRecord>();
        indicator = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        theTime += Time.deltaTime;

        if (audioRecord.isRecording)
        {
            flashRecordIndicator();
        }
        else
        {
            indicator.enabled = false;
        }
    }

    void flashRecordIndicator()
    {
        if (Mathf.Floor(theTime % 60) % 2 == 0)
        {
            indicator.enabled = false;
        }
        else
        {
            indicator.enabled = true;
        }
    }
}
