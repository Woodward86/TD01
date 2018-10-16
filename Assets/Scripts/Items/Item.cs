using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;
    public EquipmentSlotTag equipmentSlot;
    //public bool isDefaultItem = false;
    public bool isEquipment = false;
    public bool isConsumable = false;

    public int armourModifier;
    public int damageModifier;


    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }

}

public enum EquipmentSlotTag { Head, Chest, Legs, Feet, Weapon }
