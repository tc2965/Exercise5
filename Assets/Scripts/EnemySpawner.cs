using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public void SpawnEnemies()
    {
        float spawnTimer = 2.0f; 
        while (true) {
            while (spawnTimer > 0.0f) {
                spawnTimer -= Time.deltaTime;
            }
            Instantiate(enemyPrefab, transform.position,transform.rotation);
            Instantiate(enemyPrefab, transform.position,transform.rotation);
            spawnTimer = 5.0f;
        }
        
    }
}