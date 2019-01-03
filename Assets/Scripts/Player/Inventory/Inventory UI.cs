using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    //Caching the inventory so the code runs optimally
    //and we dont have to reference the inventory singleton every time
    Inventory Inventory;


	// Use this for initialization
	void Start () {
        Inventory = Inventory.instance;
        // Whenever an item is changed, the UI will be updated as the UpdateUI method will be called
        Inventory.OnItemChangedCallback += UpdateUI;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateUI()
    {
        Debug.Log("UI update");

    }
}
