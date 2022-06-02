using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    List<Transform> path = new List<Transform>();
    [Header("NEVER USE BLUE, THAT COLOR IS AN INDICATOR FOR THE LAST WAYPOINT")]
    [SerializeField] Color pathColor; //NEVER USE BLUE

    public int GetRouteLength()
    {
        return waypoints.Count - 1;
    }

    public List<Transform> GetWaypoints()
    {
        return waypoints;
    }

    ///<returns>Returns the transform of a waypoint</returns>
    public Transform GetWaypoint(int index)
    {
        return waypoints[index];
    }

    public Transform FindNearestWaypointToGameobject(GameObject target, float desiredDistance)
    {
        Transform desiredWaypoint = null;
        float desiredWaypointDistance = 999999;
        foreach (Transform waypoint in waypoints)
        {
            Vector3 directionToTarget = waypoint.position - target.transform.position;
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (desiredWaypointDistance > (dSqrToTarget + desiredDistance))
            {
                desiredWaypointDistance = dSqrToTarget;
                desiredWaypoint = waypoint;
            }
        }
        return desiredWaypoint;
    }

    public Transform FindBestPathToWaypoint(Transform currentWaypoint, Transform targetWaypoint)
    {
        //NOTE: There is a more efficient way of doing this, I'm just not the one to write it
        int indexOfCurrentWaypoint = GetIndexOfWaypoint(currentWaypoint);
        int indexOfTargetWaypoint = GetIndexOfWaypoint(targetWaypoint);

        float distanceUp, distanceDown = 0;
        Transform down = null;
        Transform up = null;

        if((indexOfCurrentWaypoint + 1) > waypoints.Count - 1)
        {
            distanceUp = Vector3.Distance(waypoints[indexOfCurrentWaypoint + 1].position, targetWaypoint.position);
            up = waypoints[indexOfCurrentWaypoint + 1];
        }
        else
        {
            distanceUp = Vector3.Distance(waypoints[0].position, targetWaypoint.position);
            up = waypoints[0];
        }

        if (indexOfCurrentWaypoint - 1 < 0)
        {
            distanceDown = Vector3.Distance(waypoints[waypoints.Count].position, targetWaypoint.position);
            down = waypoints[waypoints.Count];
        }
        else
        {
            distanceDown = Vector3.Distance(waypoints[0].position, targetWaypoint.position);
            down = waypoints[0];
        }

        if(distanceDown < distanceUp)
        {
            return down;
        }
        return up;
    }

    private int GetIndexOfWaypoint(Transform waypoint)
    {
        return waypoints.IndexOf(waypoint);
    }

    //Deprecated
    /*private int GetIndexOfWaypoint(Transform waypoint)
    {
        return waypoints.IndexOf(waypoint);
    }*/

    public Transform GetNextWaypoint(Transform waypoint)
    {
        int currentWaypointIndex = waypoints.IndexOf(waypoint);

        if (currentWaypointIndex == GetRouteLength())
        {
            return waypoints[0]; //return to start of path
        }
        return waypoints[currentWaypointIndex + 1];
    }

    //EDITOR: visual feedback for the route 
    private void OnDrawGizmos()
    {
        if (waypoints.Count == 0)
        {
            return;
        }

        for (int index = 0; index <= GetRouteLength(); index++)
        {
            if (index == GetRouteLength())
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(waypoints[GetRouteLength()].position, waypoints[0].position);
                return;
            }
            Gizmos.color = pathColor;
            Gizmos.DrawLine(waypoints[index].position, waypoints[index + 1].position);
        }
    }
}