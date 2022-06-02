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

    public void FindBestPathToWaypoint(Transform currentWaypoint, Transform targetWaypoint)
    {
        //NOTE: There is a more efficient way of doing this, I'm just not the one to write it
        int indexOfCurrentWaypoint = GetIndexOfWaypoint(currentWaypoint);
        int indexOfTargetWaypoint = GetIndexOfWaypoint(targetWaypoint);

        int pathUp = 0, pathDown = 0;
        
        int indexer = indexOfCurrentWaypoint;
        while (true)
        {
            if (indexer == indexOfTargetWaypoint)
            {
                break;
            }
            else
            {
                if (indexer == GetRouteLength())
                {
                    indexer = 0;
                }
                indexer++;
                pathUp++;
            }
        }

        indexer = indexOfCurrentWaypoint;
        while (true)
        {
            if (indexer == indexOfTargetWaypoint)
            {
                break;
            }
            else
            {
                if (indexer == 0)
                {
                    indexer = GetRouteLength();
                }
                indexer--;
                pathDown++;
            }
        }

        List<Transform> newPath = new List<Transform>();
        if(pathUp < pathDown)
        {
            for (int index = indexOfCurrentWaypoint; index < pathUp; index++)
            {
                if(index == GetRouteLength())
                {
                    index = 0;
                }
                newPath.Add(waypoints[index]);
            }
        }
        else
        {
            for (int index = indexOfCurrentWaypoint; index > pathDown; index--)
            {

                if (index == 0)
                {
                    index = GetRouteLength();
                }
                newPath.Add(waypoints[index]);
            }
        }
        path = newPath;
    }

    private int GetIndexOfWaypoint(Transform waypoint
        )
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