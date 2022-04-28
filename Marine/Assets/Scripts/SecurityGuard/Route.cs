using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = new List<Transform>();
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

    //Deprecated
    /*private int GetIndexOfWaypoint(Transform waypoint)
    {
        return waypoints.IndexOf(waypoint);
    }*/

    public Transform GetNextWaypoint(Transform waypoint)
    {
        int currentWaypointIndex = waypoints.IndexOf(waypoint);
        
        if(currentWaypointIndex == GetRouteLength())
        {
            return waypoints[0]; //return to start of path
        }
        return waypoints[currentWaypointIndex + 1];
    }

    //EDITOR: visual feedback for the route 
    private void OnDrawGizmos()
    {
        if(waypoints.Count == 0)
        {
            return;
        }

        for (int index = 0; index <= GetRouteLength(); index++)
        {
            if(index == GetRouteLength())
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