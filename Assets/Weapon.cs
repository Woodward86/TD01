using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Item item;
    public GameObject itemEffects;

    // Ranged settings
    public GameObject projectilePrefab;
    public Transform firePoint;

    //TODO: Finish building this method it will need to return the gameObject back to its starting position
    public void Strike()
    {
        gameObject.transform.Translate(Vector3.forward * 13f * Time.deltaTime);
    }

    //TODO: Instantiating with a parent had everything working... BUT the clones were then linked to the rotation/translation of the player... NOT what we want
    public void Shoot()
    {
        //Instantiate(projectilePrefab, firePoint.position, firePoint.rotation, transform.parent = firePoint.transform.parent.transform.parent);
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        //Debug.Log(firePoint.transform.parent.transform.parent.transform.parent);
        PlayItemEffects(firePoint.position);
    }

    //TODO: Need to destroy the effects once they have played
    public void PlayItemEffects(Vector3 origin)
    {
        float effectDuration = itemEffects.GetComponent<ParticleSystem>().main.duration;

        if (itemEffects != null)
        {
            GameObject toDestroy = Instantiate(itemEffects, origin, itemEffects.transform.rotation);

            if (toDestroy != null)
            {
                Debug.Log(toDestroy);
            }
        }
    }

}
