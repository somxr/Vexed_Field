using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbors();
    }

    private void ExploreNeighbors()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[neighborCoordinates].SetTopColor(Color.green);
            }
            catch
            {
                //do nothing
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.red);
        endWaypoint.SetTopColor(Color.black);
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();

        foreach(Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();
      
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block at " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }
}
