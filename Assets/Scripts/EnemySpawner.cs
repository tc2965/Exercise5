using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnTimer = 2.0f; 
    int enemiesSpawned = 0;
    public void SpawnEnemies()
    {

        StartCoroutine(spawnEnemies());
    }
    
    private IEnumerator spawnEnemies() {
        while (enemiesSpawned < 5) 
        {
            Instantiate(enemyPrefab, transform.position,transform.rotation);
            enemiesSpawned++;
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}