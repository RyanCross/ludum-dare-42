using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    public GameObject pickUpEffect;
    public float growSize = 1.7f;
    public  enum PowerUpType { BIG, SPEED };
    public PowerUpType powerUpType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    void PickUp(Collider owner)
    {
        Debug.Log("Speeed Booooost!");

        // spawn cool effect
        Instantiate(pickUpEffect, transform.position, transform.rotation);

        switch (powerUpType)
        {
            case PowerUpType.BIG:
                owner.transform.localScale *= growSize;
                break;
            case PowerUpType.SPEED:
                //increase player speed
                break;

        }
        //apply effect to player
        owner.transform.localScale *= growSize;

        Destroy(gameObject);
    }
}
