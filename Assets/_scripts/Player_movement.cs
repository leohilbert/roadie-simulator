﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_movement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpSpeed = 100f;
    public float gravity = 25f;
    public Vector3 moveDirection = Vector3.zero;
    private float vSpeed = 0;

    List<GameObject> collided = new List<GameObject>();
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    Vector2 movementInput;
    bool jump;

    void OnCollisionEnter(Collision collision)
    {
        collided.Add(collision.gameObject);
    }

    void OnCollisionExit(Collision collision)
    {
        collided.Remove(collision.gameObject);
    }

    void OnHit(InputValue value)
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

    void OnMove(InputValue value)
    {
        movementInput = -value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        jump = value.isPressed;
    }

    void Update()
    {
        moveDirection = new Vector3(movementInput.x, 0, movementInput.y);
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 0.80F);
        }

        moveDirection *= moveSpeed;
        if (characterController.isGrounded)
        {
            vSpeed = -1;
            if (Input.GetButtonDown("Jump"))
            {
                vSpeed = jumpSpeed;
            }
        }
        vSpeed -= gravity * Time.deltaTime;
        moveDirection.y = vSpeed;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
