using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayZoneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "AI")
        {
            RaceTrackController raceTrackController = GameObject.FindGameObjectWithTag("RaceTrack").GetComponent<RaceTrackController>();

            //decay the first piece of the track in the list
        }
    }

}
