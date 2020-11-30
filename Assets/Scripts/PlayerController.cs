using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 0.25f;
    public float jumpHeight = 50000;
    public float rotationSpeed = 10;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public int minXRotation = -15;
    public int maxXRotation = 15;

    public GameObject minimapCamera;
    public GameObject mapCamera;

    void Start()
    {
        Cursor.visible = false;
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
        rb.AddForce(transform.position + movement * movementSpeed * Time.timeScale);
        
        Quaternion rotation = Quaternion.Euler(new Vector3(PlayerPrefs.GetInt("Inversion", -1) * Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0.0f) * rotationSpeed * Time.timeScale);
        rotation *= rb.rotation;
        rb.MoveRotation(rotation);
        
       // transform.Rotate(new Vector3(PlayerPrefs.GetInt("Inversion", -1) * Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * PlayerPrefs.GetInt("Sensibilite", 10) * Time.timeScale, Space.Self);

        if ((Input.GetKeyDown("right shift") || Input.GetKeyDown("left shift") || Input.GetKeyDown("space")) && transform.position.y < 0.5f)
        {
            rb.AddForce(Vector3.up * jumpHeight * Time.timeScale);
        }
    }

    void Update()
    {
        mapCamera.transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        minimapCamera.transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(90, transform.rotation.eulerAngles.y, 0);
        mapCamera.transform.rotation = rotation;
        minimapCamera.transform.rotation = rotation;

        Vector3 eulerRotation = transform.rotation.eulerAngles;
        if (eulerRotation.x > 180)
        {
            if (eulerRotation.x < 360 + minXRotation)
            {
                rb.AddForce(new Vector3(-eulerRotation.x + minXRotation, 0, -eulerRotation.z));
            }
            else
            {
                rb.AddForce(new Vector3(0, 0, -eulerRotation.z));
            }
        }
        else
        {
            if (eulerRotation.x > maxXRotation)
            {
                rb.AddForce(new Vector3(-eulerRotation.x + maxXRotation, 0, -eulerRotation.z));
            }
            else
            {
                rb.AddForce(new Vector3(0, 0, -eulerRotation.z));
            }
        }
    }
}