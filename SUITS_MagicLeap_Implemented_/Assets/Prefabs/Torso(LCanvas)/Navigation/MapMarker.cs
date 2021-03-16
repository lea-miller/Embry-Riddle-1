using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMarker : MonoBehaviour
{

	private Camera MinimapCam;
	private float MinimapSize;
	private Transform torso;
	Vector3 TempV3;
	private float markHeight;


    private void Start()
    {
		MinimapCam = GameObject.FindGameObjectWithTag("MiniMapCam").GetComponent<Camera>();
		torso = GameObject.FindGameObjectWithTag("Torso").transform;
    }

    void Update()
	{
		markHeight = (MinimapCam.transform.position.y / 2);
		TempV3 = transform.parent.transform.position;
		TempV3.y = markHeight;
		transform.position = TempV3;
		MinimapSize = MinimapCam.orthographicSize;
		MinimapSize -= MinimapSize * (2f / 30); //Determines how markers lay on edge of minimap
		transform.localScale = Vector3.one * MinimapSize* 0.4f;
		transform.eulerAngles = new Vector3(0, torso.eulerAngles.y, 0);
	}

	void LateUpdate()
	{
		// Center of Minimap
		Vector3 centerPosition = MinimapCam.transform.position;

		// Just to keep a distance between Minimap camera and this Object (So that camera don't clip it out)
		centerPosition.y = markHeight;
	
		// Distance from the gameObject to Minimap
		float Distance = Vector3.Distance(transform.position, centerPosition);

		// If the Distance is less than MinimapSize, it is within the Minimap view and we don't need to do anything
		// But if the Distance is greater than the MinimapSize, then do this
		if (Distance > MinimapSize)
		{
			// Gameobject - Minimap
			Vector3 fromOriginToObject =   (transform.parent.transform.position - centerPosition);

			//Nick's Crap code
            /*Vector3 tempPos = centerPosition + Vector3.ClampMagnitude(fromOriginToObject, MinimapSize);
			tempPos.y = MinimapCam.transform.position.y - (markHeight);
			transform.position = tempPos;*/

           
			//Good code
            // Multiply by MinimapSize and Divide by Distance
            fromOriginToObject *= MinimapSize/Distance;

            // Minimap + above calculation
            transform.position = centerPosition + fromOriginToObject;

        }
    }
}
