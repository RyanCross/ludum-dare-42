using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimerScript : MonoBehaviour {

    GameObject HamBall;
    GameObject Aimer;
    public float PlayerTurnSpeed;

	// Use this for initialization
	void Start () 
    {
        HamBall = GameObject.Find("HamsterBall");
        Aimer = GameObject.Find("Aimer");
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        Aimer.transform.position = new Vector3(HamBall.transform.position.x - 3, HamBall.transform.position.y, HamBall.transform.position.z);

        transform.Rotate(0, Input.GetAxis("Horizontal") * PlayerTurnSpeed * Time.deltaTime, 0);
    }
}
