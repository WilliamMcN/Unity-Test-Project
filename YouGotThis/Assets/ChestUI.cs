using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUI : MonoBehaviour {

    public Transform itemsParent;
    ChestSlot[] slots;
    Chest chest;

    // Use this for initialization
    void Start()
    {
        chest = Chest.instance;
        chest.onChestChangeCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<ChestSlot>();
    }


    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < chest.Items.Count)
            {
                slots[i].AddItem(chest.Items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
    public List<Items> setChestInv()
    {
        List<Items> newList;
        newList = chest.Items;
        return newList;
    }

}
