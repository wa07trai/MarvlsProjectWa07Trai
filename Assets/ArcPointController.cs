using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArcPointController : MonoBehaviour
{
    public Material material; // Reference to the material using the shader

    public Transform object1; // Assign the GameObject for Arc Point 1
    public Transform object2; // Assign the GameObject for Arc Point 2

    void Update()
    {
        // Ensure the material and objects are assigned
        if (material != null && object1 != null && object2 != null)
        {
            // Calculate positions and angles for the shader properties
            Vector3 obj1Pos = object1.position;
            Vector3 obj2Pos = object2.position;
            float angle = Vector3.SignedAngle(Vector3.right, obj2Pos - obj1Pos, Vector3.forward);

            // Set the material properties for Arc Point 1 and Arc Point 2
            material.SetVector("_ArcPoint1", new Vector4(obj1Pos.x, obj1Pos.y, 0, angle));
            material.SetVector("_ArcPoint2", new Vector4(obj2Pos.x, obj2Pos.y, 0, angle));
        }
    }
}
