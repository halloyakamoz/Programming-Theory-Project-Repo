using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRain : MonoBehaviour
{

    public GameObject[] objectToFall;

    private float spawnRange = 25f;
    private float ySpawn = 20f;

    private float objectSpawnTime = 0.03f;
    private float startDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", startDelay, objectSpawnTime);
    }

    void SpawnObject()
    {
        float xSpawnRange = Random.Range(-spawnRange, spawnRange);
        float zSpawnRange = Random.Range(-spawnRange, spawnRange);
        int randomIndex = Random.Range(0, objectToFall.Length);

        Vector3 spawnPos = new Vector3(xSpawnRange, ySpawn, zSpawnRange);

        Instantiate(objectToFall[randomIndex], spawnPos, Quaternion.identity);
    }
}
