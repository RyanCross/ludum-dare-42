using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerAI : MonoBehaviour, IRacer {

    // Needs to be set at the start of the race to the first waypoint, probably.
    // i.e., drag first waypoint here in the inspector
    public Waypoint _currentWaypoint;

    public bool Dead { get; set; } = false;
    public float speed = 0.3f;
    public float wobbliness = .2f;
    public float waypointInaccuracy = 2.0f;

    private void Start()
    {

    }

    void FixedUpdate()
    {
        Move();
        if(Random.value < wobbliness)
        {
            ResetRotation();
        }
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

        gameObject.transform.Translate(0f, 0f, speed);
    }
    
    // Do nothing, for now
    public void Win()
    {    
        Debug.Log(this.ToString() + " died!");
    }

    // We entered a new zone for a waypoint. Go towards the next one
    public void ModifyTargetWaypoint(Waypoint waypoint)
    {
        _currentWaypoint = waypoint;
        ResetRotation();
    }

    private void ResetRotation()
    {
        Vector3 fuzziness = GenerateFuzziness(0.0f, waypointInaccuracy);
        gameObject.transform.LookAt(_currentWaypoint.transform.position + fuzziness);
    }

    // We don't want all the enemy race boys bumping into each other.
    private Vector3 GenerateFuzziness(float min = 0.0f, float max = 1.0f)
    {
        return new Vector3()
        {
            x = Random.Range(min, max),
            y = 0f,
            z = Random.Range(min, max)
        };
    }
}
