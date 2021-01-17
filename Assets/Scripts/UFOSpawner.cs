using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    [SerializeField] BoxCollider2D[] spawnAreas = null;
    [SerializeField] GameObject ufoPrefab = null;
    [SerializeField] float timeBetweenSpawns = 15f;
    float counter = 0f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= timeBetweenSpawns)
        {
            SpawnUFO();
        }
    }

    private void SpawnUFO()
    {
        Instantiate(ufoPrefab, GetRandomLocation(), Quaternion.identity);
        counter = 0f;
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
