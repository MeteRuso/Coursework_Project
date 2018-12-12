using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupItem : Interactable
{

    public Item NewItem;

    public override void EInteract(GameObject ItemName)
    {
        //base.EInteract();

        pickup(NewItem);
        //
    }

    void pickup(Item NewItem)
    {
        //Pick Up Item
        Debug.Log("Picking up " + NewItem.name);
        //Add to inventory List


        Debug.Log(Inventory.instance.ToString());
        //Inventory.instance.AddItem(NewItem);
        //Destroy Item
        Destroy(gameObject);
    }


}