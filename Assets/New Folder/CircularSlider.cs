using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularSlider : MonoBehaviour
{
    public Transform handle1;
    public Transform handle2;

    private Vector2 center;
    private float radius;

    private Vector3 startHandle1Pos;
    private Vector3 startHandle2Pos;

    private void Start()
    {
        center = transform.position;
        radius = Vector3.Distance(center, handle1.position);
        startHandle1Pos = handle1.position;
        startHandle2Pos = handle2.position;
    }

    private void Update()
    {
        // Calculate angles for the handles
        float angle1 = AngleBetweenVector2(center, handle1.position);
        float angle2 = AngleBetweenVector2(center, handle2.position);

        // Update the handle positions based on user input or other logic
        // You can implement your logic to move the handles radially here

        // Ensure the handles are within the radius
        handle1.position = GetPointOnCircle(center, angle1, radius);
        handle2.position = GetPointOnCircle(center, angle2, radius);

        // Handle any actions you want to perform when the handles move
        // For example, you can call custom methods here based on handle positions.
    }

    // Calculate the angle between two points around a center point
    float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 from = vec2 - vec1;
        Vector2 to = new Vector2(1, 0);
        float angle = Vector2.Angle(from, to);
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        float finalAngle = sign * angle;
        return finalAngle;
    }

    // Calculate a point on the circle
    Vector2 GetPointOnCircle(Vector2 center, float angle, float radius)
    {
        float x = center.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = center.y + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        return new Vector2(x, y);
    }
}
