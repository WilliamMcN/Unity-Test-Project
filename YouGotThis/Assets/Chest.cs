using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    #region Singleton

    public static Chest instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance found");
            return;
        }
        instance = this;
    }
    #endregion
    public delegate void onChestChange();
    public onChestChange onChestChangeCallback;
    public int space;
    public List<Items> Items = new List<Items>();

    public bool Add(Items item)
    {
        if (Items.Count >= space)
        {
            Debug.Log("Inventory is Full");
            return false;
        }
        Debug.Log("Adding Item");
        Items.Add(item);
        if (onChestChangeCallback != null)
        {
            onChestChangeCallback.Invoke();
        }
        return true;
    }
    public void Remove(Items item)
    {
        Items.Remove(item);

        if (onChestChangeCallback != null)
        {
            onChestChangeCallback.Invoke();
        }
    }

    public void RemoveAll()
    {
        for (int i = Items.Count-1; i >= 0; i--)
        {
            Debug.Log("Removing Item: " + Items[i].itemName + "at " + i.ToString());
            Items.Remove(Items[i]);
        }
    }
}
