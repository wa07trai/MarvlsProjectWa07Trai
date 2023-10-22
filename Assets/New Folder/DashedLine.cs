using UnityEngine;

public class DashedLine : MonoBehaviour
{
    public float dashLength = 0.2f; // Length of each dash
    public float gapLength = 0.1f;  // Length of each gap
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material.mainTextureScale = new Vector2(1, 1);
        UpdateDashedLine();
    }

    private void UpdateDashedLine()
    {
        float totalLength = dashLength + gapLength;
        int segmentCount = Mathf.FloorToInt(lineRenderer.positionCount / 2);
        float textureScale = totalLength / dashLength;

        lineRenderer.material.mainTextureScale = new Vector2(textureScale, 1);

        for (int i = 0; i < segmentCount; i++)
        {
            lineRenderer.SetPosition(i * 2 + 1, Vector3.zero);
            lineRenderer.SetPosition(i * 2 + 2, Vector3.right * totalLength);
        }
    }
}
