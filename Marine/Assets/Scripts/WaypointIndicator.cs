using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointIndicator : MonoBehaviour
{
    public Color myColor;

    void OnDrawGizmos()
    {
        // Draw a semitransparent green cube at the transforms position
        Gizmos.color = myColor;
        Gizmos.DrawSphere(transform.position, .4f);
    }
}
