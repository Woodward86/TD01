﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentSlot;

    public int armourModifier;
    public int damageModifier;



    public override void Use()
    {
        base.Use();
    }


}


public enum EquipmentSlot { Head, Chest, Legs, Weapon, Feet }
