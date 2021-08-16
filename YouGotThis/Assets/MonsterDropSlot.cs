using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDropSlot : MonoBehaviour {

    Items item;
    public Image icon;
    public Button removeButton;
    public Button ItemsIcon;
    public MonsterDropUI dropUI;
    public GameObject dropObject;
    public InteractableDrop dropMenu;
    public MonsterDrop monsterDrop;


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
        Items setItem = item;
        bool isNotFull = Inventory.instance.Add(item);
        if (isNotFull == true)
        {
            ClearSlot();
            Debug.Log(setItem.itemName.ToString());
            Debug.Log(setItem.itemCode.ToString());
            dropMenu.removeItem(setItem);
            bool empty =  dropUI.CheckIfEmpty();
            Debug.Log(empty.ToString());
            
            if(empty == true)
            {
                dropMenu.CloseChest();
                Destroy(dropObject);
            }
        }
    }
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        ItemsIcon.interactable = false;
        //removeButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        monsterDrop.Remove(item);
    }
}
