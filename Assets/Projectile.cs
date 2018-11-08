using UnityEngine;

public class Projectile : MonoBehaviour
{
    //TODO: Need to add a bullet life time
    public float speed = 20f;
    public float projectileLifeTime = 3f;
    public Rigidbody rb;

	void Start ()
    {
        rb.velocity = transform.forward * speed;
	}


    //TODO: Need to destroy the bullet when its life time has run out
    private void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

    

}
