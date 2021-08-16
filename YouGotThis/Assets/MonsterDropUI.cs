using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDropUI : MonoBehaviour {

    public Transform itemsParent;
    MonsterDropSlot[] slots;
    MonsterDrop monsterDrop;

    // Use this for initialization
    void Start()
    {
        monsterDrop = MonsterDrop.instance;
        monsterDrop.onDropChangeCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<MonsterDropSlot>();
    }


    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < monsterDrop.Items.Count)
            {
                slots[i].AddItem(monsterDrop.Items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void ClearAllSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log("Clearing slot at: " + i.ToString());
            slots[i].ClearSlot();
        }
    }

    public bool CheckIfEmpty()
    {
        Debug.Log("In Function ");
        for (int i = 0; i < slots.Length; i++)
        {
            if(slots[i].ItemsIcon.interactable == false)
            {
                Debug.Log("Empty " + i.ToString());
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
