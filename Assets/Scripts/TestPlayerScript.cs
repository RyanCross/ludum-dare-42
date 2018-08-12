using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerScript : MonoBehaviour {

    public Rigidbody rb;

    private void Start()
    {
        rb.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * 2;
        float z = Input.GetAxis("Vertical") * 2;

        Vector3 movement = new Vector3(x, 0.0f, z);
        rb.AddForce(movement * 2);
    }
}
