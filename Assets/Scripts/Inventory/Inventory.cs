using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public delegate void OnEquipmentChanged(Item newItem, Item oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    //TODO: Need to change this over into an array so the indexes don't change.
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

    //TODO: When new consumable is picked up and current slots are full, one of the old ones needs to drop
    public void Remove(Item item)
    {
        consumables.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }


    public void Equip(Item newItem)
    {
        int slotIndex = (int)newItem.equipmentSlot;

        Item oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            Unequip(slotIndex);

            currentEquipment[slotIndex] = null;
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
    }


    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Item oldItem = currentEquipment[slotIndex];

            Instantiate(oldItem.preFab, transform.position, Quaternion.identity);
            Debug.Log("Dropping " + oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }
}