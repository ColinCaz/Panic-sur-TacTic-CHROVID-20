using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement_aleatoire : MonoBehaviour
{
    private Rigidbody rb;
    public float movementSpeed = 0.25f;
    public float rotationSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, 0.0f) * rotationSpeed);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(1f, 0.0f, 1f);
        transform.Translate(movement * movementSpeed);
    }
}