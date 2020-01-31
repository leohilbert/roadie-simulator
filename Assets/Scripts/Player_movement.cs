using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float moveSpeed = 0.1f;

    Vector3 movement;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        Debug.Log("x: " + movement.x + ", z:" + movement.z);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position - movement * moveSpeed);
    }
}
