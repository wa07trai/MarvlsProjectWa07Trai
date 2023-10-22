using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPTGraph : MonoBehaviour
{
        public RectTransform rect;
        public int xCount;

        void Start()
        {
            rect = GetComponent<RectTransform>();
            LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.widthMultiplier = 0.2f;

            Vector3[] positions = new Vector3[xCount + 1];

            for (int i = 0; i <= xCount; i++)
            {
                float xPosition = rect.position.x + (i * (rect.rect.width / xCount));
                positions[i] = new Vector3(xPosition, rect.position.y, rect.position.z);
            }

            lineRenderer.positionCount = xCount + 1;
            lineRenderer.SetPositions(positions);
        }
    

}
