using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private Camera mainCamera;
    private float maxDistanceWithCamera = 30;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((transform.position - mainCamera.transform.position).sqrMagnitude > maxDistanceWithCamera * maxDistanceWithCamera)
        {
            gameObject.SetActive(false);
        }
    }  
}
