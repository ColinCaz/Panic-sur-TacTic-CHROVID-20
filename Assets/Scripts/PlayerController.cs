using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 0.25f;
    public float rotationSpeed = 5;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public int minXRotation = -15;
    public int maxXRotation = 15;
    public bool invertVertical = false;

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
        Quaternion rotation = Quaternion.Euler(new Vector3((invertVertical ? 1 : -1) * Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0.0f) * rotationSpeed);
        rotation *= rb.rotation;
        rb.MoveRotation(rotation);
    }

    void Update()
    {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        if (eulerRotation.x > 180)
        {
            if (eulerRotation.x < 360 + minXRotation)
            {
                transform.Rotate(new Vector3(-eulerRotation.x + minXRotation, 0, -eulerRotation.z));
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, -eulerRotation.z));
            }
        }
        else
        {
            if (eulerRotation.x > maxXRotation)
            {
                transform.Rotate(new Vector3(-eulerRotation.x + maxXRotation, 0, -eulerRotation.z));
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, -eulerRotation.z));
            }
        }
        //transform.Rotate(new Vector3(-eulerRotation.x, 0, -eulerRotation.z));
    }
}