using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NavDisplayManager : MonoBehaviour
{
    private NavManager NavManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject mapSys = GameObject.FindGameObjectWithTag("MiniMapSys");
        NavManager = mapSys.GetComponent<NavManager>();

    }

    // Update is called once per frame
    void Update()
    {
        RefeshDisplay();
    }

    void RefeshDisplay()
    {
        updateCurrentDestinationDisplay();
        updateHomeButton();
    }

    void updateHomeButton()
    {
        TextMeshPro info = GameObject.FindGameObjectWithTag("HomeDistanceInfoText").GetComponent<TextMeshPro>();
        info.text = "Distance: " + NavManager.landerDistance + "m" + "\n" + "ETA: +" + NavManager.landerETA + "min";
    }

    void updateCurrentDestinationDisplay()
    {

        TextMeshPro letter = GameObject.FindGameObjectWithTag("CurrentDestinationLetterText").GetComponent<TextMeshPro>();
        TextMeshPro title = GameObject.FindGameObjectWithTag("CurrentDestinationText").GetComponent<TextMeshPro>();
        TextMeshPro info = GameObject.FindGameObjectWithTag("CurrentDestinationInfoText").GetComponent<TextMeshPro>();
        Image block = GameObject.FindGameObjectWithTag("DestinationColorBlock").GetComponent<Image>();
        if (NavManager.CurrentTarget != null)
        {
            letter.text = NavManager.CurrentTarget.LetterName;
            title.text = "Target: " + NavManager.CurrentTarget.FullName;
            info.text = "Distance: " + NavManager.distance + "m" + "   ETA: +" + NavManager.ETA + "min";
            Color lightColor = NavManager.CurrentTarget.Color;
            float H, S, V;
            Color.RGBToHSV(lightColor, out H, out S, out V);
            lightColor = Color.HSVToRGB(H, S, V - .5f);

            //lightColor.a = 0.1f;
            block.color = lightColor;

        }
        else
        {
            title.text = "No Waypoint Set";
            info.text = "";
            block.color = Color.gray;
        }

    }
}
