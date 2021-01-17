using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab = null;
    [SerializeField] BoxCollider2D[] spawnAreas = null;
    [SerializeField] int spawnNumber = 3;
    [SerializeField] Transform asteroidsParent = null;
    int waveNum = 0;

    // Update is called once per frame
    void Update()
    {
        if (FindObjectsOfType<Asteroid>().Length <= 0)
        {
            waveNum++;
            spawnNumber++;
            SpawnWave();
        }
        
    }

    private void SpawnWave()
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            Instantiate(asteroidPrefab, GetRandomLocation(), Quaternion.identity, asteroidsParent);
        }
    }

    private Vector2 GetRandomLocation()
    {
        BoxCollider2D spawnArea = spawnAreas[UnityEngine.Random.Range(0, spawnAreas.Length)];
        Bounds bounds = spawnArea.bounds;

        float xPos = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
        float yPos = UnityEngine.Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(xPos, yPos);
    }
}
