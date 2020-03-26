using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackCanvasScreen : MonoBehaviour
{
    public GameObject currentScreen;
    private float rotation = 0.4f;
    private float initalY, finalY, defaultDistanceX, defaultDistanceY, defaultDistanceZ;
    private Vector3 currentScreenPosition;
    private Quaternion currentScreenRotation;
    private GameObject torso;
    void Start()
    {
        initalY = Camera.main.transform.rotation.y;
        torso = GameObject.FindWithTag("Torso");
    }
       

    // Update is called once per frame
    void Update()
    {
        rotationSync();
        
        //Checks the user's amount of head rotation
        finalY = Camera.main.transform.rotation.y;
        if (Mathf.Abs(finalY-initalY) > 0.50)
        {
            updateTorso();
        }
    }

    //The roation of the camera causes the current canvas to rotate without changing its position
    void rotationSync()
    {
        Vector3 currentScreenForward = Camera.main.transform.forward * rotation;
        currentScreen.transform.forward = currentScreenForward;
    }

    //Updates the torso rotation relative to the camera rotation
   public void updateTorso()
    {
        Quaternion torsoRot = Camera.main.transform.rotation;
        torso.transform.rotation = torsoRot;
        initalY = Camera.main.transform.rotation.y;
        finalY = Camera.main.transform.rotation.y;
    }

}
