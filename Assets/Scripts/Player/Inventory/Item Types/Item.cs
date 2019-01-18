using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    //Tag name is so I have a way to identify the item with no spaces in the name
    new public string displayname = "NewItem";
    new public string tagName = "Item";
    public Sprite iconOfObject = null;

    //A way to make different item interactions unique
    public virtual void Use()
    {
        Debug.Log("Used " + displayname);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.RemoveItem(this);
    }

}
