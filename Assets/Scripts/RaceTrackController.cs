using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTrackController : MonoBehaviour {

    private static RaceTrackController _instance;
    public static RaceTrackController Instance
    {
        get
        {
            return _instance;
        }
    }
    
    public int raceTrackSize = 10;
    internal List<GameObject> TheRaceTrack { get; set; }
    internal TrackGenerationController TrackGenerator { get; set; }
    internal bool decayInProgress { get; set; } = false;


    //Awake is always called before any Start functions
    void Awake()
    {
        if(_instance != null && _instance != this)
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

        Instance.initializeRaceTrack();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void initializeRaceTrack() {
        TheRaceTrack = TrackGenerationController.Instance.generateInitialTrack(raceTrackSize);
    }

}
