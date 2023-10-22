using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vectrosity;

public class GridPlotter : MonoBehaviour
{
    public Transform graphCenter; // Center of the grid
    public float graphSize = 30f; // Size of the grid
    public GameObject objectToPlot; // The GameObject to be plotted
    public InputField xInputField; // Reference to the x-coordinate Input Field
    public InputField yInputField; // Reference to the y-coordinate Input Field
    public float spacing = 3f; // Spacing between grid lines

    private VectorLine gridLine;
    private GameObject plottedObject; // Reference to the plotted object

    void Start()
    {
        // Calculate the offset to center the grid around the specified point
        Vector3 gridOffset = new Vector3(graphCenter.position.x - graphSize / 2, graphCenter.position.y - graphSize / 2, 0);

        // Calculate the step size based on the specified spacing
        float stepSize = spacing;

        // Create the grid lines centered around the graphCenter with the specified step size
        gridLine = new VectorLine("Grid", new List<Vector3>(), 2.0f, LineType.Discrete, Joins.Weld);

        for (float y = 0; y <= graphSize; y += stepSize)
        {
            gridLine.points3.Add(new Vector3(0, y, 0) + gridOffset);
            gridLine.points3.Add(new Vector3(graphSize, y, 0) + gridOffset);
        }

        for (float x = 0; x <= graphSize; x += stepSize)
        {
            gridLine.points3.Add(new Vector3(x, 0, 0) + gridOffset);
            gridLine.points3.Add(new Vector3(x, graphSize, 0) + gridOffset);
        }

        gridLine.color = Color.gray;
        gridLine.Draw3D();
    }

    void Update()
    {
        if (plottedObject == null)
        {
            if (float.TryParse(xInputField.text, out float xInput) && float.TryParse(yInputField.text, out float yInput))
            {
                float snappedX = xInput * spacing + graphCenter.position.x;
                float snappedY = yInput * spacing + graphCenter.position.y;

                // Instantiate and position the objectToPlot
                plottedObject = Instantiate(objectToPlot, new Vector3(snappedX, snappedY, 0), Quaternion.identity);
            }
        }
        else
        {
            if (float.TryParse(xInputField.text, out float xInput) && float.TryParse(yInputField.text, out float yInput))
            {
                float snappedX = xInput * spacing + graphCenter.position.x;
                float snappedY = yInput * spacing + graphCenter.position.y;

                plottedObject.transform.position = new Vector3(snappedX, snappedY, 0);
            }
        }
    }
}

