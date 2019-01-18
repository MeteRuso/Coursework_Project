using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    //Caching the inventory so the code runs optimally
    //and we dont have to reference the inventory singleton every time
    Inventory Inventory;

    //Finding the Parent of all of the inventory slots
    public Transform invParent;
    //Array of inventory slots
    InventorySlot[] slots;
    public GameObject InvUI;


	// Use this for initialization
	void Start () {
        Inventory = Inventory.instance;
        // Whenever an item is changed, the UI will be updated as the UpdateUI method will be called
        Inventory.OnItemChangedCallback += UpdateUI;

        //Make the array slots equal to the parent of the slot objects in game
        slots = invParent.GetComponentsInChildren<InventorySlot>();
	}
	


	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Inventory"))
        {
            InvUI.SetActive (!InvUI.activeSelf);
        }
	}

    void UpdateUI()
    {
        Debug.Log("UI update");

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.Playerinventory.Count)
            {
                slots[i].Additem(Inventory.Playerinventory[i]);
            } else
            {
                slots[i].Clearslot();
            }
        }



    }
}
