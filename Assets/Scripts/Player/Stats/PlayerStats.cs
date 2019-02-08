using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

	// Use this for initialization
	void Start () {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEquipmentChanged(Equipment newItem, int[] statChanges)
    {
        
    }
}
