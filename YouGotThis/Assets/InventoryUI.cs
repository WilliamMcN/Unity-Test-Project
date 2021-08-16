using UnityEngine;

public class InventoryUI : MonoBehaviour {


    public Transform itemsParent;
    InventorySlot[] slots;
    Inventory inventory;

    // Use this for initialization
    void Start() {
        inventory = Inventory.instance;
        inventory.onItemChangeCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }


    // Update is called once per frame
    void Update() {

    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if( i < inventory.Items.Count)
            {
                slots[i].AddItem(inventory.Items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
