using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour 
{
	public int ID;
	public float uIHeight = 1;
	public string type;
	public string description;
	public Sprite icon;

	public bool stackable;

	[HideInInspector]
	public bool pickedUp;

	[HideInInspector]
	public int size = 1;

	public Vector2 itemSize;

	[HideInInspector]
	public bool equiped;

	[HideInInspector]
	public GameObject weapon;

	[HideInInspector]
	public GameObject weaponManager;

	[HideInInspector]
	public bool playersWeapon;

	public void Start()
	{
		weaponManager = GameObject.FindWithTag("WeaponManager");

		if(!playersWeapon)
		{
			int allWeapons = weaponManager.transform.childCount;
			for(int i = 0; i < allWeapons; i++)
			{
				if(weaponManager.transform.GetChild(i).gameObject.GetComponent<InventoryItem>().ID == ID)
				{
					weapon = weaponManager.transform.GetChild(i).gameObject;
				}
			}
		}

		size = Mathf.RoundToInt(itemSize.x * itemSize.y);
	}

	public void Update()
	{
		if(equiped)
		{

		}
	}

	public void ItemUsage()
	{
		if(type == "Weapon")
		{
			weapon.SetActive(true);
			equiped = true;
		}
	}
}
