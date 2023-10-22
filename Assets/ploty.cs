using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vectrosity;

public class ploty : MonoBehaviour
{
    public Transform graphCenter; // Center of the grid
    public float graphSize = 30f; // Size of the grid
    public GameObject objectToPlot; // The GameObject to be plotted
    public InputField xInputField; // Reference to the x-coordinate Input Field
    public InputField yInputField; // Reference to the y-coordinate Input Field
    public float spacing = 3f; // Spacing between grid lines

    private VectorLine gridLine;
    private GameObject plottedObject; // Reference to the plotted object


    void Update()
    {
        if (plottedObject != null)
        {
            Destroy(plottedObject);
            plottedObject = null;
        }

        if (float.TryParse(xInputField.text, out float xInput) && float.TryParse(yInputField.text, out float yInput))
        {
            float snappedX = xInput * spacing + graphCenter.position.x;
            float snappedY = -yInput * spacing + graphCenter.position.y; // Negate yInput

            // Instantiate and position the objectToPlot
            plottedObject = Instantiate(objectToPlot, new Vector3(snappedX, snappedY, 0), Quaternion.identity);
        }
    }


}