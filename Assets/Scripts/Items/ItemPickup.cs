using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    private Inventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }


    void Pickup(Collider player)
    {
        Debug.Log("Picking up " + item.name);
        inventory = player.GetComponent<Inventory>();

        bool wasPickedUp = inventory.Add(item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
