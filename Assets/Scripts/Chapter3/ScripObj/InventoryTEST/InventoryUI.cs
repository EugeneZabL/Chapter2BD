using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventorySlotPrefab;

    [SerializeField]
    private TextMeshProUGUI _name;

    public void UpdateUI(Inventory inventory)
    {
        // Очистить существующий UI
        foreach (Transform child in itemsParent)
        {
            Destroy(child.gameObject);
        }

        _name.text = inventory.InventoryName;

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
    }
}