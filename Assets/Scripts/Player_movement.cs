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

    PlayerInputActions inputActions;

    Vector2 movementInput;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        Debug.Log("x: " + movement.x + ", z:" + movement.z);
        rb.MovePosition(rb.position - movement * moveSpeed);
    }
}
