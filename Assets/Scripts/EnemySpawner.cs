using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public void SpawnEnemies()
    {
        float spawnTimer = 2.0f; 
        for (int i = 0; i < 2; i++) {
            while (spawnTimer > 0) {
                spawnTimer -= Time.deltaTime;
            }
            Instantiate(enemyPrefab, transform.position,transform.rotation);
            Instantiate(enemyPrefab, transform.position,transform.rotation);
            spawnTimer = 2.0f;
        }
        
    }
}