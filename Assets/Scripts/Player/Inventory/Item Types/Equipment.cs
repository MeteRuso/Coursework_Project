using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public WeaponSlots EquipSlot;
    public Resource Resources;
    public int Damage = 1;

    public override void Use()
    {
        Debug.Log("Used Equipment");
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }

    public virtual void MainATK()
    {

    }

    public virtual void SecATK()
    {

    }

}

public enum Resource {Stamina, Mana, Arrows }
public enum WeaponSlots {RightHand, LeftHand, Both}

