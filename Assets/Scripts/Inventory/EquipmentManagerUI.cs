using UnityEngine;

public class EquipmentManagerUI : MonoBehaviour
{
    public Transform itemsParent;
    public Transform equipmentsParent;
    public GameObject equipmentManagerUI;

    public Inventory inventory;

    InventorySlot[] cSlots;
    InventorySlot[] eSlots;

    private void Start()
    {
        inventory.onItemChangedCallback += UpdateUI;

        cSlots = itemsParent.GetComponentsInChildren<InventorySlot>();
        eSlots = equipmentsParent.GetComponentsInChildren<InventorySlot>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Character Sheet"))
        {
            equipmentManagerUI.SetActive(!equipmentManagerUI.activeSelf);
        }
    }


    void UpdateUI ()
    {
        UpdateEquipmentSlots();
        UpdateConsumbaleSlots();
    }


    //TODO: The slot the equipment goes to should be dictated by slot name, not a hard coded index
    void UpdateEquipmentSlots()
    {
        for (int e = 0; e < eSlots.Length; e++)
        {
            if (e < inventory.currentEquipment.Length && inventory.currentEquipment[e] != null)
            {
                if (inventory.currentEquipment[e].equipmentSlot == EquipmentSlotTag.Head)
                {
                    eSlots[0].AddItem(inventory.currentEquipment[e]);
                }
                if (inventory.currentEquipment[e].equipmentSlot == EquipmentSlotTag.Chest)
                {
                    eSlots[1].AddItem(inventory.currentEquipment[e]);
                }
                if (inventory.currentEquipment[e].equipmentSlot == EquipmentSlotTag.Legs)
                {
                    eSlots[2].AddItem(inventory.currentEquipment[e]);
                }
                if (inventory.currentEquipment[e].equipmentSlot == EquipmentSlotTag.Feet)
                {
                    eSlots[3].AddItem(inventory.currentEquipment[e]);
                }
                if (inventory.currentEquipment[e].equipmentSlot == EquipmentSlotTag.Weapon)
                {
                    eSlots[4].AddItem(inventory.currentEquipment[e]);
                }
            }
        }
    }

    //TODO: Need to build in Stackable logic and a UI counter for items that stack
    void UpdateConsumbaleSlots()
    {
        for (int i = 0; i < cSlots.Length; i++)
        {
            if (i < inventory.consumables.Count)
            {
                cSlots[i].AddItem(inventory.consumables[i]);
            }
            else
            {
                cSlots[i].ClearSlot();
            }
        }
    }
}
