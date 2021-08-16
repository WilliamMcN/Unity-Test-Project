using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance found");
            return;
        }
        instance = this;
    }
    #endregion
    public delegate void onItemChange();
    public onItemChange onItemChangeCallback;
    public int space;
    public List<Items> Items = new List<Items>();

    public bool Add(Items item)
    {
        if(Items.Count >= space)
        {
            Debug.Log("Inventory is Full");
            return false;
        }
        Items.Add(item);
        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
        return true;
    }

    public void Remove(Items item)
    {
        Items.Remove(item);

        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
    }


}
