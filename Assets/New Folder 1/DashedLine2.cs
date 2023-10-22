using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DashedLine2 : MonoBehaviour
{
    public float dashLength = 0.2f; // Length of each dash
    public float gapLength = 0.1f;  // Length of each gap
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // Set the LineRenderer to have only 2 positions initially.
        UpdateDashedLine();
    }

    private void UpdateDashedLine()
    {
        if (lineRenderer.positionCount != 2)
        {
            Debug.LogWarning("DashedLine script requires exactly two positions.");
            return;
        }

        float lineLength = Vector3.Distance(lineRenderer.GetPosition(0), lineRenderer.GetPosition(1));
        int segmentCount = Mathf.FloorToInt(lineLength / (dashLength + gapLength));
        float segmentLength = lineLength / segmentCount;

        lineRenderer.material.mainTextureScale = new Vector2(segmentCount, 1);

        Vector3[] positions = new Vector3[(segmentCount * 2) + 2];

        for (int i = 0; i < segmentCount; i++)
        {
            float t = i * (dashLength + gapLength) / lineLength;
            positions[i * 2] = Vector3.Lerp(lineRenderer.GetPosition(0), lineRenderer.GetPosition(1), t);
            positions[(i * 2) + 1] = Vector3.Lerp(lineRenderer.GetPosition(0), lineRenderer.GetPosition(1), t + (dashLength / lineLength));
        }

        lineRenderer.SetPositions(positions);
    }
}
