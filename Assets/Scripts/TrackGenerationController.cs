using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerationController : MonoBehaviour {

    private static TrackGenerationController _instance;

    public static TrackGenerationController Instance { get { return _instance; } }

    TrackSegment[] trackSegmentPrefabs;
    public TrackSegment StartPiece;

    public int PiecesPlaced
    {
        get;
        private set;
    } = 0;


    //Awake is always called before any Start functions
    void Awake()
    {
        trackSegmentPrefabs = GameObject.FindGameObjectWithTag("GameLoader").GetComponent<GameLoader>().trackSegmentPrefabs;
        //Check if instance already exists
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else
        {
            _instance = this;
        }
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    	
	}

    internal List<GameObject> generateInitialTrack (int raceTrackSize) {
        Debug.Log("Generating Initial Track");
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
        GameObject newTrackSegment = Instantiate(StartPiece.trackSegmentPrefab, startPoint, Quaternion.identity);
        TrackSegment track = newTrackSegment.GetComponentInParent<TrackSegment>();
        track.Ordinal = PiecesPlaced++;
        initialRaceTrack.Add(newTrackSegment);
        TellEnemiesToGoTo(track.entry);
    }

    void CreateStartOfTrack(List<GameObject> initialRaceTrack)
    {
        CreateStartOfTrack(initialRaceTrack, Vector3.zero);
    }

    internal void ContinueTrack(List<GameObject> theRaceTrack)
    {
        GameObject previousSegment = theRaceTrack[theRaceTrack.Count - 1];
        GameObject pieceToLay = SelectRandomPiece(trackSegmentPrefabs);
        Vector3 newPosition = FindNewPosition(previousSegment, pieceToLay);

        // Get the vertices of the end face of the track segment
        GameObject newTrackSegment = Object.Instantiate(pieceToLay, newPosition, Quaternion.identity);
        newTrackSegment.GetComponentInParent<TrackSegment>().Ordinal = PiecesPlaced++;

        ConnectWaypoints(previousSegment, newTrackSegment);
        theRaceTrack.Add(newTrackSegment);
    }

    Vector3 FindNewPosition(GameObject go, GameObject pieceToLay)
    {
        Vector3 startToCenter = pieceToLay.GetComponentInChildren<StartFace>().transform.position - pieceToLay.transform.position;
        Vector3 endPoint = go.GetComponentInChildren<EndFace>().transform.position;
        return endPoint - startToCenter;
    }

    GameObject SelectRandomPiece(TrackSegment[] options)
    {
        int randomIndex = (int) (Random.value * options.Length);
        return options[randomIndex].gameObject;
    }

    // Connect the previous segment to the new segment in the eyes of the AI.
    void ConnectWaypoints(GameObject previousTrackSegment, GameObject newTrackSegment)
    {
        previousTrackSegment.GetComponent<TrackSegment>().exit.next = newTrackSegment.GetComponent<TrackSegment>().entry;
    }

    void TellEnemiesToGoTo(Waypoint destination)
    {
        foreach(GameObject enemy in GameController.instance.Enemies)
        {
            enemy.GetComponent<RacerAI>()._currentWaypoint = destination;
        }
    }
}