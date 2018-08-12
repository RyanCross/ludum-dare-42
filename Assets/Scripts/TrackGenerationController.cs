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


    void generateInitialTrack (int raceTrackSize) {
        for (int i = 0; i < raceTrackSize; i++)
        {
            if (theRaceTrack.Count == 0)
            {
                CreateStartOfTrack();
            }
            else
            {
                ContinueTrack();
            }
        }
    }

    void CreateStartOfTrack(Vector3 startPoint)
    {
        GameObject pieceToLay = SelectRandomPiece(trackSegmentPrefabs);
        GameObject newTrackSegment = Instantiate(pieceToLay, startPoint, Quaternion.identity);
        theRaceTrack.Add(newTrackSegment);
    }

    void CreateStartOfTrack()
    {
        CreateStartOfTrack(Vector3.zero);
    }

    void ContinueTrack()
    {
        GameObject previousSegment = theRaceTrack[theRaceTrack.Count - 1];
        GameObject pieceToLay = SelectRandomPiece(trackSegmentPrefabs);
        Vector3 newPosition = FindNewPosition(previousSegment, pieceToLay);

        // Get the vertices of the end face of the track segment
        GameObject newTrackSegment = Object.Instantiate(pieceToLay, newPosition, Quaternion.identity);

        ConnectWaypoints(previousSegment, newTrackSegment);
        theRaceTrack.Add(newTrackSegment);
    }

    Vector3 FindNewPosition(GameObject go, GameObject pieceToLay)
    {
        Vector3 startToCenter = pieceToLay.GetComponentInChildren<StartFace>().transform.position - pieceToLay.transform.position;
        Debug.Log("Start to center = " + startToCenter);
        Vector3 endPoint = go.GetComponentInChildren<EndFace>().transform.position;
        Debug.Log("EndPoint = " + endPoint);
        return endPoint - startToCenter;
    }

    GameObject SelectRandomPiece(TrackSegment[] options)
    {
        // TODO: Randomly select an option instead of always picking the straight piece.
        return options[0].trackSegmentPrefab;
    }

    // Connect the previous segment to the new segment in the eyes of the AI.
    void ConnectWaypoints(GameObject previousTrackSegment, GameObject newTrackSegment)
    {
        previousTrackSegment.GetComponent<Track>().exit.next = newTrackSegment.GetComponent<Track>().entry;
    }
}