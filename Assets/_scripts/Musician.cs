using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musician : MonoBehaviour
{
    // How thirsty the musician is. 1 = not thirsty, 0 = dying
    public float thirst = 1.0f;
    // Health of the musician. 1 = fit, 0 = dead
    public float health;

    public GameObject beerSprite;
    public GameObject intrument;

    public Equipment equipment;

    public AudioSource audioSource;

    public AudioClip clipNoError;
    
    public AudioClip clipRhyhthm;

    // Start is called before the first frame update
    public virtual void Start()
    {
        beerSprite.GetComponent<Renderer>().enabled = false;
        audioSource.clip = clipNoError;
        audioSource.Play();
        thirst = UnityEngine.Random.Range(0.7f, 1.0f);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (thirst < 0.5)
        {
            beerSprite.GetComponent<Renderer>().enabled = true;
            if (audioSource.clip != clipRhyhthm)
            {
                float t = audioSource.time;
                audioSource.clip = clipRhyhthm;
                audioSource.Play();
                audioSource.time = t;
            }
        }
        else
        {
            beerSprite.GetComponent<Renderer>().enabled = false;
            if (audioSource.clip != clipNoError)
            {
                float t = audioSource.time;
                audioSource.clip = clipNoError;
                audioSource.Play();
                audioSource.time = t;
            }
        }

        if (equipment && (equipment.isBroken|| equipment.isFailing))
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }

    }
    public virtual void FixedUpdate()
    {
        thirst -= UnityEngine.Random.Range(0.0f, 1.0f) * Time.fixedDeltaTime * 0.1f;
    }

    public void ReceiveBeer()
    {
        thirst = Math.Max(thirst + 0.5f, 1.0f);
    }

    public float GetStatus()
    {
        return thirst;
    }

    void OnTriggerEnter(Collider other)
    {
        ReceiveBeer();
    }
}
