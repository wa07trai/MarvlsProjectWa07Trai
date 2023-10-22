using UnityEngine;

public class InverseRotation : MonoBehaviour
{
    public Transform parentTransform; // Assign the parent's transform in the Inspector

    void Update()
    {
        if (parentTransform == null)
        {
            return;
        }

        // Calculate the inverse rotation of the parent object
        Quaternion inverseRotation = Quaternion.Inverse(parentTransform.rotation);

        // Apply the inverse rotation to this object
        transform.rotation = inverseRotation;
    }
}
