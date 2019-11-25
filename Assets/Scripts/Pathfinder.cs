using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Waypoint currentWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    bool isRunning = true;

    Queue<Waypoint> queue = new Queue<Waypoint>();

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

    List<Waypoint> path = new List<Waypoint>();

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;

        while(previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }

        path.Add(startWaypoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while(queue.Count > 0 && isRunning)
        {
            currentWaypoint = queue.Dequeue();
            HaltIfReachedEnd(currentWaypoint);
            ExploreNeighbors();
            currentWaypoint.isExplored = true;
        }
    }

    private void HaltIfReachedEnd(Waypoint currentWaypoint)
    {
        if (currentWaypoint == endWaypoint)
        { 
            isRunning = false;
        }
    }

    private void ExploreNeighbors()
    {
        if(!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = currentWaypoint.GetGridPos() + direction;
            if(grid.ContainsKey(neighborCoordinates))
            {
                EnqueueNewNeighbours(neighborCoordinates);
            }
        }
    }

    private void EnqueueNewNeighbours(Vector2Int neighborCoordinates)
    {
        Waypoint neighbour = grid[neighborCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            return;
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = currentWaypoint;
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
