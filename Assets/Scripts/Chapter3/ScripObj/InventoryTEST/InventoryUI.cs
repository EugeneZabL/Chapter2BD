using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform itemsParent;
    public GameObject inventorySlotPrefab;

    public TextMeshProUGUI InvName;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        // Очистить существующий UI
        foreach (Transform child in itemsParent)
        {
            Destroy(child.gameObject);
        }

        // Заполнить UI элементами инвентаря
        foreach (InventoryItem inventoryItem in inventory.Items)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, itemsParent);
            Image icon = slot.transform.GetChild(0).GetComponent<Image>();
            icon.sprite = inventoryItem.itemData.icon;

            TextMeshProUGUI itemName = slot.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            itemName.text = inventoryItem.itemData.itemName;

            TextMeshProUGUI stackAmount = slot.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            if (inventoryItem.itemData.isStackable)
            {
                stackAmount.text = "x" + inventoryItem.amount.ToString();
            }
            else
            {
                stackAmount.text = "";
            }
            
        }

        InvName.text = inventory.InventoryName;
    }
}