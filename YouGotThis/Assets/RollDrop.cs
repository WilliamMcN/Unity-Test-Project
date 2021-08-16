using System;
using System.Collections.Generic;
using UnityEngine;

public class RollDrop : MonoBehaviour {

    public Renderer rend;
    public Items[] itemList = new Items[30];

    void Update()
    {
        setColor();
    }

    public void clear()
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            itemList[i] = null;
        }
    }
    public void callItems()
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i] != null)
            {
                Debug.Log(itemList[i].itemName);
            }
        }
    }
    public void addItem(Items item)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if(itemList[i] == null)
            {
                itemList[i] = item;
                i = itemList.Length;
            }
        }
        callItems();
    }


    public void setColor()
    {
        rend = GetComponent<Renderer>();
        int rarityColor = 0;
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i] != null)
            {
                if(rarityColor <= itemList[i].rarityCode)
                {
                    rarityColor = itemList[i].rarityCode;
                }
            }
        }
        Color newColor = Color.gray;
        if(rarityColor == 0)
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

        rend.sharedMaterial.color = newColor;

        Debug.Log("Color Change");
        callItems();
    }
}
