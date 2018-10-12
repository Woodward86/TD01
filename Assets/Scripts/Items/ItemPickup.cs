using UnityEngine;

//this only works for Equipment right now not all items
public class ItemPickup : Interactable
{
    public Equipment equipment;
    //public Item item;
    private Inventory inventory;
    private EquipmentManager equipmentManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }


    void Pickup(Collider player)
    {
        Debug.Log("Picking up " + equipment.name);
        inventory = player.GetComponent<Inventory>();
        equipmentManager = player.GetComponent<EquipmentManager>();

        bool wasPickedUp = inventory.Add(equipment);

        if (wasPickedUp)
        {
            equipmentManager.Equip(equipment);
            Destroy(gameObject);
        }
    }

}
