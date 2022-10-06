using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorTrigger : MonoBehaviour
{
    public GameObject trapDoor;
    private bool activeTrapDoor;

    EnemySpawner spawnEnemies;

    void Start()
    {
        GameObject spawnEnemiesMaybe = GameObject.FindGameObjectWithTag("EnemySpawn");
        if (spawnEnemiesMaybe != null) {
            spawnEnemies = spawnEnemiesMaybe.GetComponent<EnemySpawner>();
        } else {
            Debug.Log("spawnEnemiesMaybe is null");
        }
        GameObject trapDoor = GameObject.FindGameObjectWithTag("TrapDoor");
        if (trapDoor == null) {
            Debug.Log("trapDoor is null");
        }
        activeTrapDoor = false;
        trapDoor.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) {
            if (!activeTrapDoor) {
                trapDoor.SetActive(true);
                activeTrapDoor = true;
                spawnEnemies.SpawnEnemies();
            }

        }

        
    }
}
