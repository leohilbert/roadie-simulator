﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singer : Musician
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        this.gameObject.transform.Translate(Time.fixedDeltaTime, 0, 0);
    }
}

