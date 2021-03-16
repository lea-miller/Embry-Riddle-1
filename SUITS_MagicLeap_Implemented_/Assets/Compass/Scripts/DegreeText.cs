using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DegreeText : MonoBehaviour
{
    Vector3 headRot, headPos, normalV, northPos;
    private GameObject head, DegreeTextObj, CompDegText, compass, map;
    private Text CompassDegreeText;

    void Start()
    {
        head = GameObject.FindWithTag("MainCamera");
        DegreeTextObj = GameObject.FindWithTag("DegreeTextObject");

        CompDegText = GameObject.FindWithTag("DegreeText");
        CompassDegreeText = CompDegText.GetComponent<Text>();

        compass = GameObject.FindWithTag("Compass");

        map = GameObject.FindWithTag("Map");

        //normal vector to the xz plane
        normalV = new Vector3(0, 1, 0);
    }

    void Update()
    {
        //center degree text screen object above the head
        rotateDegreeTextObj();

        //vector from origin to user
        headPos = head.transform.position;
        headPos.y = 0;

        //vector from origin to north - origin to user, resultant vector from user to north
        /*northPos = map.transform.forward;
        northPos.y = 0;
        Vector3 compassDir = northPos - headPos;*/

        Vector3 facingDir = DegreeTextObj.transform.forward;

        Vector3 compassDir = compass.transform.forward;

        float angle = Vector3.Angle(compassDir, -facingDir);
        float sign = Mathf.Sign(Vector3.Dot(normalV, Vector3.Cross(facingDir, compassDir)));
        float signedAngle = angle * sign;

        float headingAngle = (signedAngle + 180) % 360;

        headingAngle = 1 * (Mathf.RoundToInt(headingAngle / 1.0f));

        int displayAngle;
        displayAngle = Mathf.RoundToInt(headingAngle);

        //change text to string name for cardinal directions
        switch (displayAngle)
        {
            case 0:
                CompassDegreeText.text = " N ";
                break;
            case 360:
                CompassDegreeText.text = " N ";
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
                CompassDegreeText.text = headingAngle.ToString();
                break;
        }
    }

    //Torso Heading update function
    public void rotateDegreeTextObj()
    {
        headRot.y = head.transform.eulerAngles.y;
        DegreeTextObj.transform.eulerAngles = headRot;
    }
}
