using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item {

    public Resource resource;
    public enum Resource {Health, Mana, Stamina, Other}
    public int value = 100;
 
}
