using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circlepit : MonoBehaviour
{
    public float speed = 100;
    public float radius = 1;
    private Vector3 point;
    
    void Start()
    {
        speed = Random.Range(50F, 100F);
        radius = Random.Range(1F, 3F);
    }

    void Update()
    {
        transform.RotateAround(transform.parent.position + radius * Vector3.right, Vector3.up, speed * Time.deltaTime);
    }
}
