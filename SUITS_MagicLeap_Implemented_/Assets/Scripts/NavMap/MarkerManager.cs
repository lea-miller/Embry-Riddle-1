using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarkerManager: MonoBehaviour
{
    public int markerCount;
    public char letterCount;
    private GameObject localMap, compSys;
    private GameObject map;
    private float hue;
    public List<Marker> markerList;
    public Marker landerMarker;
    private GameObject Lander;
    private Transform Torso;

    private void Awake()
    {

        landerMarker = new Marker();
        markerCount = 0;
        letterCount = 'A';
        localMap = GameObject.FindGameObjectWithTag("LocalMap");
        map = GameObject.FindGameObjectWithTag("Map");
        Lander = GameObject.FindGameObjectWithTag("Lander");
        hue = 0;
        markerList = new List<Marker>();
        BuildLanderMarker();
        Debug.Log(landerMarker.Object);
        Torso = GameObject.FindGameObjectWithTag("Torso").transform;

        
        //markerManager = GameObject.FindWithTag("MiniMapSys").GetComponent<MarkerManager>();
        //markerList = markerManager.markerList;

        compSys = GameObject.FindWithTag("CompSys");

    }


    private void BuildLanderMarker()
    {
        landerMarker.Object = Lander;
        landerMarker.LetterName = "$";
        landerMarker.FullName = "Lander";
        landerMarker.Coords = Lander.transform.position;
        landerMarker.Color = Color.white;
        
    }

    public void NewMarkerPrefab(int index)
    {
        
        Vector3 coords = markerList[index].Coords;

        Vector3 vecZero = Vector3.zero;

        GameObject newMark = Instantiate(Resources.Load("MiniMapSys/Target")) as GameObject;
        newMark.name = "Target " + (markerList[index].LetterName);
        newMark.transform.SetParent(localMap.transform);
        newMark.transform.localPosition = coords;
        newMark.transform.localEulerAngles = vecZero;
        newMark.transform.Rotate(new Vector3(0, 180, 0));

        GameObject number = newMark.transform.Find("MapMarkerObject/MarkerNumber").gameObject;
        if (number ==null) { Debug.Log("MakerNumber object not found"); }
        TextMeshPro numberText = number.transform.GetComponent<TextMeshPro>();
        if (numberText == null) { Debug.Log("MakerNumber component not found"); }
        numberText.text = "" + (markerList[index].LetterName);

        
        Color color = Color.HSVToRGB(hue % 1, 1, 1);
        hue += 0.11f;
        GameObject cube = newMark.transform.Find("MapMarkerObject").gameObject;
        cube.GetComponentInChildren<Renderer>().material.color = color;

        GameObject newFullMark = Instantiate(cube);
        newFullMark.name = "FullMapMarkerObject ";
        newFullMark.transform.SetParent(newMark.transform);
        newFullMark.transform.localPosition = new Vector3(0,40,0);
        newFullMark.transform.localEulerAngles = vecZero;
        newFullMark.transform.localScale = new Vector3(17f, 17f, 17f);
        newFullMark.layer = 12;
        newFullMark.transform.Find("MarkerNumber").gameObject.layer = 12;
        Destroy(newFullMark.GetComponent<MapMarker>());

        markerList[index].Color = color;
        markerList[index].Object = newMark;


        /*Marker marker = new Marker();
        marker.Index = markerCount;
        marker.LetterName = letterCount;
        marker.FullName = "Site: " + letterCount;
        marker.Coords = coords;
        marker.Color = color;
        marker.Object = newMark;
        markerList.Add(marker);

        letterCount++;
        markerCount ++;*/

        //return marker.Index;
    }

    public void NewSampleMarkerPrefab()
    {
        Vector3 coords = Torso.position;
        coords.y = 0;
        Debug.Log(coords);

        GameObject newMark = Instantiate(Resources.Load("MiniMapSys/SampleMarker")) as GameObject;
        newMark.name = "SampleMarker";
        newMark.transform.SetParent(localMap.transform);
        newMark.transform.position = coords;
        Vector3 localCoords = newMark.transform.localPosition;
        localCoords.y = 0f;
        Debug.Log(localCoords);
        newMark.transform.localPosition = localCoords;
    }

    public void ImportMarkers( List<List<string>> markers)
    {
        int markIndex = 0;
        foreach( List<string> markerParams in markers)
        {
            int index = 0;
            Marker marker = new Marker();
            marker.Index = markIndex;
            Vector3 coords = Vector3.zero;
            foreach ( string param in markerParams)
            {
                Debug.Log(param);
                switch(index)
                {
                    case 0:
                        marker.LetterName = param;
                        break;
                    case 1:
                        marker.FullName = param;
                        break;
                    case 2:
                        marker.Description = param;
                        break;
                    case 3:
                        coords.x = float.Parse(param);
                        break;
                    case 4:
                        coords.z = float.Parse(param);
                        marker.Coords = coords;
                        break;
                }
                index++;

            }
            markerList.Add(marker);
            NewMarkerPrefab(markIndex);
            NewWaypointPrefab(markIndex);
            markIndex++;
        }
    }

    void NewWaypointPrefab(int index)
    {
        GameObject newWaypoint = Instantiate(Resources.Load("MiniMapSys/Waypoint")) as GameObject;
        newWaypoint.transform.SetParent(compSys.transform);
        newWaypoint.name = "Waypoint " + (markerList[index].LetterName);
        newWaypoint.GetComponentInChildren<Renderer>().material.color = markerList[index].Color;
        newWaypoint.GetComponentInChildren<waypointController>().target = markerList[index].Object;
        //Transform targetTrans = newWaypoint.GetComponentInChildren<Transform>().Find("targetPos");
        //GameObject target = targetTrans.gameObject;
        //target.transform.position = markerList[index].Coords;
    }
}


public class Marker
{
    public int Index;
    public string LetterName;
    public string FullName;
    public string Description;
    public Vector3 Coords;
    public GameObject Object;
    public Color Color;
    

}