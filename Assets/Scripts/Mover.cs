using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField] float translationSpeed = 5f;
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] ParticleSystem[] thrusters = null;
    [SerializeField] float invincibilityTime = 2f;



    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        float translation = Mathf.Clamp(Input.GetAxis("Vertical"), -0.25f, 1f) * translationSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, translation * Time.deltaTime), ForceMode2D.Force);
        transform.Rotate(0, 0, -rotation * Time.deltaTime);

        if (translation > 0)
        {
            foreach (ParticleSystem thruster in thrusters)
            {
                if (!thruster.isPlaying)
                {
                    thruster.Play();
                }
            }
        }
        else
        {
            foreach (ParticleSystem thruster in thrusters)
            {
                thruster.Stop();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<LivesDisplay>().TakeLife();
        StartCoroutine(GetInvincible());
        transform.position = Vector2.zero;
    }

    private IEnumerator GetInvincible()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = Color.gray;
        GetComponent<Shooter>().DisableShooting();
        yield return new WaitForSeconds(invincibilityTime);
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<Shooter>().EnableShooting();
    }
}
