using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDrop : MonoBehaviour {

    #region Singleton

    public static MonsterDrop instance;

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
    public delegate void onDropChange();
    public onDropChange onDropChangeCallback;
    public int space;
    public List<Items> Items = new List<Items>();

    public bool Add(Items item)
    {
        if (Items.Count >= space)
        {
            Debug.Log("Inventory is Full");
            return false;
        }
        Items.Add(item);
        if (onDropChangeCallback != null)
        {
            onDropChangeCallback.Invoke();
        }
        return true;
    }
    public void Remove(Items item)
    {
        Items.Remove(item);

        if (onDropChangeCallback != null)
        {
            onDropChangeCallback.Invoke();
        }
    }
}
