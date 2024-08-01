using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class InventoryItem
{
    public Item itemData;
    public int amount;

    public InventoryItem(Item itemData, int amount)
    {
        this.itemData = itemData;
        this.amount = amount;
    }
}

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField]
    private string inventoryName;
    public string InventoryName { get { return inventoryName; } }

    [SerializeField]
    private List<InventoryItem> items = new List<InventoryItem>();

    public List<InventoryItem> Items { get { return items; } }

    public void Add(Item item)
    {
        // Проверка, существует ли уже элемент в инвентаре
        InventoryItem existingItem = items.Find(i => i.itemData.itemName == item.itemName);
        if (existingItem != null && item.isStackable)
        {
            existingItem.amount += 1;  // Обновляем количество
        }
        else
        {
            if (items.Count < 10)
            {
                items.Add(new InventoryItem(item, 1));
            }
            else
                Debug.Log("BackPackIsFULL");
        }
    }

    public void Add(Item item, int amount)
    {
        for(int i = 0; i<=amount; i++)
        {
            InventoryItem existingItem = items.Find(i => i.itemData.itemName == item.itemName);
            if (existingItem != null && item.isStackable)
            {
                existingItem.amount += 1;  // Обновляем количество
            }
            else
            {
                if (items.Count < 10)
                {
                    items.Add(new InventoryItem(item, 1));
                }
                else
                    Debug.Log(item.itemName + " - is dropped.");
            }
        }
    }

    public void Remove(Item item)
    {
        InventoryItem existingItem = items.Find(i => i.itemData.itemName == item.itemName);
        if (existingItem != null)
        {
            existingItem.amount -= 1;
            if (existingItem.amount <= 0)
            {
                items.Remove(existingItem);
            }
        }
    }

    public void Clear()
    {
        items.Clear();
    }

    public void Add(Inventory Inv)
    {
        foreach(InventoryItem item in Inv.Items)
        {
            Add(item.itemData,item.amount-1);
        }
    }
}