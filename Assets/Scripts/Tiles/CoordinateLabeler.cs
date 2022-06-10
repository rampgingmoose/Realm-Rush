using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.red;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f); //RGB must be between 0 and 1

    TextMeshPro label;
    Vector2Int tileCoordinates = new Vector2Int();

    GridManager gridManager;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        gridManager = FindObjectOfType<GridManager>();

        DisplayCoordinatesText();
    }
    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinatesText();
            UpdateObjectName();
        }

        ChangeTileTextColor();
        ToggleLabelText();
    }

    private void ChangeTileTextColor()
    {
        if (gridManager == null)
        {
            return;
        }

        Node node = gridManager.GetNode(tileCoordinates);

        if(node == null)
        {
            return;
        }

        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }
    }

    private void ToggleLabelText()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void DisplayCoordinatesText()
    {
        if (gridManager == null)
        {
            return;
        }

        //Using X and Y for coordinates to help visualize the grid as a 2D graph
        //the Parent position is actually on the z axis however rather than the y
        tileCoordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        tileCoordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize); 

        label.text = tileCoordinates.x + "," + tileCoordinates.y;
    }

    private void UpdateObjectName()
    {
        transform.parent.name = tileCoordinates.ToString();
    }
}
