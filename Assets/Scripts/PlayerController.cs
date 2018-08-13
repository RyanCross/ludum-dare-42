using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float deathY; 

    private void Start()
    {
        deathY = GameController.instance.deathY;
    }

    private void FixedUpdate()
    {
        if (FellTooFar())
        {
            Die ();
        }
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
