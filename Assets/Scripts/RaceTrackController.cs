using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTrackController : MonoBehaviour {

    // placeholder script for the class the holds the current state of the track.
    // Retrieves new TrackSegment information from the TrackGeneratorController.
    public int raceTrackSize = 10;
    internal List<GameObject> TheRaceTrack { get; set; }
    internal TrackGenerationController TrackGenerator { get; set; }


    // Use this for initialization
    void Start () {
        TrackGenerator = GameObject.FindGameObjectWithTag("TrackGenerator").GetComponent<TrackGenerationController>();
        initializeRaceTrack();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void initializeRaceTrack() {
        this.TheRaceTrack = TrackGenerator.generateInitialTrack(raceTrackSize);
    }


    void checkForDecay () {

    }
}
