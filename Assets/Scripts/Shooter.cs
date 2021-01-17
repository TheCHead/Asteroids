using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] ParticleSystem bullets = null;
    bool ableToshoot = true;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ableToshoot)
            {
                bullets.Play();
            }

        }
        if (Input.GetButtonUp("Fire1") || !ableToshoot)
        {
            bullets.Stop();
        }
    }

    public void DisableShooting()
    {
        ableToshoot = false;
    }

    public void EnableShooting()
    {
        ableToshoot = true;
    }
}
