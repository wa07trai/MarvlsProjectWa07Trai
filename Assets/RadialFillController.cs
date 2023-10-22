using UnityEngine;

public class RadialFillController : MonoBehaviour
{
    public Material material; // Reference to the material using the shader
    public Transform gameObject;
    void Update()
    {
        if (material != null)
        {
            // Access the parent object's transform
            Transform parentTransform = gameObject;

            // Calculate the rotation speed based on the parent's rotation
            // For example, you can use the parent's z-axis rotation
            float rotationSpeed = parentTransform.rotation.eulerAngles.z;

            // Set the rotation speed in the material's shader property
            material.SetFloat("_RotationSpeed", rotationSpeed);
        }
    }
}
