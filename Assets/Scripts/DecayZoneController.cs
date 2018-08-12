using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayZoneController : MonoBehaviour
{
    // How many pieces should we allow between first and last place?
    private int _maxGap = 2;
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
                    // If this track is way too far from the guy in the back
                    int distance = TrackGenerationController.Instance.PiecesPlaced + parentTrack.Ordinal - TrackGenerationController.Instance.raceTrackSize;
                    //Debug.Log("Pieces Placed = " + TrackGenerationController.Instance.PiecesPlaced);
                    //Debug.Log("Ordinal = " + parentTrack.Ordinal);
                    Debug.Log("distance = " + distance);
                    Debug.Log("maxGap = " + _maxGap);
                    if (distance <= _maxGap)
                    {
                        Debug.Log("distance too short");
                        return;
                    }
                    Debug.Log("Enough Distance");
                    
                    GameObject trackToRemove = RaceTrackController.Instance.TheRaceTrack[0];
                    //This will immediately remove the track as soon as the player enters it
                    trackToRemove.gameObject.SetActive(false);
                    RaceTrackController.Instance.TheRaceTrack.RemoveAt(0);
                    

                    RaceTrackController.Instance.decayInProgress = false;

                    // Add new track
                    TrackGenerationController.Instance.ContinueTrack(RaceTrackController.Instance.TheRaceTrack);
                }
            }
        }
        // Do nothing, decay is already in progress
    }
}
