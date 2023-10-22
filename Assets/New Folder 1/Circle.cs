using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Circle : MonoBehaviour //class is a blueprint for what an object is/what it's inherent attributes are & what it does
{
    public int vertexCount = 40;// public varible, accessible to other scripts & visible in inspector
    private LineRenderer lineRenderer; //private varible, only accessible within the script
    public float lineWidth = .2f; //lineWidth is the identifier or varible name
    public float radius; 
    public GameObject parentLocation; //GameObject is a Unity type

    private void Start() //Plays before the first frame
    {
        lineRenderer = GetComponent<LineRenderer>();      
    }
    void Update()//Plays anything within curly brackets once per frame
    {
        SetupCircle();
    }
    private void SetupCircle() //void states this code should perform an action, and not return a value
    {
        lineRenderer.widthMultiplier = lineWidth; 
        float deltaTheta = (2f * Mathf.PI) / vertexCount; 
        float theta=0f;

        lineRenderer.positionCount = vertexCount;
        for (int i = 0; i < lineRenderer.positionCount; i++) 
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f)

                + new Vector3(parentLocation.transform.position.x, parentLocation.transform.position.y, 0f);

            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
        
    }

}
