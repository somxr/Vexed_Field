using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{

    [Range(1f,20f)] [SerializeField] float gridSize =10f;
    TextMesh textMesh;

    void Update()
    {
        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = 0f;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = snapPos;

        textMesh = GetComponentInChildren<TextMesh>();

        string textLabel = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        textMesh.text = textLabel;
        gameObject.name = textLabel;
    }
}