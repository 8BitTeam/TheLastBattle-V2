using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject main = GameObject.FindGameObjectWithTag("main");
        GameObject gameObject = GameObject.Find("CM vcam1");
        if(main != null)
        {
            gameObject.GetComponent<CinemachineVirtualCamera>().Follow=main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
