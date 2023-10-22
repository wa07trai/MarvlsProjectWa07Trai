using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Vectrosity;

public class NewGrid : MonoBehaviour
{
    public int numberOfPoints = 100;
    public float plotSize = 10f;
    public Color pointColor = Color.blue;
    public Color gridColor = Color.gray;
    public int gridLines = 10;
    public float lineWidth = 2.0f; // Adjust this value for line width
    public Transform centerObject; // Specify the center GameObject
    public Transform object1; // First rotating object.
    public Transform object2; // Second rotating object;
    public Transform rotationReference; // The object whose rotation controls the rotation of object1 and object2.
    public float radius = 5.0f; // Radius of the circle.

    private VectorLine scatterLine;
    private VectorLine gridLine;

    void Start()
    {
        if (centerObject == null || object1 == null || object2 == null || rotationReference == null)
        {
            Debug.LogError("One or more objects not assigned in the Inspector.");
            return;
        }

        // Create a new List to hold the scatter plot points
        List<Vector3> scatterPoints = new List<Vector3>();

        // Calculate the center point based on the position of the centerObject
        Vector3 centerPoint = centerObject.position;

        // Generate random data points for the scatter plot, centered around the center point
        for (int i = 0; i < numberOfPoints; i++)
        {
            float x = Random.Range(-plotSize / 2, plotSize / 2) + centerPoint.x;
            float y = Random.Range(-plotSize / 2, plotSize / 2) + centerPoint.y;
            Vector3 point = new Vector3(x, y, 0f);
            scatterPoints.Add(point);
        }

        // Create a VectorLine from the scatter points
        scatterLine = new VectorLine("ScatterPlot", scatterPoints, lineWidth, LineType.Points);

        // Set the color for the points
        scatterLine.color = pointColor;

        // Create a grid centered around the center point
        gridLine = new VectorLine("Grid", new List<Vector3>(), lineWidth, LineType.Discrete, Joins.Weld);
        float stepSize = plotSize / gridLines;

        // Horizontal grid lines
        for (float y = -plotSize / 2; y <= plotSize / 2; y += stepSize)
        {
            gridLine.points3.Add(new Vector3(centerPoint.x - plotSize / 2, centerPoint.y + y, 0));
            gridLine.points3.Add(new Vector3(centerPoint.x + plotSize / 2, centerPoint.y + y, 0));
        }

        // Vertical grid lines
        for (float x = -plotSize / 2; x <= plotSize / 2; x += stepSize)
        {
            gridLine.points3.Add(new Vector3(centerPoint.x + x, centerPoint.y - plotSize / 2, 0));
            gridLine.points3.Add(new Vector3(centerPoint.x + x, centerPoint.y + plotSize / 2, 0));
        }

        // Set the color for the grid lines
        gridLine.color = gridColor;

        // Draw the scatter plot and grid
        scatterLine.Draw3D();
        gridLine.Draw3D();
    }

    void Update()
    {
        // Get the rotation of the rotationReference object.
        float referenceRotation = rotationReference.eulerAngles.z;

        // Calculate the angle for rotation based on the referenceRotation.
        float angle = referenceRotation;

        // Calculate the new positions for object1 and object2 on the circle's circumference.
        Vector3 position1 = centerObject.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * radius, Mathf.Sin(angle * Mathf.Deg2Rad) * radius, 0f);
        Vector3 position2 = centerObject.position - new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * radius, Mathf.Sin(angle * Mathf.Deg2Rad) * radius, 0f);

        // Update the positions of object1 and object2.
        object1.position = position1;
        object2.position = position2;
    }

    void OnDestroy()
    {
        // Clean up the VectorLines when they are no longer needed
        VectorLine.Destroy(ref scatterLine);
        VectorLine.Destroy(ref gridLine);
    }
}
