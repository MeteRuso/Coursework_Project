using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string displayname = "NewItem";
    new public string tagName = "Item";
    public Sprite iconOfObject = null;

    public bool Equipable = false;
    public bool Consumable = false;
    public bool Essential = false;

}
