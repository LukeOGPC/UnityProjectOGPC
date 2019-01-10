using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum itemType
{
	smallCylinder,
	mediumCylinder,
	largeCylinder,
	hugeCylinder
}
	
public class AddToInventory : MonoBehaviour 
{
	public itemType typeOfItem;
	public int objectSize = 1; // How many inventory slots the object takes
	public GameObject pickUpIcon;
	public GameObject fullIcon;
	private GameObject ico;
	private PlayerController player;
	public float iconHeight = 1.0f;

	void Start () 
	{
		if(objectSize < 1)
			objectSize = 1;

		player = FindObjectOfType<PlayerController>();
	}

	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			if(ico != null && Input.GetButtonDown("Submit"))
			{
				if(Stats.InventorySlots >= objectSize)
				{
					UpdateStats ();
					Destroy(transform.gameObject);
					Destroy(ico);
				}
				else
				{

				}
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			if(ico == null)
			{
				if(Stats.InventorySlots >= objectSize)
				{
					ico = Instantiate(pickUpIcon);
					ico.transform.position = transform.position + (Vector3.up * iconHeight);
					ico.GetComponentInChildren<TextMesh>().text = "" + objectSize;
				}
				else
				{
					ico = Instantiate(fullIcon);
					ico.transform.position = transform.position + (Vector3.up * iconHeight);
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			if(ico != null)
			{
				Destroy(ico);
			}
		}
	}

	void UpdateStats ()
	{
		Stats.InventorySlots -= objectSize;
		Stats.NumberOfItemsInInventory += 1;

		if(typeOfItem == itemType.smallCylinder)
		{
			Stats.smallCylinders += 1;
			Debug.Log(Stats.smallCylinders + " Small Cylinders");
		}

		if(typeOfItem == itemType.mediumCylinder)
		{
			Stats.mediumCylinders += 1;
			Debug.Log(Stats.mediumCylinders + " Medium Cylinders");
		}

		if(typeOfItem == itemType.largeCylinder)
		{
			Stats.largeCylinders += 1;		
			Debug.Log(Stats.largeCylinders + " Large Cylinders");
		}

		if(typeOfItem == itemType.hugeCylinder)
		{
			Stats.hugeCylinders += 1;
			Debug.Log(Stats.hugeCylinders + " Huge Cylinders");
		}

	}
}
