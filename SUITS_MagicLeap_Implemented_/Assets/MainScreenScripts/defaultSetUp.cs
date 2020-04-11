using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultSetUp : MonoBehaviour
{
    private GameObject recordDisp, recordSel, mainScreen, loadScreen;
    
    void Awake()
    {
        recordDisp = GameObject.FindWithTag("Recording Display");
        recordSel = GameObject.FindWithTag("Recording Selection");
        mainScreen = GameObject.FindWithTag("Main Screen");
        loadScreen = GameObject.FindWithTag("Loading Screen");
    }

    void Start()
    {
        recordDisp.SetActive(false);
        recordSel.SetActive(false);
        mainScreen.SetActive(false);
        Invoke("changeMain", 6.0f);
    }

    private void changeMain()
    {
        mainScreen.SetActive(true);
        loadScreen.SetActive(false);
    }

}
