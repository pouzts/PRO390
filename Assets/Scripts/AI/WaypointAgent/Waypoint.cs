using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : Node
{
    public List<Waypoint> neighbors;
    public Waypoint previous;
    
    public float distance = 10f;

    public Color waypointColor;
    public Color waypointPathColor;

    public bool IsVisited { get; set; } = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = waypointColor;
        Gizmos.DrawSphere(transform.position, 0.1f);

        if (neighbors.Count > 0)
        {
            Gizmos.color = waypointPathColor;
            foreach (var waypoint in neighbors)
            {
                if (waypoint != null)
                    Gizmos.DrawLine(transform.position, waypoint.transform.position);
            }
        }
    }
}
