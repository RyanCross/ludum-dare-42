﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerationController : MonoBehaviour {

    public static TrackGenerationController instance = null;

    TrackSegment[] trackSegmentPrefabs;

    // eventually we'll want to get these values from the controller script controlling the state of track.
    public int raceTrackSize = 10;


    //Awake is always called before any Start functions
    void Awake()
    {
        trackSegmentPrefabs = GameObject.FindGameObjectWithTag("GameLoader").GetComponent<GameLoader>().trackSegmentPrefabs;
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }

    // Use this for initialization
    void Start () {
        generateInitialTrack(raceTrackSize);
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}


    internal List<GameObject> generateInitialTrack (int raceTrackSize) {
        List<GameObject> theRaceTrack = new List<GameObject>();
        for (int i = 0; i < raceTrackSize; i++)
        {
            if (theRaceTrack.Count == 0)
            {
                CreateStartOfTrack(theRaceTrack);
            }
            else
            {
                ContinueTrack(theRaceTrack);
            }
        }
        return theRaceTrack;
    }

    void CreateStartOfTrack(List<GameObject> initialRaceTrack, Vector3 startPoint)
    {
        // first track should probably always be the plain straight one (index 0)
        GameObject newTrackSegment = Instantiate(trackSegmentPrefabs[0].trackSegmentPrefab, startPoint, Quaternion.identity);
        initialRaceTrack.Add(newTrackSegment);
    }

    void CreateStartOfTrack(List<GameObject> initialRaceTrack)
    {
        CreateStartOfTrack(initialRaceTrack, Vector3.zero);
    }

    void ContinueTrack(List<GameObject> theRaceTrack)
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
        previousTrackSegment.GetComponent<TrackSegment>().exit.next = newTrackSegment.GetComponent<TrackSegment>().entry;
    }
}