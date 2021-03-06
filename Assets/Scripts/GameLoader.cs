﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour {

    public GameObject gameControllerPrefab;             //GameManager prefab to instantiate.
    public GameObject raceTrackControllerPrefab;         //RaceTrackController prefab to instantiate.
    public GameObject trackGenerationControllerPrefab;   //TrackGenerationController prefab to instantiate
    public TrackSegment[] trackSegmentPrefabs; //Track pieces that will be used for procedural generation
    public GameObject countdownControllerPrefab;             //CountdownController prefab to instantiate.
    public TrackSegment startingTrackSegmentPrefab;

    void Awake()
    {
        Debug.Log("Ensure all TrackPieces have decay trigger zones, start/end faces, waypoints and have been assigned to track segment prefabs");
        if (trackSegmentPrefabs.Length == 0)
        {
            Debug.Log("No track prefabs loaded");
            QuitGame();

        }
        //Check if a GameController has already been assigned to static variable GameManager.instance or if it's still null
        if (GameController.instance == null)
        {
            //Instantiate gameManager prefab
            Instantiate(gameControllerPrefab);
        }
        else
        {
            Debug.Log("No game controller, is the prefab instance assigned?");
            QuitGame();
        }

        if (RaceTrackController.Instance == null)
        {
            Instantiate(raceTrackControllerPrefab);
        }
        else
        {
            Debug.Log("No race track singleton to hold racetrack information, is the prefab instance assigned?");
            QuitGame();
        }

        if (TrackGenerationController.Instance == null)
        {
            Instantiate(trackGenerationControllerPrefab);
            TrackGenerationController.Instance.StartPiece = startingTrackSegmentPrefab;
        }
        else
        {
            Debug.Log("No track generation controller, is the prefab instance assigned?");
            QuitGame();
        }

        if (CountdownController.instance == null)
        {
            Instantiate(countdownControllerPrefab);
        }
        else
        {
            Debug.Log("No countdown controller, is the prefab instance assigned?");
            QuitGame();
        }
    }

    void QuitGame()
    {
    #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
    #else
             Application.Quit();
    #endif
    }
}
