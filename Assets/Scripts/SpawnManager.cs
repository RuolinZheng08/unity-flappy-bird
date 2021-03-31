using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    float spawnDelay = 1;
    float spawnInterval = 1;
    float xSpawnPos = 20;
    float zSpawnPos = -2;
    float ySpawnMin = 5;
    float ySpawnMax = 8;
    PlayerController playerController;

    void Start() {
        InvokeRepeating("SpawnObject", spawnDelay, spawnInterval);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObject() {
        if (playerController.isGameOver) {
            return;
        }
        float ySpawnPos = Random.Range(ySpawnMin, ySpawnMax);
        // first flip a coin to determine if the object comes from the top or bottom
        bool bottom  = (Random.value > 0.5f);
        if (bottom) { // negate
            ySpawnPos = -ySpawnPos;
        }
        Vector3 spawnPos = new Vector3(xSpawnPos, ySpawnPos, zSpawnPos);
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
