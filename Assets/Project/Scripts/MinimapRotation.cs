using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapRotation : MonoBehaviour 
{
	public Transform target;
	public Vector3 offset;

	void Update ()
	{
		transform.rotation = target.rotation;
		transform.position = target.transform.position + offset;
	}
}
