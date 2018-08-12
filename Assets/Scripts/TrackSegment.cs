using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// telling unity that this class is Serializable will allow it to show up in the inspector
[System.Serializable]
public class TrackSegment : MonoBehaviour
{
    public Waypoint entry;
    public Waypoint exit;

    public GameObject trackSegmentPrefab;
    public GameObject CollisionZone;
}
