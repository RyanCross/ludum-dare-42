using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayZoneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "AI")
        {
            if (RaceTrackController.instance.decayInProgress == true)
            {
                // Do nothing, decay is already in progress
            }
            else
            {
                GameObject trackToRemove = RaceTrackController.instance.TheRaceTrack[0];
                RaceTrackController.instance.TheRaceTrack.RemoveAt(0);
                Object.Destroy(trackToRemove);
            }

            

            //decay the first piece of the track in the list
        }
    }

}
