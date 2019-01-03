using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Inventory : MonoBehaviour {

    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one inventory");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;
    
    //Amount of available slots for items in the inventory
    public int inventorySpace = 20;


    //invent my own list
    public List<Item> Playerinventory = new List<Item>();

    #region AddOrRemove
    public bool AddItem(Item NewItem)
    {
        if (Playerinventory.Count >= inventorySpace)
        {
            Debug.Log("Full");
            return false;
        }
        Debug.Log("Adding Item");
        Playerinventory.Add(NewItem);

        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }

        return true;
    }

    public void RemoveItem(Item Item)
    {
        Playerinventory.Remove(Item);

        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke
        }
    }
    #endregion
}
