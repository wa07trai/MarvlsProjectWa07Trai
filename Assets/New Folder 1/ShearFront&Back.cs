using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class ShearFrontandBack : MonoBehaviour
{
    public float stemLength;
    public float stemWidth;
    public float tipLength;
    public float tipWidth;

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

    // Update is called once per frame
    void Update()
    {
        GenerateArrow();
    }


    void GenerateArrow()
    {
        verticiesList = new List<Vector3>();
        triangleList = new List<int>();

        Vector3 stemOrigin = Vector3.zero;
        float stemHalfWidth = stemWidth / 2f;

        // Vertices for the stem front face
        verticiesList.Add(stemOrigin + (stemHalfWidth * Vector3.down));
        verticiesList.Add(stemOrigin + (stemHalfWidth * Vector3.up));
        verticiesList.Add(verticiesList[0] + (stemLength * Vector3.right));
        verticiesList.Add(verticiesList[1] + (stemLength * Vector3.right));

        // Vertices for the stem back face (offset by stemWidth)
        verticiesList.Add(verticiesList[0]+ (stemWidth)* Vector3.forward);
        verticiesList.Add(verticiesList[1] + (stemWidth) * Vector3.forward);
        verticiesList.Add(verticiesList[2] + (stemWidth) * Vector3.forward);
        verticiesList.Add(verticiesList[3] + (stemWidth) * Vector3.forward);

        // Define triangles for the stem front face
        triangleList.Add(0);
        triangleList.Add(1);
        triangleList.Add(3);

        triangleList.Add(0);
        triangleList.Add(3);
        triangleList.Add(2);

        // Define triangles for the stem back face
        triangleList.Add(7);
        triangleList.Add(5);
        triangleList.Add(4);

        triangleList.Add(6);
        triangleList.Add(7);
        triangleList.Add(4);

        // Calculate the tipOrigin for the arrowhead
        Vector3 tipOrigin = verticiesList[4];
        float tipHalfWidth = tipWidth / 2;

        // Vertices for the arrowhead front face
        verticiesList.Add(tipOrigin + (tipHalfWidth * Vector3.up) + (stemLength * Vector3.right) + (stemHalfWidth * Vector3.up));
        verticiesList.Add(tipOrigin + (tipHalfWidth * Vector3.down) + (stemLength * Vector3.right) + (stemHalfWidth * Vector3.up));
        verticiesList.Add(tipOrigin + (tipLength * Vector3.right) + (stemLength * Vector3.right) + (stemHalfWidth * Vector3.up));

        // Vertices for the arrowhead back face (offset by tipWidth)
        verticiesList.Add(verticiesList[8]);//- (tipWidth * Vector3.forward));
        verticiesList.Add(verticiesList[9]);//- (tipWidth *Vector3.forward));
        verticiesList.Add(verticiesList[10]);// - (tipWidth *Vector3.forward));

        // Define triangles for the arrowhead front face
        triangleList.Add(9);
        triangleList.Add(8);
        triangleList.Add(10);

        // Define triangles for the arrowhead back face
        triangleList.Add(11);//this is the issue face
        triangleList.Add(12);
        triangleList.Add(13);

        mesh.vertices = verticiesList.ToArray();
        mesh.triangles = triangleList.ToArray();
    }
}
