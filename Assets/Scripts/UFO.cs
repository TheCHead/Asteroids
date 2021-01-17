using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] int hits = 4;
    [SerializeField] int scorePoints = 300;
    [SerializeField] float lifeTime = 8f;
    [SerializeField] float changeDirTime = 2f;
    [SerializeField] float speed = 5f;
    [SerializeField] ParticleSystem explosion = null;
    float direction;

    float lifeTimeCounter = 0f;
    float changeDirCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        direction = UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad;
    }

    // Update is called once per frame
    void Update()
    {
        
        lifeTimeCounter += Time.deltaTime;
        
        if (lifeTimeCounter >= lifeTime)
        {
            Destroy(gameObject);
        }

        changeDirCounter += Time.deltaTime;

        if (changeDirCounter >= changeDirTime)
        {
            ChangeDirection();
        }

        transform.Translate(Mathf.Cos(direction) * speed * Time.deltaTime, Mathf.Sin(direction) * speed * Time.deltaTime, 0, Space.World);
    }


    private void ChangeDirection()
    {
        direction += UnityEngine.Random.Range(-45, 45) * Mathf.Deg2Rad;
        changeDirCounter = 0f;
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        hits--;
        if (hits <= 0)
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        FindObjectOfType<ScoreDisplay>().AddToScore(scorePoints);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
