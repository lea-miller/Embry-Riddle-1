using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject homeScreen, vitalScreen, noteScreen, taskScreen;
    void Start()
    {
        homeScreen.SetActive(true);
        vitalScreen.SetActive(false);
        noteScreen.SetActive(false);
        taskScreen.SetActive(false);
    }
}
