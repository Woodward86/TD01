using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    protected Inventory inventory;

	void Start ()
    {
        inventory = GetComponent<Inventory>();
        inventory.onEquipmentChanged += OnEquipmentChanged;
	}


    void OnEquipmentChanged(Item newItem, Item oldItem)
    {
        if (newItem != null)
        {
            armour.AddModifier(newItem.armourModifier);
            damage.AddModifier(newItem.damageModifier);
            walkSpeed.AddModifier(newItem.speedModifier);
        }

        if (oldItem != null)
        {
            armour.RemoveModifier(oldItem.armourModifier);
            damage.RemoveModifier(oldItem.damageModifier);
            walkSpeed.RemoveModifier(oldItem.speedModifier);
        }
    }

    //TODO: Not sure if this is the way we should kill the player, this will force a start from scratch
    public override void Die()
    {
        base.Die();

        //TODO: Add something special for Player death

        Destroy(gameObject);
    }

}
