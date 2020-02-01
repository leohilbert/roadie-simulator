using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_movement : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float jumpSpeed = 4f;
    Vector3 movement;

    List<GameObject> collided = new List<GameObject>();

    public Rigidbody rb;

    void Start()
    {
    }

    Vector2 movementInput;

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    void OnCollisionEnter(Collision collision)
    {
        collided.Add(collision.gameObject);
    }

    void OnCollisionExit(Collision collision)
    {
        collided.Remove(collision.gameObject);
    }

    void OnHit()
    {
        Debug.Log("Onhit");
        foreach (GameObject collision in collided)
        {
            Debug.Log(collision);
            Fan fan = collision.GetComponent<Fan>();
            if (fan != null)
            {
                fan.kick();
            }
        }
    }

    void OnJump()
    {
        if (IsGrounded())
        {
            rb.velocity += jumpSpeed * Vector3.up;
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1F);
    }

    private void FixedUpdate()
    {
        movement.x = movementInput.x;
        movement.z = movementInput.y;
        Debug.Log($"{movement.x} {movementInput.y}");
        //Debug.Log("x: " + movement.x + ", z:" + movement.z);
        rb.MovePosition(rb.position - movement * moveSpeed);
        rb.rotation = Quaternion.FromToRotation(Vector3.back, movement);
    }       
}
