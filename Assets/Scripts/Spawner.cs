using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bombPrefab;
    public Transform[] spawnPoints;
    public float enemySpawnProbability = 0.8f; // Probability of spawning an enemy
    public float timeBetweenSpawns;
    float nextSpawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            // Randomly decide whether to spawn an enemy or a bomb
            GameObject objectToSpawn = Random.value < enemySpawnProbability ? enemyPrefab : bombPrefab;

            // Instantiate the selected object at a random spawn point
            Instantiate(objectToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);

            // Set the next spawn time
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
}
