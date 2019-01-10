using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
	public float moveSpeed;
	public float sightRange;

	void Start () 
	{
		
	}

	void Update () 
	{
		RaycastHit hit;
		Physics.SphereCast (transform.position, sightRange, Vector3.up, out hit);
		//Debug.Log
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere (transform.position, sightRange);
	}
}
