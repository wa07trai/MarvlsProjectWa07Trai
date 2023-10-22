using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vectrosity;

public class MoveObjectWithIntegerInput1 : MonoBehaviour
{
    public InputField xInputField; // Input field for X coordinate (integer)
    public InputField yInputField; // Input field for Y coordinate (integer)
    public GameObject objectToMove; // The GameObject you want to move
    public Transform graphCenter; // Center of the graph
    public float graphSize = 10f; // Size of the graph
    public GameObject pointPrefab; // Prefab for the plotted point

    private VectorLine scatterLine;
    private VectorLine gridLine;

    void Start()
    {
        // Create a VectorLine for the grid (similar to the original NewGrid script)
        gridLine = new VectorLine("Grid", new List<Vector3>(), 2.0f, LineType.Discrete, Joins.Weld);
        float stepSize = graphSize / 10; // Adjust gridLines value accordingly

        // Create grid lines (similar to the original NewGrid script)
        for (float y = -graphSize / 2; y <= graphSize / 2; y += stepSize)
        {
            gridLine.points3.Add(new Vector3(graphCenter.position.x - graphSize / 2, graphCenter.position.y + y, 0));
            gridLine.points3.Add(new Vector3(graphCenter.position.x + graphSize / 2, graphCenter.position.y + y, 0));
        }

        for (float x = -graphSize / 2; x <= graphSize / 2; x += stepSize)
        {
            gridLine.points3.Add(new Vector3(graphCenter.position.x + x, graphCenter.position.y - graphSize / 2, 0));
            gridLine.points3.Add(new Vector3(graphCenter.position.x + x, graphCenter.position.y + graphSize / 2, 0));
        }

        // Set the color for the grid lines (similar to the original NewGrid script)
        gridLine.color = Color.gray;

        // Draw the grid (similar to the original NewGrid script)
        gridLine.Draw3D();
    }

    public void MoveObjectToPoint()
    {
        // Get the X and Y coordinates from the input fields
        if (!int.TryParse(xInputField.text, out int xCoordinate) || !int.TryParse(yInputField.text, out int yCoordinate))
        {
            Debug.LogError("Invalid input. Please enter valid integer values.");
            return;
        }

        // Calculate the position for the object in the graph
        Vector3 graphPosition = new Vector3(xCoordinate, yCoordinate, 0f);

        // Ensure the object stays within the graph bounds
        graphPosition.x = Mathf.Clamp(graphPosition.x, -graphSize / 2, graphSize / 2);
        graphPosition.y = Mathf.Clamp(graphPosition.y, -graphSize / 2, graphSize / 2);

        // Set the position of the object to the calculated position
        objectToMove.transform.position = graphCenter.position + graphPosition;

        // Plot a point (similar to the original MoveObjectWithTextBoxInput script)
        GameObject newPoint = Instantiate(pointPrefab, graphCenter);
        newPoint.transform.localPosition = graphPosition;
    }
}
