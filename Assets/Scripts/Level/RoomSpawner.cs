﻿using UnityEngine;

//TODO: if this looks like a path we want to go, need to add more rooms and more rules for spawning them
//TODO: build a method to destroy all the spawn points once the level is finished building
public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    private RoomTemplates templates;
    private int rand;
    private bool isSpawned = false;
    //private float buildTime;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("RoomSpawn", .1f);
    }


    private void RoomSpawn()
    {
        if (!isSpawned && openingDirection == 0)
        {
            Instantiate(templates.startRoom, transform.position, templates.startRoom.transform.rotation);
            //buildTime += Time.deltaTime;
        }
        else if (isSpawned == false)
        {
            if (openingDirection == 5)
            {
                isSpawned = true;
                return;
            }
            else if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.bottomRooms.Length);
                Invoke("GenBottomRooms", .05f);
                isSpawned = true;
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.topRooms.Length);
                Invoke("GenTopRooms", .1f);
                isSpawned = true;
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                Invoke("GenLeftRooms", .15f);
                isSpawned = true;
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, templates.rightRooms.Length);
                Invoke("GenRightRooms", .2f);
                isSpawned = true;
            }
        }
    }


    private void GenBottomRooms()
    {
        Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
    }


    private void GenTopRooms()
    {
        Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
    }


    private void GenLeftRooms()
    {
        Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
    }


    private void GenRightRooms()
    {
        Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
    }


    private void OnTriggerEnter(Collider spawnPointCollider)
    {
        if (spawnPointCollider.CompareTag("Spawn Point") && spawnPointCollider.GetComponent<RoomSpawner>().isSpawned == true)
        {
            Destroy(gameObject);
        }
    }
}
