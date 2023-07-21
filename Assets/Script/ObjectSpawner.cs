using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Terrain terrain;
    public int numberOfObjects = 10;
    public float respawnTime = 30f;

    float heightY = 0.2f;

    private TerrainData terrainData;

    void Start()
    {
        terrainData = terrain.terrainData;

        SpawnObjects();

        StartCoroutine(RespawnObjects());    
    }

    IEnumerator RespawnObjects()
    {
        while (true)
        {
            // Wait for the specified respawn time
            yield return new WaitForSeconds(respawnTime);

            // Spawn the objects
            SpawnObjects();
        }
    }


    // Update is called once per frame
    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Generate random coordinates within the terrain bounds
            float randomX = Random.Range(0f, terrainData.size.x);
            float randomZ = Random.Range(0f, terrainData.size.z);

            // Set the Y coordinate based on the terrain height
            float spawnY = terrain.SampleHeight(new Vector3(randomX, 0f, randomZ)) + heightY;

            // Create a new spawn position using the random coordinates
            Vector3 spawnPosition = terrain.transform.position + new Vector3(randomX, spawnY, randomZ);

            // Instantiate the object at the spawn position
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
