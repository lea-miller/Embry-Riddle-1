using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NavManager : MonoBehaviour
{
    private NavPlayer NavPlayer;
    private NavPlayerLander NavPlayerLander;
    private MarkerManager MarkerManager;
    public Marker CurrentTarget;
    public Marker landerMarker;
    public double distance, landerDistance;
    public double ETA, landerETA;
    private List<List<string>> markerImport;

  

    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        
        NavPlayer = GameObject.FindGameObjectWithTag("NavPlayer").GetComponent<NavPlayer>();
        NavPlayerLander = GameObject.FindGameObjectWithTag("NavPlayerLander").GetComponent<NavPlayerLander>();
        MarkerManager = GetComponent<MarkerManager>();
        markerImport = GetComponent<MarkerCSVReader>().getMarkers();
        MarkerManager.ImportMarkers(markerImport);
        landerMarker = MarkerManager.landerMarker;




    }

    // Update is called once per frame
    void Update()
    {
        distance = Math.Round(NavPlayer.getDistanceToTarget(), 1);
        //Avg walking speed 1.4 m/s
        ETA = Math.Round(distance * 1.4/ 60, 0);

        landerDistance = Math.Round(NavPlayerLander.getDistanceToTarget(), 1);
        //Avg walking speed 1.4 m/s
        landerETA = Math.Round(landerDistance * 1.4 / 60, 0);
  
    }

    public void setCurrentTarget(Marker marker)
    {
        NavPlayer.setTarget(marker.Object.transform);
        CurrentTarget = marker;

    }

    public void setCurrentTargetHome()
    {
        setCurrentTarget(landerMarker);
        CurrentTarget = landerMarker;
    }

   

}
