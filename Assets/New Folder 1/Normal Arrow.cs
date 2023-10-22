using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class NormalArrow : MonoBehaviour
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


    }
}
