using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCam : MonoBehaviour
{

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;
    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensivityX = 5.0f;
    private float sensivityY = 5.0f;


    // Use this for initialization
    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
        //Set Cursor to not be visible
        Cursor.visible = false;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {

        Vector3 dir = new Vector3(0, 0, - distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX * sensivityX, 0);
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}