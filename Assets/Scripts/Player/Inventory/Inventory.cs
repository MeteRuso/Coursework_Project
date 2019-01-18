using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
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

    // A subroutine that is called every time an item is picked up
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;
    
    //Amount of available slots for items in the inventory
    public int inventorySpace = 20;
    //Variables for items that the user can hold multiple of (Consumables)
    public int HPot, SPot, MPot, Arrow, Gold;
    //Variable for text for each consumable
    public Text HPotionText, MPotionText, SPotionText, ArrowText;

    //invent my own list
    public List<Item> Playerinventory = new List<Item>();

    #region AddOrRemove
    public bool AddItem(Item NewItem)
    {
        // If statement increments the consumable items when picked up 
        // The else statement adds the item the inventory list and updates the UI
        if (NewItem.displayname == "Health Potion")
        {
            HPot += 1;
            HPotionText.text = HPot.ToString();
        }
        else if (NewItem.displayname == "Stamina Potion")
        {
            SPot += 1;
            SPotionText.text = SPot.ToString();
        }
        else if (NewItem.displayname == "Mana Potion")
        {
            MPot += 1;
            MPotionText.text = MPot.ToString();
        }
        else if (NewItem.displayname == "Arrow")
        {
            Arrow += 1;
            ArrowText.text = Arrow.ToString();
        }
        else
        {
            // Limits inventory size so cant have more items than spaces
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
        }
        return true;
    }

    public void RemoveItem(Item Item)
    {
        Playerinventory.Remove(Item);

        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
    }
    #endregion

}
