﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;
    TextMesh textMesh;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
        textMesh = GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        string textLabel = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        textMesh.text = textLabel;
        gameObject.name = textLabel;
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x *gridSize, 0f, waypoint.GetGridPos().y * gridSize);
    }
}