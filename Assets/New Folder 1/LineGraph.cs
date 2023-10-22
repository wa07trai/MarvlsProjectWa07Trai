using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGraph : MonoBehaviour
{

    private int xCount;

    public RectTransform rect;

    public LineRenderer instantiateLine;
    private LineRenderer lineRenderer;
    //include y lines as well
    // Start is called before the first frame update

    void Start()
    {
        xCount = 2;

        for (int i = 0; i < 10; i++)
        {

            float xPosition = rect.position.x + (i * (xCount / rect.rect.width));

            lineRenderer = Instantiate(instantiateLine);

            lineRenderer.SetPosition(0, new Vector3(xPosition, rect.position.y, rect.position.z));
            lineRenderer.SetPosition(1, new Vector3(xPosition, rect.position.y + rect.rect.height, rect.position.z));

            xCount++;
        }
    }
}