using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    public Waypoint next;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("AI"))
        {
            //Debug.Log("AI reached a checkpoint");
            other.GetComponent<RacerAI>().ModifyTargetWaypoint(next);
        }
    }
}
