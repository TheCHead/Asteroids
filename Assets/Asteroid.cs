using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float minStartSpeed = 1f;
    [SerializeField] float maxStartSpeed = 3f;

    [SerializeField] int hitsToDestroy = 3;
    [SerializeField] GameObject childAsteroid = null;
    [SerializeField] int childAsteroidsNum = 2;

    [SerializeField] int scorePoints = 100;

    [SerializeField] ParticleSystem explosion = null;

    [SerializeField] Transform asteroidsParent = null;

    float startSpeed = 1f;
    float startDirection = 0f;

    private void Start()
    {

        startSpeed = UnityEngine.Random.Range(minStartSpeed, maxStartSpeed);
        startDirection = UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Mathf.Cos(startDirection) * startSpeed * Time.deltaTime, Mathf.Sin(startDirection) * startSpeed * Time.deltaTime, 0, Space.World);
    }

    private void TakeDamage()
    {
        hitsToDestroy--;
        if (hitsToDestroy < 1)
        {
            DestroySequence();
        }
    }

    private void DestroySequence()
    {

        if (childAsteroid != null)
        {
            for (int i = 0; i < childAsteroidsNum; i++)
            {
                Instantiate(childAsteroid, transform.position, Quaternion.identity, asteroidsParent);
            }
        }

        FindObjectOfType<ScoreDisplay>().AddToScore(scorePoints);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage();
    }
}
