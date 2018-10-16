using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    //public int space = 9;

    public List<Item> consumables = new List<Item>();

    public Item[] currentEquipment;

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlotTag)).Length;
        currentEquipment = new Item[numSlots];
    }


    public bool Add(Item item)
    {
        if (item.isConsumable)
        {
            consumables.Add(item);
        }
        if (item.isEquipment)
        {
            Equip(item);
        }

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        return true;
    }


    public void Equip(Item newItem)
    {
        int slotIndex = (int)newItem.equipmentSlot;

        Item oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            //drop oldTtem on the ground by instantiating a copy
            Debug.Log("Dropping " + oldItem);

            currentEquipment[slotIndex] = null;
        }

        currentEquipment[slotIndex] = newItem;
    }


    public void Remove(Item item)
    {
        consumables.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}
