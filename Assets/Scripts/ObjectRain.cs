using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRain : MonoBehaviour
{
    public GameObject[] objectToFall;

    private float spawnRange = 25f;
    private float ySpawn = 20f;
    private float objectSpawnTime = 0.03f;
    private float startDelay = 0.2f;

    private bool isRainStarted = false;

    public GameObject[] selectableObjects;
    private int selectedObjectIndex = -1;

    void Start()
    {
        // Disable the renderer for all objects in the objectToFall array
        foreach (GameObject obj in objectToFall)
        {
            obj.GetComponent<Renderer>().enabled = false;
        }
    }

    void Update()
    {
        // Check if the user has clicked one of the selectable objects
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object that was clicked is in the selectableObjects array
                for (int i = 0; i < selectableObjects.Length; i++)
                {
                    if (hit.collider.gameObject == selectableObjects[i])
                    {
                        // Set the selectedObjectIndex to the index of the clicked object
                        selectedObjectIndex = i;

                        // Enable the renderer for the selected object in the objectToFall array
                        objectToFall[selectedObjectIndex].GetComponent<Renderer>().enabled = true;

                        // Start the rain
                        if (!isRainStarted)
                        {
                            isRainStarted = true;
                            InvokeRepeating("SpawnObject", startDelay, objectSpawnTime);
                        }

                        break;
                    }
                }
            }
        }
    }

    void SpawnObject()
    {
        // If the rain hasn't started yet, exit the method
        if (!isRainStarted)
        {
            return;
        }

        // Generate a random spawn position within the spawn range
        float xSpawnRange = Random.Range(-spawnRange, spawnRange);
        float zSpawnRange = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(xSpawnRange, ySpawn, zSpawnRange);

        // Select the object to spawn based on the selectedObjectIndex
        if (selectedObjectIndex >= 0 && selectedObjectIndex < objectToFall.Length)
        {
            GameObject objectToSpawn = objectToFall[selectedObjectIndex];

            // Spawn the object at the random position
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);

            // Set the parent of the spawned object to the ObjectRain game object
            spawnedObject.transform.SetParent(transform);

            // Destroy the object when it passes the y-position threshold
            if (spawnedObject.transform.position.y < -0.1f)
            {
                Destroy(spawnedObject);
            }
        }
    }
}
