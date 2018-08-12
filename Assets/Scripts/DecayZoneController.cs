using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayZoneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTERING NEW TRACK COLLISION");
        if (RaceTrackController.Instance.decayInProgress == false)
        {
            TrackSegment parentTrack = gameObject.GetComponentInParent<TrackSegment>();
            if (parentTrack.hasBeenTraversed == false)
            {
                if (other.gameObject.tag == "Player" || other.gameObject.tag == "AI")
                {
                    Debug.Log("BEGIN DECAY");
                    RaceTrackController.Instance.decayInProgress = true;
                    // track has now been traversed by atleast one player or npc, so we won't trigger decay any more for this track
                    parentTrack.hasBeenTraversed = true;
                    // Destroy the track
                    GameObject trackToRemove = RaceTrackController.Instance.TheRaceTrack[0];
                    RaceTrackController.Instance.TheRaceTrack.RemoveAt(0);
                    
                    //This will immediately remove the track as soon as the player enters it
                    // trackToRemove.gameObject.SetActive(false);

                    RaceTrackController.Instance.decayInProgress = false;

                    // Add new track
                    TrackGenerationController.Instance.ContinueTrack(RaceTrackController.Instance.TheRaceTrack);

                }
            }
        }
        // Do nothing, decay is already in progress
    }
}
