using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{

    public bool isBroken;
    
    public bool isFailing;

    public double breakingProbability = 0.0001;

    public double failingProbability = 0.001;

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
        
        //GetComponent<Renderer>().enabled = false;
    }

    public void Fail()
    {

    }

    
}
