using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    
   

    public RectTransform rect;

    public LineRenderer instantiateLine;
    private LineRenderer lineRenderer;
    //include y lines as well
    // Start is called before the first frame update

    void Start()
    {
       
   
        for (int i = 0; i <= 15; i++)
        {

            float xPosition = rect.position.x + (i * (15f / rect.rect.width));

            lineRenderer = Instantiate(instantiateLine);

            lineRenderer.SetPosition(0, new Vector3(xPosition, rect.position.y, rect.position.z));
            lineRenderer.SetPosition(1, new Vector3(xPosition, rect.position.y+rect.rect.height, rect.position.z));
        }
    }
}

