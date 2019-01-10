using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public enum tp
{
	slot,
	icon,
	master
}

public enum orent
{
	vertical,
	horizontal
}

public class InventoryManager : MonoBehaviour 
{
	public tp inventoryType;
	public int slotSize = 1;
	public orent slotOrientation;
	private bool inv = true;
	public GameObject inventory;
	private int items;
	public GameObject smallItem;
	private GameObject sI;
	public GameObject iconManager;

	void Start () 
	{
		
	}

	void Update () 
	{
		slotScript();
		iconScript();
		masterScript();
	}

	void slotScript ()
	{
		if(inventoryType == tp.slot)
		{
			
		}
	}

	void iconScript ()
	{
		if(inventoryType == tp.master)
		{
			if(items != Stats.NumberOfItemsInInventory)
			{
				sI = Instantiate(smallItem);
				sI.transform.parent = iconManager.transform;
				sI.transform.localScale = Vector3.one;
				items += 1;
			}
		}
	}

	void masterScript ()
	{
		if(inventoryType == tp.master)
		{
			if(Input.GetButtonDown("Inventory"))
			{
				Stats.CanMove = !inv;
				inventory.SetActive(inv);
				inv = !inv;
			}
		}
	}
}
