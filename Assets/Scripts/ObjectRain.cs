using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRain : MonoBehaviour
{

    public GameObject[] objectToFall;

    private float spawnRange = 25f;
    private float ySpawn = 20f;
    private float yDestroyThreshold = -0.1f;

    private float objectSpawnTime = 1f;
    private float startDelay = 1f;

    private int selectedObjectIndex; // Index of the selected object from the objectToFall array

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            GameObject objectToSpawn = objectToFall[selectedObjectIndex];

            float xSpawnRange = Random.Range(-spawnRange, spawnRange);
            float zSpawnRange = Random.Range(-spawnRange, spawnRange);
            Vector3 spawnPos = new Vector3(xSpawnRange, ySpawn, zSpawnRange);

            GameObject obj = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);

            // Set the object to be destroyed when it passes the yDestroyThreshold
            Destroy(obj, Mathf.Abs(ySpawn - yDestroyThreshold) / Mathf.Abs(Physics.gravity.y));

            yield return new WaitForSeconds(objectSpawnTime);
        }
    }

    public void SetSelectedObjectIndex(int index)
    {
        // Set the selected object index
        selectedObjectIndex = index;
    }
}