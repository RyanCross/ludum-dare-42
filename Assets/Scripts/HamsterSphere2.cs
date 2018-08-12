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

    private void FixedUpdate()
    {
        float turning = Input.GetAxis("Horizontal");
        rigBod.AddRelativeTorque(Vector3.up * PlayerTurnSpeed * turning);

        float accelerate = Input.GetAxis("Vertical");
        rigBod.AddRelativeTorque(Vector3.forward * PlayerRollSpeed * accelerate);
    }
}
