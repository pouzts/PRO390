using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAgent : MonoBehaviour
{
    [SerializeField] private Waypoint startWaypoint;
    [SerializeField] private float speed = 1f;

    public Waypoint CurWaypoint { get; set; }

    private void Start()
    {
        CurWaypoint = startWaypoint;
    }

    private void Update()
    {
        if (CurWaypoint.neighbors.Count > 0)
        {
            var next = Node.GetRandomNode(CurWaypoint.neighbors);
            transform.LookAt(next.transform);
            transform.position += Vector3.MoveTowards(transform.position, next.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Waypoint waypoint))
        { 
            CurWaypoint = waypoint;
            CurWaypoint.IsVisited = true;
        }
    }
}
