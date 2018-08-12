using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayZoneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTERING NEW TRACK COLLISION");
        if (RaceTrackController.instance.decayInProgress == false)
        {
            TrackSegment parentTrack = gameObject.GetComponentInParent<TrackSegment>();
            if (parentTrack.hasBeenTraversed == false)
            {
                if (other.gameObject.tag == "Player" || other.gameObject.tag == "AI")
                {
                    Debug.Log("BEGIN DECAY");
                    RaceTrackController.instance.decayInProgress = true;
                    // track has now been traversed by atleast one player or npc, so we won't trigger decay any more for this track
                    parentTrack.hasBeenTraversed = true;
                    // Destroy the track
                    GameObject trackToRemove = RaceTrackController.instance.TheRaceTrack[0];
                    RaceTrackController.instance.TheRaceTrack.RemoveAt(0);
                    Object.Destroy(trackToRemove.gameObject);

                    RaceTrackController.instance.decayInProgress = false;

                    // Add new track
                    TrackGenerationController.instance.ContinueTrack(RaceTrackController.instance.TheRaceTrack);

                }
            }
        }
        // Do nothing, decay is already in progress
    }
}
