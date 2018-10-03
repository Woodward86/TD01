using UnityEngine;

//TODO: might need to set this up to move with a Ridgid body so i can move by velocity not just teleport around
public class Walker : MonoBehaviour
{

    public GameObject floorTilePrefab;
    public int floorTileSize = 4;
    public int size = 25;

    private int randDir;
    private Vector3[] directions;
    private bool isSpawned = false;


    private void Start()
    {
        directions = new Vector3[4];

        directions[0] = Vector3.forward;
        directions[1] = Vector3.back;
        directions[2] = Vector3.right;
        directions[3] = Vector3.left;

        Instantiate(floorTilePrefab, transform.position, floorTilePrefab.transform.rotation);

        //Invoke("Stumble", 1f);
    }

    //TODO: needs to be fixed time interval
    private void Update()
    {
        if (isSpawned == false)
        {
            randDir = Random.Range(0, 4);
            this.transform.position += directions[randDir] * floorTileSize;
            Instantiate(floorTilePrefab, transform.position, floorTilePrefab.transform.rotation);
        }
    }


    //void Stumble()
    //{
    //    for (int i = 0; i < size; i++)
    //    {
    //        if (isSpawned == false)
    //        {
    //            randDir = Random.Range(0, 4);
    //            this.transform.position += directions[randDir] * floorTileSize;
    //            Instantiate(floorTilePrefab, transform.position, floorTilePrefab.transform.rotation);
    //        }
    //    }
    //}

    //TODO: needs to destroy whatever it collides with
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FloorTile"))
        {
            isSpawned = true;
        }
    }
}
