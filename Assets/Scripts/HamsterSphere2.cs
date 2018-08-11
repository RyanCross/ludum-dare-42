using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterSphere2 : MonoBehaviour {

    public float PlayerRollSpeed;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void FixedUpdate()
    {
        //Character Controls
        gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.right * PlayerRollSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);

        gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.forward * PlayerRollSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

    }
}
