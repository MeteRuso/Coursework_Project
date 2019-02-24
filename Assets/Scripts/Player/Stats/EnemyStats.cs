using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats {

    public enum Weapon
    {
        SWORD,
        BOW,
        STAFF,
        SHIELD
    }

    Weapon WeaponType;
    public Stat Ammo;

}
