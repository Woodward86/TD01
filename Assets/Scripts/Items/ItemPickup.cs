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
        inventory = player.GetComponentInParent<Inventory>();

        bool wasPickedUp = inventory.Add(item);

        if (wasPickedUp && item.isEquipment)
        {
            //TODO: Will need to have locaters so the equipment goes to the right places on the body
            gameObject.transform.position = player.transform.position;
            //TODO: Need to find a more efficient way of doing these searches (look into singleton patterns)
            //TODO: Also will need to replace "Player_Geo" with name of final parent decision
            gameObject.transform.rotation = GameObject.Find("Player_Geo").transform.rotation;
            gameObject.transform.parent = GameObject.Find("Player_Geo").transform;
        }
        if (wasPickedUp && item.isConsumable)
        {
            Destroy(gameObject);
        }
    }
}
