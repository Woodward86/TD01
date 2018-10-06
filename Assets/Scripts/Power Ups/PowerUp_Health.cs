using System.Collections;
using UnityEngine;

public class PowerUp_Health : PowerUp
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine( Pickup(other) );
        }
    }


    IEnumerator Pickup(Collider player)
    {
        toDestroy = Instantiate(pickupEffect, transform.position, pickupEffect.transform.rotation);

        PlayerStats_Temp stats = player.GetComponent<PlayerStats_Temp>();
        stats.health *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.health /= multiplier;

        Destroy(gameObject);
        Destroy(toDestroy);
    }


}
