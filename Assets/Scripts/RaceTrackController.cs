using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTrackController : MonoBehaviour {

    public static RaceTrackController instance;
    
    public int raceTrackSize = 10;
    internal List<GameObject> TheRaceTrack { get; set; }
    internal TrackGenerationController TrackGenerator { get; set; }
    internal bool decayInProgress { get; set; } = false;


    //Awake is always called before any Start functions
    void Awake()
    {
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
        RaceTrackController.instance.initializeRaceTrack();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void initializeRaceTrack() {
        this.TheRaceTrack = TrackGenerationController.instance.generateInitialTrack(raceTrackSize);
    }

}
