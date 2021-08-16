using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Items : ScriptableObject
{

    public string itemCode;
    public string type;
    public string itemName;
    public string Class;
    public int value;
    public string rarity;
    public enum Type { Weapon, Armour, Healing, Consumable };
    public int rarityCode;
    public Sprite itemImage;
}
