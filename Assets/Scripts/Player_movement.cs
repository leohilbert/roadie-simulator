using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float moveSpeed = 0.1f;

    //public string left, right, forward, backward;

    Vector3 movement;

    public Rigidbody rb;

    private void FixedUpdate()
    {
        //Debug.Log("Left: " + Input.GetAxis(left) + ", right: " + Input.GetAxis(right));
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        //Vector3 next_position = new Vector3(gameObject.transform.position.x + Input.GetAxis(left);
        rb.MovePosition(rb.position + movement * moveSpeed);
    }
}
