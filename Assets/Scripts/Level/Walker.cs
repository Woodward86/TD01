using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Walker : MonoBehaviour
{

    public GameObject floorTilePrefab;
    public GameObject wallPrefab;
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


    private void Stumble()
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

        foreach (Vector3 loc in prevLocations)
        {
            WallGeneration(loc);
        }
    }


    private bool Chance(int x)
    {
        return (x >= Random.Range(0, 100));
    }


    private void WallGeneration(Vector3 tilePos)
    {
        foreach (Vector3 dir in directions)
        {
            if (!Physics.Raycast(tilePos, dir, floorTileSize))
            {
                if (dir == Vector3.forward)
                {
                    Instantiate(wallPrefab, tilePos + Vector3.forward * floorTileSize / 2, Quaternion.Euler(0, 90, 0));
                }
                else if (dir == Vector3.back)
                {
                    Instantiate(wallPrefab, tilePos + Vector3.back * floorTileSize / 2, Quaternion.Euler(0, 90, 0));
                }
                else if (dir == Vector3.right)
                {
                    Instantiate(wallPrefab, tilePos + Vector3.right * floorTileSize / 2, wallPrefab.transform.rotation);
                }
                else if (dir == Vector3.left)
                {
                    Instantiate(wallPrefab, tilePos + Vector3.left * floorTileSize / 2, wallPrefab.transform.rotation);
                }
            }
        }
    }

}
