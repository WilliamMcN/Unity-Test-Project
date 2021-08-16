using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestSlot : MonoBehaviour {

    Items item;
    public Image icon;
    public Button removeButton;
    public Button ItemsIcon;
    public ChestUI chestUI;
    public InteractableChest chest;
    public GameObject chestObject;

    public void AddItem(Items newItem)
    {
        item = newItem;

        icon.sprite = item.itemImage;
        icon.enabled = true;
        ItemsIcon.interactable = true;
        //removeButton.interactable = true;
    }

    public void AddToInventory()
    {
        bool isNotFull = Inventory.instance.Add(item);
        if(isNotFull == true)
        {
            //ClearSlot();
            OnRemoveButton();
        }
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        ItemsIcon.interactable = true;
        //removeButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        Chest.instance.Remove(item);
    }
}
