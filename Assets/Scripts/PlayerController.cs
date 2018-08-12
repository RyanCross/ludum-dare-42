using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float deathY; 

    private void Start()
    {
        deathY = GameObject.FindWithTag("GameController").GetComponent<GameController> ().deathY;
        rb.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (FellTooFar())
        {
            Die ();
        }

        float x = Input.GetAxis("Horizontal") * 2;
        float z = Input.GetAxis("Vertical") * 2;

        Vector3 movement = new Vector3(x, 0.0f, z);
        rb.AddForce(movement * 2);
    }

    private bool FellTooFar()
    {
        Debug.Log(deathY);
        return this.transform.position.y < deathY;
    }

    private void Die ()
    {
        Debug.Log("WE DEAD");
        SceneManager.LoadScene(3);
    }
}
