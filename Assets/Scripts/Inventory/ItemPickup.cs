using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;
    public Inventory inventory;

    //private void Start()
    //{
    //    inventory = GetComponent<Inventory>();
    //}

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

        bool wasPickedUp = inventory.Add(item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }

}
