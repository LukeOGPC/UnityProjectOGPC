using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]

public class PlayerController : MonoBehaviour 
{
	//----Define Variables----//
	private CharacterController cont;
	private Vector3 dir;
	public float moveSpeed;
	private Camera cam;
	public float jumpHeight;
	private GameObject model;

	void Start () 
	{
		model = GetComponentInChildren<MeshRenderer>().gameObject;
		cam = Camera.main; // Find the camera object
		cont = GetComponent<CharacterController>(); // Define the character controller
		model.transform.rotation = Quaternion.LookRotation(Vector3.up);
	}
	
	// Update is called once per frame
	void Update () 
	{
		dir = (cam.transform.forward * Input.GetAxis("Vertical")) + (cam.transform.right * Input.GetAxis("Horizontal"));
		dir.y = Physics.gravity.y;

		if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
			model.transform.rotation = Quaternion.LookRotation(dir);

		/*if(cont.isGrounded)
		{
			dir.y = 0;
			if(Input.GetButtonDown("Jump"))
			{
				dir.y += jumpHeight;
			}
		}*/

		if(Stats.CanMove)
			cont.Move(dir * Time.deltaTime * moveSpeed);
	}
}
