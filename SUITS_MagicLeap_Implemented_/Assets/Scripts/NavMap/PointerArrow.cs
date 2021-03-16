using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerArrow : MonoBehaviour
{
	public Transform Target;
	public Transform Torso;
	public Transform TorsoHeading;
	private Vector3 TargetPos;
	private Vector3 TorsoPos;
	private Vector3 TorsoHeadingPos;

	void Awake()
    {
		TargetPos = Target.position;
		TorsoPos = Torso.position;
		TorsoHeadingPos = TorsoHeading.position;
		Debug.Log(TargetPos);

	}
	void Update()
	{
		TargetPos = Target.position;
		TorsoPos = Torso.position;
		TorsoHeadingPos = TorsoHeading.position;
		TargetPos.y = 0f;
		TorsoPos.y = 0f;
		TorsoHeadingPos.y = 0;
		Vector3 heading = (TorsoHeadingPos - TorsoPos).normalized;
		Debug.DrawRay(Torso.position, heading, Color.green);
		Vector3 dir = (TargetPos - TorsoPos);
		Debug.DrawRay(Torso.position, dir, Color.red);
		Vector3 axis = Vector3.down;

		dir = Vector3.forward;

		Debug.DrawRay(Torso.position, axis, Color.blue);
		//float angle = (Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg) % 360;
		float angle = Vector3.SignedAngle(heading, dir, axis);
		transform.localEulerAngles = new Vector3(0, 0, -angle);
	}

	
}

