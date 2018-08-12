using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
    PlayerController player;
    TrackGenerationController trackGenerationController;

    public float deathY { get; set; } = -15f;

    // To be set in inspector
    public int numAIs = 1;

	// Use this for initialization
	void Start () 
    {
        RacerAI.OnAIDeath += EnemyDeath;
        SpawnRacers();
	}

    private void Awake()
    {
        RaceCountdown();
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
