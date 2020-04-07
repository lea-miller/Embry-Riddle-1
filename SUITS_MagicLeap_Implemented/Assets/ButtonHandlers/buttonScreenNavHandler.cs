using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScreenNavHandler : MonoBehaviour
{
    public GameObject currentScreen, nextScreen;
    public void changeScreen()
    {
        nextScreen.SetActive(true);
        currentScreen.SetActive(false);
    }

}
