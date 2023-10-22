using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererConnector : MonoBehaviour
{
    public Transform startPoint; // The starting point object.
    public Transform endPoint;   // The ending point object.
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // Ensure Line Renderer has at least 2 positions.
        lineRenderer.positionCount = 2;

        // Set the initial positions based on the start and end objects.
        UpdateLineRenderer();
    }

    void Update()
    {
        // Update the positions of the line renderer based on the objects' positions.
        UpdateLineRenderer();
    }

    void UpdateLineRenderer()
    {
        if (startPoint != null && endPoint != null)
        {
            // Update the line renderer positions to match the start and end points.
            lineRenderer.SetPosition(0, startPoint.position);
            lineRenderer.SetPosition(1, endPoint.position);
        }
    }
}

