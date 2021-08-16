using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InteractableChest : MonoBehaviour
{

    public Controls control;
    public Image chestpanel;
    public ChestUI chestUI;
    public bool chestactive = false;
    public List<Items> dropList = new List<Items>();
    public List<float> dropChance = new List<float>();
    public List<Items> itemList = new List<Items>();
    public float maxDropRange;
    public int minDrops;
    public int maxDrops;
    public int amountofdrops;
    public bool isActive = false;
    public bool resetInv = true;
    public Chest chest;
    public bool onChest = false;
    public bool inChest = false;
    public Button closeButton;

    public void Start()
    {
        int selectedItem = 0;
        float randomNum = Random.Range(0f, maxDropRange);
        float total = 0;
        amountofdrops = Random.Range(minDrops, maxDrops);
        Debug.Log("Item:" + amountofdrops.ToString());
        for (int i = 0; i < amountofdrops; i++)
        {
        for (int j = 0; j < dropChance.Count; j++)
        {
            total = total + dropChance[j];
            if (randomNum < total)
            {
                selectedItem = j;
                addItem(dropList[selectedItem]);
                j = dropChance.Count;
            }
        }
        //Debug.Log("Item:" + dropList[selectedItem].itemName);
        }
        callItems();
}

    public void Update()
    {

        if(onChest && inChest && Input.GetKeyDown(control.interactKey))
        {
            CloseChest();
            inChest = false;
        }
        else if (onChest && inChest == false)
        {
                if (Input.GetKeyDown(control.interactKey))
                {
                    inChest = true;
                    resetInv = true;
                    isActive = false;
                    chestactive = true;
                    Debug.Log("You have opened chest");
                    for (int i = 0; i < itemList.Count; i++)
                    {
                        Debug.Log("Adding: " + i.ToString());
                        if (itemList[i] == null)
                        {
                            i = itemList.Count;
                        }
                        else
                        {
                            Chest.instance.Add(itemList[i]);
                        }

                    }
                    isActive = true;
                    chestpanel.gameObject.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        onChest = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Leaving Chest");
        chestpanel.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        onChest = false;
        resetList();
    }
    public void resetList()
    {
        if (resetInv == true)
        {
            resetInv = false;
            chestactive = false;
            List<Items> newItems;
            newItems = chestUI.setChestInv();
            //itemList = newItems;
            for (int i = 0; i < newItems.Count; i++)
            {
                Debug.Log("Size of newList: " + newItems.Count.ToString() + "Size of oldList: " + itemList.Count.ToString());
                itemList[i] = newItems[i];
            }
            for (int i = newItems.Count; i < itemList.Count; i++)
            {
                itemList[i] = null;
            }
            Debug.Log(newItems.Count.ToString());
            chest.RemoveAll();
            Debug.Log(newItems.Count.ToString());
        }
    }
    public void CloseChest()
    {
        Debug.Log("Leaving Chest");
        chestpanel.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        onChest = false;
        resetList();

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
}
