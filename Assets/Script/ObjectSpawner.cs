using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> enemylist = new List<GameObject>();
    public GameObject evo, coin, enemy;
    public Terrain terrain;
    private int evospawn = 1000, coinspawn = 50, enemyspawn = 10, spawntimes = 5;
    private float respawnTime = 30f;
    public TextMeshProUGUI enemyleftext;
    public int enemyleft, enemydecrease;

    float heightY = 0.2f;

    private TerrainData terrainData;

    void Start()
    {
        terrainData = terrain.terrainData;

        EvoSpawner();
        CoinSpawner();
        EnemySpawner();

        StartCoroutine(RespawnObjects());    
    }
    void Update()
    {
        enemyleftext.text = "Enemy left: " + enemyleft;
        Debug.Log(enemylist.Count + 1);
        enemyleft = (enemylist.Count + 1) - enemydecrease;
    }

    IEnumerator RespawnObjects()
    {
        while (true)
        {
            // Wait for the specified respawn time
            yield return new WaitForSeconds(respawnTime);

            // Spawn the objects
            if(spawntimes>0)
            {
                EvoSpawner();
                CoinSpawner();
                spawntimes--;
            }
            else
            {
                Debug.Log("Stop Spawn");
            }
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
    void EnemySpawner()
    {
        for (int i = 0; i < enemyspawn; i++)
        {
            // Generate random coordinates within the terrain bounds
            float randomX = Random.Range(0f, terrainData.size.x);
            float randomZ = Random.Range(0f, terrainData.size.z);

            // Set the Y coordinate based on the terrain height
            float spawnY = terrain.SampleHeight(new Vector3(randomX, 0f, randomZ)) + heightY;

            // Create a new spawn position using the random coordinates
            Vector3 spawnPosition = terrain.transform.position + new Vector3(randomX, spawnY, randomZ);

            enemylist.Add(Instantiate(enemy, spawnPosition, Quaternion.identity));
        }
    }
}
