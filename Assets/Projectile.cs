using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float projectileLifeTime = 1.5f;
    private float projectileLifeCounter;
    public Rigidbody rb;

	void Start ()
    {
        rb.velocity = transform.forward * speed;
	}


    private void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }


    public void Update()
    {
        projectileLifeCounter += Time.deltaTime;
        if (projectileLifeCounter >= projectileLifeTime)
        {
            Destroy(gameObject);
        }
    }
}
