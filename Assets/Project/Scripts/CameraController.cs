using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	//----Define Variables----//
	private PlayerController player;
	public float rotateSpeed = 75.0f;
	public float heightClamp = 60.0f;

	[HideInInspector]
	public GameObject camPivot;
	public float height = 1.0f;
	public float distance = 7.0f; //Distance from player

	private float xClip;
	private float yClip;
	private float zClip;

	void Start () 
	{
		player = FindObjectOfType<PlayerController>();
		camPivot = new GameObject("Camera Pivot");
	}

	void Update () 
	{
		if(Stats.CanMove)
		{
			MoveCamera();
			RotateCamera();
			DetectClip();
			UpdateCamera();
		}
	}

	void MoveCamera()
	{
		camPivot.transform.position = player.gameObject.transform.position + Vector3.up * height; // Set Camera Pivot's position to 'height' above the player's position
	}

	void RotateCamera()
	{
		camPivot.transform.Rotate(new Vector3(0, Input.GetAxis("CHorizontal") * rotateSpeed * Time.deltaTime, 0), Space.World); // Rotate the Camera Pivot Horizontaly

		camPivot.transform.Rotate(new Vector3(-Input.GetAxis("CVertical") * rotateSpeed * Time.deltaTime, 0, 0)); // Rotate the Camera Pivot verticaly

		if(camPivot.transform.rotation.eulerAngles.x > heightClamp && camPivot.transform.rotation.eulerAngles.x < 180)
		{
			camPivot.transform.rotation = Quaternion.Euler(heightClamp, camPivot.transform.rotation.eulerAngles.y, camPivot.transform.rotation.eulerAngles.z); // Prevent the camera from rotating over the player
		}

		if(camPivot.transform.rotation.eulerAngles.x < 360 - heightClamp && camPivot.transform.rotation.eulerAngles.x > 180)
		{
			camPivot.transform.rotation = Quaternion.Euler(360 - heightClamp, camPivot.transform.rotation.eulerAngles.y, camPivot.transform.rotation.eulerAngles.z); // Prevent the camera from rotating under the player
		}
	}

	void DetectClip ()
	{
		zClip = GetComponent<Camera>().nearClipPlane;
		xClip = Mathf.Tan(GetComponent<Camera>().fieldOfView / 2 * Mathf.Deg2Rad) * zClip; 
		yClip = xClip / GetComponent<Camera>().aspect;

		Debug.DrawLine(transform.localPosition + new Vector3(xClip, yClip, zClip), player.transform.position);
		Debug.DrawLine(transform.localPosition + new Vector3(-xClip, -yClip, zClip), player.transform.position);
		Debug.DrawLine(transform.localPosition + new Vector3(-xClip, yClip, zClip), player.transform.position);
		Debug.DrawLine(transform.localPosition + new Vector3(xClip, -yClip, zClip), player.transform.position);
	}

	void UpdateCamera()
	{
		transform.position = camPivot.transform.position - camPivot.transform.forward * distance; // Set the cameras position to 'distance' units behind the Pivot
		transform.LookAt(player.transform.position + Vector3.up * height); // Make the camera look at the player
	}
}
