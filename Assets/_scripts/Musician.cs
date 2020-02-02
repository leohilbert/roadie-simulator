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

    public AudioClip clipEquipment;

    // Start is called before the first frame update
    public virtual void Start()
    {
        beerSprite.GetComponent<Renderer>().enabled = false;
        audioSource.clip = clipNoError;
        audioSource.Play();
        thirst = UnityEngine.Random.Range(0.7f, 1.0f);
    }

    void ChangeClip(AudioClip clip)
    {
        if (clip && (audioSource.clip != clip))
        {
            float t = audioSource.time;
            audioSource.clip = clip;
            audioSource.Play();
            audioSource.time = t;
            audioSource.mute = false;
        }
        else if (clip == null)
        {
            audioSource.mute = true;
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        AudioClip clip = clipNoError;

        if (thirst < 0.5)
        {
            beerSprite.GetComponent<Renderer>().enabled = true;
            clip = clipRhyhthm;
        }
        else
        {
            beerSprite.GetComponent<Renderer>().enabled = false;
        }

        if (equipment)
        {
            if (equipment.isFailing)
            {
                clip = clipEquipment;
            }
            else if (equipment.isBroken)
            {
                clip = null;
            }
        }

        ChangeClip(clip);
    }
    public virtual void FixedUpdate()
    {
        thirst = Math.Max(0.0f, thirst - UnityEngine.Random.Range(0.0f, 1.0f) * Time.fixedDeltaTime * 0.05f);
    }

    public void ReceiveBeer()
    {
        thirst = Math.Max(0.0f, Math.Min(thirst + 0.5f, 1.0f));
    }

    public float GetStatus()
    {
        float status = thirst;

        if (equipment)
        {
            if (equipment.isBroken)
            {
                return 0;
            }
            else if (equipment.isFailing)
            {
                return thirst / 2.0f;
            }

        }

        return thirst;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            ReceiveBeer();
        }
    }
}
