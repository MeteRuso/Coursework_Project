using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton
    public static EquipmentManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one equipment array");
            return;
        }

        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    Inventory inventory;

    // Use this for initialization
    void Start () {
        inventory = Inventory.instance;

       //number of equip slots are determined by the number of elements in the weaponslots enum
        int equipmentSlots = System.Enum.GetNames(typeof(WeaponSlots)).Length;
        currentEquipment = new Equipment[equipmentSlots];
	}
	
    public void Equip(Equipment newItem)
    {
        int ItemSlotIndex = (int)newItem.EquipSlot;

        Equipment oldItemOne = null;
        Equipment oldItemTwo = null;

        if (ItemSlotIndex == 2)
        {
            //unequip
        }
        else if (ItemSlotIndex == 1)
        {
            if (currentEquipment[0] != null)
            {
                oldItemOne = currentEquipment[0];
                inventory.AddItem(oldItemOne);
            }
            if (currentEquipment[2] != null)
            {
                oldItemTwo = currentEquipment[2];
                inventory.AddItem(oldItemTwo);
            }
            
        }
        else if (ItemSlotIndex ==2)
        {
            if (currentEquipment[1] != null)
            {
                oldItemOne = currentEquipment[0];
                inventory.AddItem(oldItemOne);
            }
            if (currentEquipment[2] != null)
            {
                oldItemTwo = currentEquipment[2];
                inventory.AddItem(oldItemTwo);
            }


        }
        
    }


	// Update is called once per frame
	void Update () {
		
	}
}
