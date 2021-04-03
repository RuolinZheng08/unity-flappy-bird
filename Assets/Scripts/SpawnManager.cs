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
    [SerializeField] float ySpawnMin;
    [SerializeField] float ySpawnMax;
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
        if (bottom) { // negate y
            ySpawnPos = -ySpawnPos;
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
            obstaclePrefab.transform.GetChild(0).gameObject.transform.rotation = spawnRotation;
        } else { // rorate z by 180
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 180);
            obstaclePrefab.transform.GetChild(0).gameObject.transform.rotation = spawnRotation;
        }
        Vector3 spawnPos = new Vector3(xSpawnPos, ySpawnPos, zSpawnPos);
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
