using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    public EquipmentManager equipmentManager;

    public Equipment[] currentEquipment;

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }


    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipmentSlot;

        currentEquipment[slotIndex] = newItem;
    }

}
