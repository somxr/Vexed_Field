using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
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
        print("Loaded " + grid.Count + " blocks");
    }
}
