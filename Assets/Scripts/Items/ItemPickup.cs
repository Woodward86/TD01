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
            gameObject.transform.position = player.transform.position;
            //TODO: Need to find a more efficient way of doing these searches (look into singleton patterns)
            gameObject.transform.rotation = GameObject.Find("Player_Geo").transform.rotation;
            gameObject.transform.parent = GameObject.Find("Player_Geo").transform;
        }
        if (wasPickedUp && item.isConsumable)
        {
            Destroy(gameObject);
        }
    }

    //TODO: This logic should be somewhere else
    public void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Attack pressed.");
            item.preFab.transform.position = Vector3.forward * 2f;
        }
        else
        {
            item.preFab.transform.localPosition = Vector3.zero;
        }
    }
}
