using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    private Inventory inventory;
    private GameObject playerGeo;

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
        //TODO: Need to find a more efficient way of doing these searches (look into singleton patterns)
        //TODO: Also will need to replace "Player_Geo" with name of final parent decision
        playerGeo = GameObject.Find("Player_Geo");

        bool wasPickedUp = inventory.Add(item);

        if (wasPickedUp && item.isEquipment)
        {
            //TODO: Will need to have locaters so the equipment goes to the right places on the body
            gameObject.transform.position = player.transform.position;
            gameObject.transform.rotation = playerGeo.transform.rotation;
            gameObject.transform.parent = playerGeo.transform;
        }
        if (wasPickedUp && item.isConsumable)
        {
            Destroy(gameObject);
        }
    }
}
