/*using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class One : MonoBehaviour
{
    public float stemWidth;
    public float tipLength;
    public float tipWidth;

    public float StartValue;
    public float MaxValue;
    public float MinValue;

    public Transform rotationControlObject; // Reference to the object controlling rotation.
    public float rotationMultiplier = 1.0f; // Adjust this to control the rotation's effect on stem length.

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
            // Get the rotation of the control object and use it to adjust the stem length.
            float rotationValue = Mathf.InverseLerp(0f, 360f, rotationControlObject.eulerAngles.z);
            float newStemLength = Mathf.Lerp(MinValue, MaxValue, rotationValue * rotationMultiplier);
            stemLength = newStemLength;
        }

        GenerateArrow();
    }
    void GenerateArrow() 
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
*/