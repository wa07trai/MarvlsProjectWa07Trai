using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLLines : MonoBehaviour
{
    public Transform origin;
    public Material material;
    public Color baseColor;
    public Vector3[] points;
    public Color[] colors;
    void Start()
    {

    }
    void OnPostRender()
    {
        RenderLines(points, colors);
    }

    void OnDrawGizmos()
    {
        RenderLines(points, colors);
    }

    void RenderLines(Vector3[] points, Color[] colors)
    {

        GL.Begin(GL.LINES);//pass to our graphics library
        material.SetPass(0);//On the first pass, AKA the only pass, set the material
        for (int i=0; i<points.Length; i++)
        {
            GL.Color(baseColor);
            GL.Vertex(origin.position);
            GL.Vertex(points[i]); 
        }

        GL.End(); // Says after doing all this, actually render the line, similar to a return statement
    }
}