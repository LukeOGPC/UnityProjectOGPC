using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler 
{
	[HideInInspector]
	public GameObject item;

	[HideInInspector]
	public int ID;

	[HideInInspector]
	public string type;

	[HideInInspector]
	public string description;

	[HideInInspector]
	public bool empty;

	[HideInInspector]
	public Sprite icon;

	[HideInInspector]
	public bool held;

	[HideInInspector]
	public Vector2 size;

	public bool clickable;
    public bool box1;
    public bool box2;
    public bool box3;
    public bool box4;
    public bool box5;
    public bool box6;
    public bool box7;
    public bool box8;
    public bool box9;
    public bool box10;
    public bool box11;
    public bool box12;
    public bool box13;
    public bool box14;
    public Collider box1c;
    public Collider box2c;
    public Collider box3c;
    public Collider box4c;
    public Collider box5c;

    box1c = GetComponent<box1>();
    public GameObject UITile;
	private GameObject background;

	private Vector3 inventorySlotPosition;

	void Start ()
	{
		transform.rotation = Quaternion.Euler(Vector3.zero);
	}

	void Update ()
	{
		if(held)
		{
			if(Input.GetButtonDown("RightTrigger"))
			{
				transform.Rotate(Vector3.forward * 90);
			}

			if(Input.GetButtonDown("LeftTrigger"))
			{
				transform.Rotate(Vector3.forward * -90);
			}

			transform.position = Input.mousePosition;
		}
		else
		{
			transform.localPosition = inventorySlotPosition;
		}
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if(background != null)
			Destroy(background);
		
		if(held)
		{
		
			inventorySlotPosition = new Vector3(transform.localPosition.x/* + x + x + x / 4*/, transform.localPosition.y/* + y + y + y / 4*/, 0);
		}
        TakenS();
        if (clickable)
        { 
		held = !held;
        TakeS();
         }
	}

	public void UpdateSlot()
	{
		this.GetComponent<Image>().sprite = icon;
		this.GetComponent<RectTransform>().localScale = new Vector3((size.x * 50) + (10 * (size.x - 1)), (size.y * 50) + (10 * (size.y - 1)), 0);
	} 

	public void TakenS()
	{
        if ((box1 == false) )
        {
            clickable = false;
        }
        else if ((box2 == false))
        {
            clickable = false;
        }
        else if ((box3 == false))
        {
            clickable = false;
        }
        else
        {
            clickable = true;

        }
	}
    public void TakeS()
    {
        if ((box1c))
        {
            box1 = false;
        }
    }
    void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position, transform.localScale);
	}
}










