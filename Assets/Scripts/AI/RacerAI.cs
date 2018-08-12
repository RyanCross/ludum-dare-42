using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerAI : MonoBehaviour, IRacer {

    public delegate void AIDeathAction();
    public static event AIDeathAction OnAIDeath;

    // Needs to be set at the start of the race to the first waypoint, probably.
    // i.e., drag first waypoint here in the inspector
    public Waypoint _currentWaypoint;

    public Rigidbody rb;
    float distanceToGround;

    public bool Dead { get; set; } = false;
    
    public float acceleration = 50f;
    public float aerialAcceleration = 5f;

    public float wobbliness = .2f;
    public float waypointInaccuracy = 2.0f;

    public bool isBoosting = false;
    public float boostAcceleration = 200f;

    public float deathY;

    private void Start()
    {
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
        deathY = GameObject.FindWithTag("GameController").GetComponent<GameController> ().deathY;
    }

    void FixedUpdate()
    {
        Move();

        if (FellTooFar())
        {
            Die();
        }
        if(Random.value > wobbliness)
        {
            ModifyTargetWaypoint(_currentWaypoint);
        }
    }
    
    private bool IsGrounded()
    {
        return Physics.Raycast(new Ray(transform.position, -Vector3.up), distanceToGround + .1f);
    }

    private bool FellTooFar()
    {
        return this.transform.position.y < deathY;
    }

    public void Die()
    {
        Dead = true;
        Debug.Log(this.ToString() + " died!");

        OnAIDeath();
        Destroy(gameObject);
    }
    
    // Probably will remove this from the scene, but for now...
    public void Move()
    {
        if (Dead) return;
        Debug.Log(this.ToString() + " is moving towards " + _currentWaypoint.ToString());

        Vector3 targetPosition = _currentWaypoint.transform.position;
        Vector3 myPosition = transform.position;

        Vector3 direction = (targetPosition - myPosition).normalized;

        Vector3 resultingForce = IsGrounded() ? acceleration * direction : aerialAcceleration * direction;

        rb.AddForce(resultingForce);
    }
    
    // Do nothing, for now
    public void Win()
    {    
        Debug.Log(this.ToString() + " won!");
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
        Vector3 composite = _currentWaypoint.transform.position + fuzziness;
        gameObject.transform.LookAt(composite);
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
