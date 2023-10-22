using UnityEngine;

public class SelfLeveling : MonoBehaviour
{
    public Transform parentTransform; // Assign the parent's transform in the Inspector

    void Update()
    {
        if (parentTransform == null)
        {
            return;
        }

        // Get the rotation of the parent object
        Quaternion parentRotation = parentTransform.rotation;

        // Create a new rotation based on the parent's rotation, but with zero rotation around the z-axis
        Quaternion levelRotation = Quaternion.Euler(parentRotation.eulerAngles.x+90, parentRotation.eulerAngles.y+90, 0f);

        // Apply the levelRotation to the object
        transform.rotation = levelRotation;
    }
}
