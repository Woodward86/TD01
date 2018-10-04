using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Walker : MonoBehaviour
{

    public GameObject floorTilePrefab;
    public int floorTileSize = 4;
    public int size = 100;
    public int densityPercent = 50;

    private int randDir;
    private Vector3[] directions;
    private List<Vector3> prevLocations;


    private void Start()
    {
        directions = new Vector3[4];

        directions[0] = Vector3.forward;
        directions[1] = Vector3.back;
        directions[2] = Vector3.right;
        directions[3] = Vector3.left;

        Invoke("Stumble", 0.05f);
    }


    void Stumble()
    {
        prevLocations = new List<Vector3>();
        prevLocations.Add(transform.position);

        for (int i = 0; i < size; i++)
        {
            if (Chance(densityPercent))
            {
                randDir = Random.Range(0, 4);
            }

            transform.position += directions[randDir] * floorTileSize;

            if (!prevLocations.Contains(transform.position))
            {
                prevLocations.Add(transform.position);
            }
        }

        foreach (Vector3 loc in prevLocations)
        {
            Instantiate(floorTilePrefab, loc, floorTilePrefab.transform.rotation);
        }
    }


    private bool Chance(int x)
    {
        return (x >= Random.Range(0, 100));
    }

}
