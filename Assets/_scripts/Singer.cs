using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singer : Musician
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        this.gameObject.transform.Translate(Time.fixedDeltaTime, 0, 0);
    }
}

