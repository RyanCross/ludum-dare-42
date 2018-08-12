using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterCamster : MonoBehaviour
{

    GameObject HamBall;
    float middleOfTrack = 0f;

    // Use this for initialization
    void Start()
    {
        HamBall = GameObject.Find("HamsterBall");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        Camera.main.transform.position = new Vector3(HamBall.transform.position.x + 4, HamBall.transform.position.y + 3, middleOfTrack);
    }
}
