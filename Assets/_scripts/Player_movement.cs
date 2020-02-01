using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_movement : MonoBehaviour
{
    public float moveSpeed = 0.1f;

    Vector3 movement;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    Vector2 movementInput;

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        movement.x = movementInput.x;
        movement.z = movementInput.y;
        //Debug.Log("x: " + movement.x + ", z:" + movement.z);
        rb.MovePosition(rb.position - movement * moveSpeed);
    }
}
