using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;


    private RoomTemplates templates;
    private int rand;
    private bool isSpawned = false;
    private bool isStartSpawned = false;
    private Vector3 testVect = Vector3.zero;


    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("genStartRoom", .1f);
        Invoke("Spawn", .2f);
    }


    private void genStartRoom()
    {
        if (!isStartSpawned && openingDirection == 0)
        {
            Instantiate(templates.startRoom[0], transform.position, templates.startRoom[0].transform.rotation);

            isStartSpawned = true;
        }
        
    }


    private void Spawn()
    {
        if (!isSpawned)
        {
            if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }

            isSpawned = true;
        }

    }


    private void OnTriggerEnter(Collider spawnPointCollider)
    {
        if (spawnPointCollider.CompareTag("Spawn Point") && spawnPointCollider.GetComponent<RoomSpawner>().isSpawned == true)
        {
            Destroy(gameObject);
        }
    }
}
