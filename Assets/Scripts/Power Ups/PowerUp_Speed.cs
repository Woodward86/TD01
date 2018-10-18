using System.Collections;
using UnityEngine;

public class PowerUp_Speed : PowerUp
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }


    IEnumerator Pickup(Collider player)
    {
        toDestroy = Instantiate(pickupEffect, transform.position, pickupEffect.transform.rotation);

        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.walkSpeed.AddMultiplier(multiplier);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.walkSpeed.RemoveMultiplier(multiplier);

        Destroy(gameObject);
        Destroy(toDestroy);
    }


}
