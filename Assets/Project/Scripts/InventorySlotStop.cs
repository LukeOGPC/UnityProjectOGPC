﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventorySlotStop : MonoBehaviour {

    private bool clickable;
    private bool box1Coll;
    private bool ntaken;
    // Update is called once per frame
    void Update ()
    {
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
}