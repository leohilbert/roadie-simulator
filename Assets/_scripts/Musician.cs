using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Musician : MonoBehaviour
{
    // How thirsty the musician is. 1 = not thirsty, 0 = dying
    public double thirst = 1.0;
    // Health of the musician. 1 = fit, 0 = dead
    public double health;

    public GameObject beerSprite;
    public GameObject intrument;

    public AudioSource audioSource;

    // Start is called before the first frame update
    public virtual void Start()
    {
        beerSprite.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (thirst < 0.5)
        {
            beerSprite.GetComponent<Renderer>().enabled = true;
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
        else
        {
            beerSprite.GetComponent<Renderer>().enabled = false;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
    public virtual void FixedUpdate()
    {
        System.Random random = new System.Random();

        thirst -= random.NextDouble() * Time.fixedDeltaTime * 0.1;
    }

    public void ReceiveBeer()
    {
        thirst = Math.Max(thirst + 0.5f, 1.0f);
    }

    public double GetStatus()
    {
        return thirst;
    }
}
