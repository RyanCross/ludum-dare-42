using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterSphere2 : MonoBehaviour {

    public float PlayerRollSpeed;
    public float PlayerTurnSpeed;

    public float turn;

    public Rigidbody rigBod;

	// Use this for initialization
	void Start () 
    {
        rigBod = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void FixedUpdate()
    {
        if (Input.GetKey("w"))
            rigBod.AddTorque(Camera.main.transform.right * PlayerRollSpeed * Time.deltaTime);
        if (Input.GetKey("a"))
            rigBod.AddTorque(Camera.main.transform.forward * PlayerRollSpeed * Time.deltaTime);
        if (Input.GetKey("s"))
            rigBod.AddTorque(Camera.main.transform.right * -PlayerRollSpeed * Time.deltaTime);
        if (Input.GetKey("d"))
            rigBod.AddTorque(Camera.main.transform.forward * -PlayerRollSpeed * Time.deltaTime);
    }
}
