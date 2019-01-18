using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public WeaponSlots EquipSlot;
    public int Damage = 1;
    public string Resource = "None";

    public override void Use()
    {
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

public enum WeaponSlots {RightHand, LeftHand, Both}

