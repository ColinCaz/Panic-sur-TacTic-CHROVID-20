using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 0.25f;
    public float rotationSpeed = 10;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        movement = transform.TransformDirection(movement);
        rb.MovePosition(transform.position + movement * movementSpeed);
        Quaternion rotation = Quaternion.Euler(new Vector3(0.0f, Input.GetAxis("Mouse X"), 0.0f) * rotationSpeed);
        rb.MoveRotation(rb.rotation * rotation);
        
    }
}
