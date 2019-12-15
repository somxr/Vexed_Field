using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 10;

    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;



    // Start is called before the first frame update
    void Start()
    {
            
            
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
                Mathf.RoundToInt(transform.position.x / gridSize),
                Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }

    

    public void SetTopColor(Color color)
    {
        MeshRenderer TopMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        TopMeshRenderer.material.color = color;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            else
            {
                print("Can't place tower on " + gameObject.name);
            }
        }
    }

}
