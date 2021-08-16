using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InteractableDrop : MonoBehaviour {

    public Controls control;
    public Image Droppanel;
    public bool chestactive = false;
    public Renderer rend;
    public List<Items> itemList = new List<Items>();
    public MonsterDropUI drop;
    public bool isActive = false;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player has entered");
    }
    void Update()
    {
        setColor();
    }
    /*private void OnTriggerExit(Collider other)
    {
        Droppanel.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        chestactive = false;
        //drop.ClearAllSlots();
    }*/
    public void CloseChest()
    {
        Droppanel.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        chestactive = false;
        //drop.ClearAllSlots();
    }

    public void OpenDrop()
    {
        Droppanel.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        chestactive = true;
    }

    public void clear()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            itemList[i] = null;
        }
    }
    public void callItems()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i] != null)
            {
                Debug.Log(itemList[i].itemName);
            }
        }
    }
    public void addItem(Items item)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i] == null)
            {
                itemList[i] = item;
                i = itemList.Count;
            }
        }
        callItems();
    }


    public void setColor()
    {
        rend = GetComponent<Renderer>();
        int rarityColor = 0;
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i] != null)
            {
                if (rarityColor <= itemList[i].rarityCode)
                {
                    rarityColor = itemList[i].rarityCode;
                }
            }
        }
        Color newColor = Color.gray;
        if (rarityColor == 0)
        {
            newColor = Color.gray;
        }
        if (rarityColor == 1)
        {
            newColor = Color.green;
        }
        if (rarityColor == 2)
        {
            newColor = Color.blue;
        }
        if (rarityColor == 3)
        {
            newColor = Color.magenta;
        }
        if (rarityColor == 4)
        {
            newColor = Color.yellow;
        }

        rend.material.color = newColor;

        Debug.Log("Color Change");
        callItems();
    }
    private void OnTriggerStay(Collider other)
    {
        if (chestactive == false)
        {
            if (Input.GetKeyDown(control.interactKey))
            {

                Debug.Log("You have opened drop");
                for (int i = 0; i < itemList.Count; i++)
                {
                    if(itemList[i] == null)
                    {
                        i = itemList.Count;
                    }
                    else
                    {
                        if (isActive == false)
                        {
                            MonsterDrop.instance.Add(itemList[i]);
                        }
                    }
                    
                }
                isActive = true;
                OpenDrop();
                //setColor();
            }
        }
    }
    public void removeItem(Items newItem)
    {
        itemList.Remove(newItem);
        MonsterDrop.instance.Remove(newItem);
    }
}
