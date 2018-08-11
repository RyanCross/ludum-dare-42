using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerationController : MonoBehaviour {


    public TrackSegment[] trackSegmentPrefabs;

    // eventually we'll want to get these values from the controller script controlling the state of track.
    public int raceTrackSize = 10;
    public List<GameObject> theRaceTrack = new List<GameObject>();

    // Use this for initialization
    void Start () {
        generateInitialTrack(raceTrackSize);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void generateInitialTrack (int raceTrackSize)
    {
        for (int i = 0; i < raceTrackSize; i++)
        {
            GameObject newTrackSegment;
            if (theRaceTrack.Count == 0)
            {
                newTrackSegment = Object.Instantiate(trackSegmentPrefabs[0].trackSegmentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                theRaceTrack.Add(newTrackSegment);
            }
            else
            {
                GameObject previousSegment = theRaceTrack[theRaceTrack.Count - 1];
                Transform transform = previousSegment.GetComponent<Transform>();
      
                // Get the vertices of the end face of the track segment
                newTrackSegment = Object.Instantiate(trackSegmentPrefabs[0].trackSegmentPrefab, new Vector3((transform.localPosition.x + transform.localScale.x), 0, 0), Quaternion.identity);

                // Connect the previous segment to the new segment in the eyes of the AI.
                previousSegment.GetComponent<Track>().exit.next = newTrackSegment.GetComponent<Track>().entry;

                theRaceTrack.Add(newTrackSegment);
            }
        }
    }

    
}
