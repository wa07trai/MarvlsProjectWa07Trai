using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slidervalues : MonoBehaviour
{
    public Slider slider;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float UnnormalizedSlider = (slider.value) * (360);

        Quaternion rotation = Quaternion.Euler(0, 0, UnnormalizedSlider);

        cube.transform.rotation = rotation;
    }
}
