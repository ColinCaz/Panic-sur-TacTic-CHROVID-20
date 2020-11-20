using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 0.25f;
    public float rotationSpeed = 5;
    public float jumpHeight = 25000;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public int minXRotation = -15;
    public int maxXRotation = 15;
    public bool invertVertical = false;

    public GameObject Minimap;
    public GameObject Map;

    public GameObject minimapCamera;
    public GameObject mapCamera;

    public GameObject borderGun;
    public GameObject borderGrenade;

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
        rb.MovePosition(transform.position + movement * movementSpeed * Time.timeScale);
        Quaternion rotation = Quaternion.Euler(new Vector3((invertVertical ? 1 : -1) * Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0.0f) * rotationSpeed * Time.timeScale);
        rotation *= rb.rotation;
        rb.MoveRotation(rotation);
        if ((Input.GetKeyDown("right shift") || Input.GetKeyDown("left shift") || Input.GetKeyDown("space")) && transform.position.y < 0.5f)
        {
            rb.AddForce(Vector3.up * jumpHeight * Time.timeScale);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("escape") && Time.timeScale != 0)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
        }
        if (Input.GetKeyDown("1") || Input.GetKeyDown("[1]"))
        {
            borderGrenade.SetActive(false);
            borderGun.SetActive(true);
        }
        if (Input.GetKeyDown("2") || Input.GetKeyDown("[2]"))
        {
            borderGun.SetActive(false);
            borderGrenade.SetActive(true);
        }
        if ((Input.GetKeyDown("m") || Input.GetKeyDown("tab")) && Time.timeScale != 0)
        {
            Minimap.SetActive(false);
            Map.SetActive(true);
        }
        if ((Input.GetKeyUp("m") || Input.GetKeyUp("tab")) && Time.timeScale != 0)
        {
            Map.SetActive(false);
            Minimap.SetActive(true);
        }

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