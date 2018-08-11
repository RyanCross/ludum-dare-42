using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public int Number { get; } = -1;

    public Waypoint(int number)
    {
        Number = number;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("AI"))
        {
            other.GetComponent<RacerAI>().ModifyTargetWaypoint(Number);
        }
    }
}
