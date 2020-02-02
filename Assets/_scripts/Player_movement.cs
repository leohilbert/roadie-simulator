using System.Collections;
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

    private Equipment equipment;

    private Transform equipmentParent;

    List<GameObject> collided = new List<GameObject>();
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    Vector2 movementInput;
    bool jump;

    void OnTriggerEnter(Collider collider)
    {
        collided.Add(collider.gameObject);
    }

    void OnTriggerExit(Collider collider)
    {
        collided.Remove(collider.gameObject);
    }

    void OnHit(InputValue value)
    {
        if (equipment)
        {
            // drop equipment
            Debug.Log("drop equipoment");

            // set player as parent
            equipment.transform.parent = equipmentParent;

            // physics again
            equipment.GetComponent<Rigidbody>().isKinematic = false;

            // no more
            equipment = null;

            return;
        }

        foreach (GameObject collision in collided)
        {
            Fan fan = collision.GetComponent<Fan>();
            if (fan != null)
            {
                Debug.Log(fan);
                fan.kick(transform);
            }

            Equipment e = collision.GetComponent<Equipment>();
            if (e && !equipment)
            {
                Debug.Log("pick equipment");

                // remember me
                equipment = e;
                equipmentParent = equipment.transform.parent;

                // set player as parent
                equipment.transform.parent = transform;

                // no more physics
                equipment.GetComponent<Rigidbody>().isKinematic = true;

                // place infront of player
                equipment.transform.localPosition = (Vector3.forward * 0.5f + Vector3.up * 1.5f);
                equipment.transform.localRotation = Quaternion.identity;
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
            if (jump)
            {
                vSpeed = jumpSpeed;
            }
        }
        vSpeed -= gravity * Time.deltaTime;
        moveDirection.y = vSpeed;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
