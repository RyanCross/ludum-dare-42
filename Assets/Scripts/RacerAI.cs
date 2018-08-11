using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerAI : MonoBehaviour, IRacer {

    // Needs to be set at the start of the race to the first waypoint, probably.
    // i.e., drag first waypoint here in the inspector
    private int _currentWaypoint;

    public bool Dead { get; set; } = false;

    private void Start()
    {

    }

    public void Die()
    {
        Dead = true;
        Debug.Log(this.ToString() + " died!");

        // Some other stuff
    }
    
    // Probably will remove this from the scene, but for now...
    public void Move()
    {
        if (Dead) return;
        Debug.Log(this.ToString() + " is moving towards " + _currentWaypoint.ToString());
    }
    
    // Do nothing, for now
    public void Win()
    {    
        Debug.Log(this.ToString() + " died!");
    }

    // We entered a new zone for a waypoint. Go towards the next one
    public void ModifyTargetWaypoint(int number)
    {
        _currentWaypoint = number;
    }
}
