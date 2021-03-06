﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{

    public bool isBroken;
    
    public bool isFailing;

    public double breakingProbability = 0.0001;

    public double failingProbability = 0.001;

    public GameObject smokePrefab;

        private GameObject smoke;


    // Start is called before the first frame update
    void Start()
    {
        isBroken = false;
        isFailing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnTriggerEnter(Collider collider)
    {
        Equipment e = collider.gameObject.GetComponent<Equipment>();
        Debug.Log("Equ placed:" + e);
        if (e && e.GetType() == GetType() && isBroken)
        {
            isBroken = false;
            GameObject p = collider.gameObject;
            //while (p.transform.parent)
            //    p = p.transform.parent.gameObject;
            Destroy(p);

            if (smoke) Destroy(smoke);
        }
    }

    public virtual void FixedUpdate()
    {
        if (!isBroken)
        {
            if (Random.Range(0.0f, 1.0f) < breakingProbability)
            {
                isBroken = true;
                Break();
            }
            else if (Random.Range(0.0f, 1.0f) < failingProbability)
            {
                isFailing = true;
                Fail();
            }
            else
            {
                isFailing = false;
            }
        }

    }

    public void Break()
    {
        foreach (ParticleSystem ps in GetComponentsInChildren<ParticleSystem>())
        {
            ps.Play();
        }
        foreach (Detonator dt in GetComponentsInChildren<Detonator>())
        {
            dt.Explode();
        }
        
        smoke = Instantiate(smokePrefab, transform.position, Quaternion.identity, transform);

        //GetComponent<Renderer>().enabled = false;
    }

    public void Fail()
    {

    }

    
}
