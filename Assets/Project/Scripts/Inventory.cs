using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private bool inventoryEnabled;
	public GameObject inventory;
	public GameObject inventorySlot;

	private int allSlots;
	private int enabledSlots;
	private GameObject[] slot;

	public GameObject slotHolder;

	public GameObject pickUpIcon;
	public GameObject noRoomIcon;
	private GameObject icon;

	public AnimationClip inventoryIn;
	public AnimationClip inventoryOut;

	void Start ()
	{
		allSlots = 20;
		slot = new GameObject[allSlots];

		/*for(int i = 0; i < allSlots; i++)
		{
			slot[i] = slotHolder.transform.GetChild(i).gameObject;

			if(slot[i].GetComponent<InventorySlot>().item == null)
				slot[i].GetComponent<InventorySlot>().empty = true;
		}*/
	}

	void Update () 
	{
		if(Input.GetButtonDown("Inventory"))
		{
			Stats.CanMove = inventoryEnabled;
			inventoryEnabled = !inventoryEnabled;

			if(inventoryEnabled)
				StartCoroutine(slideIn());

			if(!inventoryEnabled)
				StartCoroutine(slideOut());
		}
	}

	IEnumerator slideIn()
	{
		inventory.SetActive(inventoryEnabled);
		inventory.GetComponent<Animator>().Play(inventoryIn.name);
		yield return new WaitForSeconds(inventoryIn.length);
	}

	IEnumerator slideOut()
	{
		inventory.GetComponent<Animator>().Play(inventoryOut.name);
		yield return new WaitForSeconds(inventoryOut.length);
		inventory.SetActive(inventoryEnabled);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Item")
		{
			if(allSlots - other.GetComponent<InventoryItem>().size >= 0 && icon == null)
			{
				icon = Instantiate(pickUpIcon);
				icon.GetComponentInChildren<TextMesh>().text = "" + other.GetComponent<InventoryItem>().size;
				icon.transform.position = other.transform.position + Vector3.up * other.GetComponent<InventoryItem>().uIHeight;
			}

			if(allSlots - other.GetComponent<InventoryItem>().size <= 0 && icon == null)
			{
				icon = Instantiate(noRoomIcon);
				icon.transform.position = other.transform.position + Vector3.up * other.GetComponent<InventoryItem>().uIHeight;
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Item" && Input.GetButtonDown("Submit"))
		{
			if(icon != null)
				Destroy(icon);
			
			GameObject itemPickedUp = other.gameObject;
			InventoryItem item = itemPickedUp.GetComponent<InventoryItem>();

			Stats.CanMove = inventoryEnabled;
			inventoryEnabled = !inventoryEnabled;

			inventory.SetActive(inventoryEnabled);

			if(inventoryEnabled)
				inventory.GetComponent<Animator>().Play(inventoryIn.name);
			
			AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon, item.itemSize);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "Item")
		{
			if(icon != null)
				Destroy(icon);
		}
	}

	void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon, Vector2 itemSize)
	{
		GameObject iSlot = Instantiate(inventorySlot);
		iSlot.transform.SetParent(slotHolder.transform);

		itemObject.GetComponent<InventoryItem>().pickedUp = true;

		iSlot.GetComponent<InventorySlot>().item = itemObject;
		iSlot.GetComponent<InventorySlot>().icon = itemIcon;
		iSlot.GetComponent<InventorySlot>().type = itemType;
		iSlot.GetComponent<InventorySlot>().ID = itemID;
		iSlot.GetComponent<InventorySlot>().description = itemDescription;
		iSlot.GetComponent<InventorySlot>().held = true;
		iSlot.GetComponent<InventorySlot>().size = itemSize;

		itemObject.transform.parent = iSlot.transform;
		itemObject.SetActive(false);

		iSlot.GetComponent<InventorySlot>().UpdateSlot();
		iSlot.GetComponent<InventorySlot>().empty = false;
	}
}
