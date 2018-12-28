using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "NewItem";
    public Sprite iconOfObject = null;

    public bool Equipable = false;
    public bool Consumable = false;


}
