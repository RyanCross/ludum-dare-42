using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterSphere : MonoBehaviour {
    
    float speed    = 10.0f;
    float distance = 10.0f;
    float height   = 10.0f;
    float damping  = 2.0f;

    void Start()
    {
        if (!GetComponent<Rigidbody>())
            gameObject.AddComponent(typeof(Rigidbody));

        // setup camera
        var trans = Camera.main.transform;
        var wantedPosition = new Vector3(0, height, distance);
        wantedPosition += transform.position;
        trans.position = wantedPosition;
        trans.LookAt(transform);
    }

    void FixedUpdate()
    {
        var move = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
        if (move.magnitude > 0.0)
        {
            var y = Camera.main.transform.position.y;
            //Keep camera height the same in relation to ball height
            Vector3 position = Camera.main.transform.position;
            position.y = transform.position.y;
            transform.position = position;

            move = Camera.main.transform.TransformDirection(move.normalized);

            gameObject.GetComponent<Rigidbody>().AddTorque(move * speed);

            position = Camera.main.transform.position;
            position.y = transform.position.y;
            transform.position = position;
        }
    }

    void LateUpdate()
    {
        var trans = Camera.main.transform;

        var wantedPosition = -gameObject.GetComponent<Rigidbody>().velocity;

        wantedPosition.y = 0;
        wantedPosition = wantedPosition.normalized * distance;
        wantedPosition.y = height;
        wantedPosition += transform.position;
        trans.position = Vector3.Lerp(trans.position, wantedPosition, damping * Time.deltaTime);
        trans.LookAt(transform);
    }
}
