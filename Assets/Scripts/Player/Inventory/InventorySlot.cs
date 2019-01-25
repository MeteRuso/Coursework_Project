using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    Item currentItem;
    public Image Icon;

    public void Additem(Item Item)
    {
        currentItem = Item;
        Icon.sprite = currentItem.iconOfObject;
        Icon.enabled = true;
    }

    public void Clearslot()
    {
        currentItem = null;
        Icon.sprite = null;
        Icon.enabled = false;
    }

    public void AddToInv(Item Item)
    {
        Inventory.instance.AddItem(Item);
    }

    public void UseItem()
    {
        if (currentItem != null)
        {
            currentItem.Use();
        }
        
    }

}
