using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFollow : MonoBehaviour
{
    
    public Slider Slider;
    
    public Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
            Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
       
        
    }
}
