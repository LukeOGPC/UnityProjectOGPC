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
    private bool clickable;
    private bool box1Coll;
    private bool ntaken;
    public GameObject UITile;
    private GameObject background;
    private Vector3 inventorySlotPosition;
    void Start()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    void Update()
    {
        if (held)
        {
            if (Input.GetButtonDown("RightTrigger"))
            {
                transform.Rotate(Vector3.forward * 90);
            }
            if (Input.GetButtonDown("LeftTrigger"))
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
        if (background != null)
            Destroy(background);
       
       
        if (clickable)
        {
            if (held)
            {
                Drop();
                inventorySlotPosition = new Vector3(transform.localPosition.x/* + x + x + x / 4*/, transform.localPosition.y/* + y + y + y / 4*/, 0);
            }
            held = !held;
            ntaken = !ntaken;
        }
    }
    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
        this.GetComponent<RectTransform>().localScale = new Vector3((size.x * 50) + (10 * (size.x - 1)), (size.y * 50) + (10 * (size.y - 1)), 0);
    }
    public void Drop()
    {
        /*background = Instantiate(UITile);
        background.transform.position = this.GetComponent<RectTransform>().localPosition;
        background.transform.localScale = this.GetComponent<RectTransform>().localScale;
        background.transform.parent = this.transform;
        Collider[] c = Physics.OverlapBox(transform.position, transform.localScale / 2, transform.rotation);
        Debug.Log(c.Length);
        for(int i = 0; i < c.Length; i++)
        {
         Debug.Log(c.GetValue(i));
        }*/
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ntaken == false)
            {
                clickable = !clickable;
            }
            else
            {
                clickable = true;
            }
            Debug.Log("Triggered");
        }
    }

}
