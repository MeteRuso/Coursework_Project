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
        Debug.Log("Picking up " + NewItem.displayname);
        //Add to inventory List
        
        bool pickupSuccess = Inventory.instance.AddItem(NewItem);
        
        if (pickupSuccess == true)
        {
            //Destroy Item
            Destroy(gameObject);
        }

    }


}