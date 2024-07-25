using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{
    public Inventory inventory;

    public InventoryUI inventoryUI;

    public List<Item> ItemsList;

    bool DelMode=false;

    private void Start()
    {
        inventoryUI.UpdateUI(inventory);
    }

    private void Update()
    {
        string key = Input.inputString;
        if(key == ",")
            
        if (key == "D" || key == "d")
        {
            DelMode = !DelMode;
            Debug.Log("DelMode - " + DelMode);
        }
        else if(key != "")
        {
            int i = Convert.ToInt32(key)-1;
            if (i>=0 && i<=ItemsList.Count)
            {
                if (DelMode)
                    RemouteItem(i);
                else
                    AddItem(i);
            }
        }
    }

    void AddItem(int i)
    {
        if (i < ItemsList.Count)
        {
            Item newItem = ItemsList[i];
            inventory.Add(newItem);
            inventoryUI.UpdateUI(inventory);
        }
    }

    void RemouteItem(int i)
    {
        if (i < ItemsList.Count)
        {
            Item newItem = ItemsList[i];
            inventory.Remove(newItem);
            inventoryUI.UpdateUI(inventory);
        }
    }
}
