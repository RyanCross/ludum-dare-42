using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(1f, 0.0f, 0.0f);
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(movement * 200);
        }
    }
}
