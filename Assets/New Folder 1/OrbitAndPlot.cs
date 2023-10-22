using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using Vectrosity;

public class OrbitAndPlot : MonoBehaviour
{
    public InputField xInputField; // Input field for X coordinate
    public InputField yInputField; // Input field for Y coordinate
    public GameObject objectToMove; // The GameObject you want to move
    public Transform graphCenter; // Center of the graph
    public float graphSize = 10f; // Size of the graph
    public Transform object1; // First rotating object
    public Transform object2; // Second rotating object
    public Transform rotationReference; // The object whose rotation controls the rotation of object1 and object2
    public float radius = 5.0f; // Radius of the sphere
    public GameObject pointPrefab; // Prefab for the plotted point

    private VectorLine scatterLine;
    private List<GameObject> plottedPoints = new List<GameObject>();
    private Vector3 centerPosition; // Center position of the sphere

    void Start()
    {
        // Calculate the center position of the sphere
        centerPosition = transform.position;

        // Create the initial scatter plot
        CreateScatterPlot();
    }

    void CreateScatterPlot()
    {
        // Create a VectorLine for the scatter plot
        scatterLine = new VectorLine("ScatterPlot", new List<Vector3>(), 2.0f, LineType.Points);

        // Set the color for the points
        scatterLine.color = Color.blue;

        // Draw the scatter plot
        scatterLine.Draw3D();
    }

    void Update()
    {
        // Check for input and move the object
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            MoveObjectToPoint();
        }

        // Get the rotation of the rotationReference object
        float referenceRotation = rotationReference.eulerAngles.z;

        // Calculate the angle for rotation based on the referenceRotation
        float angle = referenceRotation;

        // Calculate the new positions for object1 and object2 on the circle's circumference
        Vector3 position1 = centerPosition + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * radius, Mathf.Sin(angle * Mathf.Deg2Rad) * radius, 0f);
        Vector3 position2 = centerPosition - new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * radius, Mathf.Sin(angle * Mathf.Deg2Rad) * radius, 0f);

        // Update the positions of object1 and object2
        object1.position = position1;
        object2.position = position2;
    }

    public void MoveObjectToPoint()
    {
        // Get the X and Y coordinates from the input fields
        if (!float.TryParse(xInputField.text, out float xCoordinate) || !float.TryParse(yInputField.text, out float yCoordinate))
        {
            Debug.LogError("Invalid input. Please enter valid numeric values.");
            return;
        }

        // Calculate the position for the object in the graph
        Vector3 graphPosition = new Vector3(xCoordinate, yCoordinate, 0f);

        // Ensure the object stays within the graph bounds
        graphPosition.x = Mathf.Clamp(graphPosition.x, -graphSize / 2, graphSize / 2);
        graphPosition.y = Mathf.Clamp(graphPosition.y, -graphSize / 2, graphSize / 2);

        // Set the position of the object to the calculated position
        objectToMove.transform.position = graphCenter.position + graphPosition;

        // Add the point to the scatter plot
        GameObject newPoint = Instantiate(pointPrefab, graphCenter);
        newPoint.transform.localPosition = graphPosition;
        plottedPoints.Add(newPoint);
    }
}
