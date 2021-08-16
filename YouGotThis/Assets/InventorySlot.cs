﻿
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    Items item;
    public Image icon;
    public Button removeButton;

    public void AddItem (Items newItem)
    {
        item = newItem;

        icon.sprite = item.itemImage;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }
}
