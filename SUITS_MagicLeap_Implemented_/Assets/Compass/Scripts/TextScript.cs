using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{

    public Transform Facing;
    public Text CompassDegreeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = Facing.transform.forward;
        forward.y = 0;

        float headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;
        headingAngle = 1 * (Mathf.RoundToInt(headingAngle / 1.0f));

        int displayAngle;
        displayAngle = Mathf.RoundToInt(headingAngle);

        switch (displayAngle)
        {
            case 0:
                CompassDegreeText.text = "N";
                break;
            case 360:
                CompassDegreeText.text = "N";
                break;
            case 45:
                CompassDegreeText.text = "NE";
                break;
            case 90:
                CompassDegreeText.text = "E";
                break;
            case 135:
                CompassDegreeText.text = "SE";
                break;
            case 180:
                CompassDegreeText.text = "S";
                break;
            case 225:
                CompassDegreeText.text = "SW";
                break;
            case 270:
                CompassDegreeText.text = "W";
                break;
            case 315:
                CompassDegreeText.text = "NW";
                break;
            default:
                CompassDegreeText.text = headingAngle.ToString ();
                break;
        }
    }
}
