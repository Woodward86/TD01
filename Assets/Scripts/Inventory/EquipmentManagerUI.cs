using UnityEngine;

public class EquipmentManagerUI : MonoBehaviour
{

    public Transform itemsParent;
    public GameObject equipmentManagerUI;

    public Inventory inventory;

    InventorySlot[] slots;

    private void Start()
    {
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }


    private void Update()
    {
        if(Input.GetButtonDown("Character Sheet"))
        {
            equipmentManagerUI.SetActive(!equipmentManagerUI.activeSelf);
        }
    }


    void UpdateUI ()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

}
