using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Item item;
    public GameObject itemEffects;
    //TODO: Add sound FX and screen FX

    // Ranged settings
    public GameObject projectilePrefab;
    public Transform firePoint;


    //TODO: Finish building this method it will need to return the gameObject back to its starting position
    public void Strike()
    {
        gameObject.transform.Translate(Vector3.forward * 13f * Time.deltaTime);
    }


    public void Shoot()
    {
        GameObject pp = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        pp.transform.parent = firePoint.transform.parent.transform.parent.transform.parent;
        PlayItemEffects(firePoint.position);
    }


    public void PlayItemEffects(Vector3 origin)
    {
        if (itemEffects != null)
        {
            GameObject ie = Instantiate(itemEffects, origin, itemEffects.transform.rotation);
            ie.transform.parent = firePoint.transform.parent;
        }
    }

}
