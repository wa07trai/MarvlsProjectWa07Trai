using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class CSharpShear : MonoBehaviour
{
    public float stemWidth;
    public float tipLength;
    public float tipWidth;
    public float MaxValue;
    public float MinValue;
    public Transform rotationControlObject; // Reference to the object controlling rotation.

    public float stemLengthAt0Degrees; // Stem length at 0 degrees.
    public float stemLengthAt45Degrees; // Stem length at 45 degrees.
    public float stemLengthAt90Degrees; // Stem length at 90 degrees.
    public float stemLengthAt180Degrees; // Stem length at 180 degrees.

    [System.NonSerialized]
    public List<Vector3> verticiesList;
    [System.NonSerialized]
    public List<int> triangleList;

    Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        this.GetComponent<MeshFilter>().mesh = mesh;
    }

    void Update()
    {
        if (rotationControlObject != null)
        {
            float currentRotation = rotationControlObject.eulerAngles.z;

            // Calculate stem length based on current rotation.
            float stemLength = CalculateStemLength(currentRotation);

            // Generate the arrow.
            GenerateArrow(stemLength);
        }
    }

    float CalculateStemLength(float currentRotation)
    {
        if (currentRotation >= 0 && currentRotation < 45)
        {
            // Interpolate between stemLengthAt0Degrees and stemLengthAt45Degrees.
            return Mathf.Lerp(stemLengthAt0Degrees, stemLengthAt45Degrees, currentRotation / 45f);
        }
        else if (currentRotation >= 45 && currentRotation < 90)
        {
            // Interpolate between stemLengthAt45Degrees and stemLengthAt90Degrees.
            return Mathf.Lerp(stemLengthAt45Degrees, stemLengthAt90Degrees, (currentRotation - 45f) / 45f);
        }
        else if (currentRotation >= 90 && currentRotation <= 180)
        {
            // Interpolate between stemLengthAt90Degrees and stemLengthAt180Degrees.
            return Mathf.Lerp(stemLengthAt90Degrees, stemLengthAt180Degrees, (currentRotation - 90f) / 90f);
        }

        return 0; // Handle other cases as needed.
    }

    void GenerateArrow(float stemLength)
    {
        verticiesList = new List<Vector3>();
        triangleList = new List<int>();

        Vector3 stemOrigin = Vector3.zero;
        float stemHalfWidth = stemWidth / 2f;

        verticiesList.Add(stemOrigin + (stemHalfWidth * Vector3.down));
        verticiesList.Add(stemOrigin + (stemHalfWidth * Vector3.up));
        verticiesList.Add(verticiesList[0] + (stemLength * Vector3.right));
        verticiesList.Add(verticiesList[1] + (stemLength * Vector3.right));

        triangleList.Add(0);
        triangleList.Add(1);
        triangleList.Add(3);

        triangleList.Add(0);
        triangleList.Add(3);
        triangleList.Add(2);

        Vector3 tipOrigin = stemLength * Vector3.right;
        float tipHalfWidth = tipWidth / 2;

        verticiesList.Add(tipOrigin + (tipHalfWidth * Vector3.up));
        verticiesList.Add(tipOrigin + (tipHalfWidth * Vector3.down));
        verticiesList.Add(tipOrigin + (tipLength * Vector3.right));

        triangleList.Add(4);
        triangleList.Add(6);
        triangleList.Add(5);

        mesh.vertices = verticiesList.ToArray();
        mesh.triangles = triangleList.ToArray();
    }
}
