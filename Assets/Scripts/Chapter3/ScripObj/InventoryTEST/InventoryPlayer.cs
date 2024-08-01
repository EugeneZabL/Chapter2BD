using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{
    public List<Inventory> InventoryList;

    public InventoryUI InventoryUI;

    public List<Item> ItemsList;

    bool DelMode=false;
    int NumberInventory = 0;

    private void Start()
    {
        InventoryUI.UpdateUI();
    }

    private void Update()
    {
        string key = Input.inputString;

        if (key == "D" || key == "d")
        {
            DelMode = !DelMode;
            Debug.Log("DelMode - " + DelMode);
        }
        else if(key == "S" || key == "s")
        {
            InventoryList[NumberInventory].Clear();
            Debug.Log("Inventory Clear");
            InventoryUI.UpdateUI();
        }
        else if(key == "N" || key == "n")
        {
            NMinus();
        }
        else if(key == "M" || key == "m")
        {
            NPlus();
        }
        else if(key == "L" || key == "l")
        {
            Loot();
        }
        else if(key != "")
        {
            try
            {
                int i = Convert.ToInt32(key) - 1;
                if (i >= 0 && i <= ItemsList.Count)
                {
                    if (DelMode)
                        RemouteItem(i);
                    else
                        AddItem(i);
                }
            }
            catch
            {
                Debug.LogError("CHANGE LANGUAGE!!");
            }
        }
    }

    void AddItem(int i)
    {
        if (i < ItemsList.Count)
        {
            Item newItem = ItemsList[i];
            InventoryList[NumberInventory].Add(newItem);
            InventoryUI.UpdateUI();
        }
    }

    void RemouteItem(int i)
    {
        if (i < ItemsList.Count)
        {
            Item newItem = ItemsList[i];
            InventoryList[NumberInventory].Remove(newItem);
            InventoryUI.UpdateUI();
        }
    }

    public void NMinus()
    {
        if(NumberInventory>0)
        NumberInventory--;

        InventoryUI.inventory = InventoryList[NumberInventory];
        InventoryUI.UpdateUI();
    }

    public void NPlus()
    {
        if(InventoryList.Count-2>=NumberInventory)
        NumberInventory++;

        InventoryUI.inventory = InventoryList[NumberInventory];
        InventoryUI.UpdateUI();
    }
    
    public void Loot()
    {
        if(NumberInventory!=0)
        {
            InventoryList[0].Add(InventoryList[NumberInventory]);
            InventoryUI.UpdateUI();
        }
    }
}
