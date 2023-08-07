using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject evo, coin;
    public Terrain terrain;
    private int evospawn = 2, coinspawn = 50;
    private float respawnTime = 5f;

    float heightY = 0.2f;

    private TerrainData terrainData;

    void Start()
    {
        terrainData = terrain.terrainData;

        EvoSpawner();
        CoinSpawner();

        StartCoroutine(RespawnObjects());    
    }

    IEnumerator RespawnObjects()
    {
        while (true)
        {
            // Wait for the specified respawn time
            yield return new WaitForSeconds(respawnTime);

            // Spawn the objects
            EvoSpawner();
            CoinSpawner();
        }
    }


    // Update is called once per frame
    void EvoSpawner()
    {
        for (int i = 0; i < evospawn; i++)
        {
            // Generate random coordinates within the terrain bounds
            float randomX = Random.Range(0f, terrainData.size.x);
            float randomZ = Random.Range(0f, terrainData.size.z);

            // Set the Y coordinate based on the terrain height
            float spawnY = terrain.SampleHeight(new Vector3(randomX, 0f, randomZ)) + heightY;

            // Create a new spawn position using the random coordinates
            Vector3 spawnPosition = terrain.transform.position + new Vector3(randomX, spawnY, randomZ);

            // Instantiate the object at the spawn position
            Instantiate(evo, spawnPosition, Quaternion.identity);
        }
    }
    void CoinSpawner()
    {
        for (int i = 0; i < coinspawn; i++)
        {
            // Generate random coordinates within the terrain bounds
            float randomX = Random.Range(0f, terrainData.size.x);
            float randomZ = Random.Range(0f, terrainData.size.z);

            // Set the Y coordinate based on the terrain height
            float spawnY = terrain.SampleHeight(new Vector3(randomX, 0f, randomZ)) + heightY;

            // Create a new spawn position using the random coordinates
            Vector3 spawnPosition = terrain.transform.position + new Vector3(randomX, spawnY, randomZ);

            // Instantiate the object at the spawn position
            Instantiate(coin, spawnPosition, Quaternion.identity);
        }
    }

}
