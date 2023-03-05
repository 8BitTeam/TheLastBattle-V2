using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 4f;
    public bool Thrown;
    public Vector3 LaunchOffSet;
    void Start()
    {
        if (Thrown)
        {
            var direction = transform.right + Vector3.up;
            GetComponent<Rigidbody>().AddForce(direction * Speed,ForceMode.Impulse);
        }
        transform.Translate(LaunchOffSet);
        Destroy(gameObject, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Thrown)
        {
            transform.position += -transform.right * Speed * Time.deltaTime;
        }
        
    }
}
