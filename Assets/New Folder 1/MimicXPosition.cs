using UnityEngine;

public class MimicXPosition : MonoBehaviour
{
    
    public Transform object1; // Second rotating object.
    public Transform rotationReference; // The object whose rotation controls the rotation of object1 and object2.

    public float radius = 5.0f; // Radius of the sphere.

    private Vector3 centerPosition; // Center position of the sphere.

    void Start()
    {
        // Calculate the center position of the sphere.
        centerPosition = transform.position;
    }

    void Update()
    {
        // Get the rotation of the rotationReference object.
        float referenceRotation = rotationReference.eulerAngles.z;

        // Calculate the angle for rotation based on the referenceRotation and rotation speed.
        float angle = referenceRotation;

        // Calculate the new positions for object1 and object2 on the sphere's surface.
        Vector3 position1 = centerPosition + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * radius, 0f, 0f);
  

        // Update the positions of the objects.
        object1.position = position1;
       
    }
}
