using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

    public static GameController instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    PlayerController player;
    private TrackGenerationController trackGenerationController;

    public float deathY { get; set; } = -15f;

    // To be set in inspector
    public int numAIs = 1;


    private void Awake()
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

        RaceCountdown();

    }

    // Use this for initialization
    void Start () 
    {
        RacerAI.OnAIDeath += EnemyDeath;
        SpawnRacers();
	}

    // Update is called once per frame
    void Update () 
    {
		
	}

    private void FixedUpdate()
    {
        
    }

    private void SpawnRacers()
    {

    }

    private void RaceCountdown()
    {

    }

    void EnemyDeath()
    {
        numAIs--;
        if (numAIs < 1)
        {
            SceneManager.LoadScene(2);
        }
    }
}
