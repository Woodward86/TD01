using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    //TODO: EquipmentSlot option should only be shown if isEquipment is on
    //TODO: isStackable should only be shown if isConsumable is on
    //TODO: Consumable items should probably get a duration
    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject preFab;
    public EquipmentSlotTag equipmentSlot;

    public bool isEquipment = false;
    public bool isConsumable = false;
    public bool isStackable = false;

    public int healthModifier;
    public int armourModifier;
    public int damageModifier;
    public int speedModifier;


    public void Use(PlayerStats target)
    {
        Debug.Log("Using " + name);

        //TODO: All of this logic should probably be moved to PlayerStats, subscribing to the OnItemChanged() delegate from Inventory.
        if (target != null)
        {
            target.walkSpeed.AddModifier(speedModifier);
            target.armour.AddModifier(armourModifier);
            target.damage.AddModifier(damageModifier);
            target.maxHealth += healthModifier;
        }
    }

}

public enum EquipmentSlotTag { Head, Chest, Legs, Feet, Weapon }

