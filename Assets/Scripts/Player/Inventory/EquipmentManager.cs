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

    InventorySlot[] slots;
    Equipment[] currentEquipment;
    public Transform EquipSlotParent;
    Inventory inventory;

    // Use this for initialization
    void Start () {
        inventory = Inventory.instance;

        slots = EquipSlotParent.GetComponentsInChildren<InventorySlot>();

        //number of equip slots are determined by the number of elements in the weaponslots enum
        int equipmentSlots = System.Enum.GetNames(typeof(WeaponSlots)).Length;
        currentEquipment = new Equipment[equipmentSlots];
	}
	
    public void UnEquip(Equipment newItem)
    {
        int ItemSlotIndex = (int)newItem.EquipSlot;
        
        if (ItemSlotIndex == 2)
        {
            ClearSlotZero();
            ClearSlotOne();
            ClearSlotTwo();
        }
        else if (ItemSlotIndex == 1)
        {
            ClearSlotOne();
            ClearSlotTwo();
        }
        else if (ItemSlotIndex == 0)
        {
            ClearSlotZero();
            ClearSlotTwo();
        }
        
    }

    #region Clear Slots

    public void ClearSlotZero()
    {
        if (currentEquipment[0] != null)
        {
            inventory.AddItem(currentEquipment[0]);
            currentEquipment[0] = null;
            slots[0].Clearslot();
        }
    }

    public void ClearSlotOne()
    {
        if (currentEquipment[1] != null)
        {
            inventory.AddItem(currentEquipment[1]);
            currentEquipment[1] = null;
            slots[1].Clearslot();
        }
    }

    public void ClearSlotTwo()
    {
        if (currentEquipment[2] != null)
        {
            inventory.AddItem(currentEquipment[2]);
            currentEquipment[2] = null;
            slots[1].Clearslot();
            slots[0].Clearslot();
        }
    }

    #endregion

    public void Equip(Equipment newItem)
    {
        UnEquip(newItem);
        currentEquipment[(int)newItem.EquipSlot] = newItem;
        if ((int)newItem.EquipSlot < 2)
        {
            slots[(int)newItem.EquipSlot].Additem(newItem);
        }
        else
        {
            slots[0].Additem(newItem);
            slots[1].Additem(newItem);
        }
    }
    
}
