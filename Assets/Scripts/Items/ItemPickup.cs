using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;
    public Inventory inventory;
    public EquipmentManager equipmentManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }


    //TODO: Need this to auto equip new Equipment
    void Pickup(Collider player)
    {
        Debug.Log("Picking up " + item.name);

        bool wasPickedUp = inventory.Add(item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }

}
