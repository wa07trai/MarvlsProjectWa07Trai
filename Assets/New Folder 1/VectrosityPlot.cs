using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

public class VectrosityPlot : MonoBehaviour
{
    public int numberOfPoints = 100;
    public float plotSize = 10f;
    public Color pointColor = Color.blue;

    private VectorLine scatterLine;

    void Start()
    {
        // Create a new List to hold the scatter plot points
        List<Vector3> scatterPoints = new List<Vector3>();

        // Generate random data points for the scatter plot
        for (int i = 0; i < numberOfPoints; i++)
        {
            float x = Random.Range(-plotSize / 2, plotSize / 2);
            float y = Random.Range(-plotSize / 2, plotSize / 2);
            Vector3 point = new Vector3(x, y, 0f);
            scatterPoints.Add(point);
        }

        // Create a VectorLine from the scatter points
        scatterLine = new VectorLine("ScatterPlot", scatterPoints, 2.0f, LineType.Points);

        // Set the color for the points
        scatterLine.color = pointColor;

        // Draw the scatter plot
        scatterLine.Draw3D();
    }

    void OnDestroy()
    {
        // Clean up the VectorLine when it's no longer needed
        VectorLine.Destroy(ref scatterLine);
    }
}
