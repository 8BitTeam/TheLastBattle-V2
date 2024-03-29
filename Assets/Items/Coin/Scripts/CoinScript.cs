using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private GameObject main;
    [SerializeField]
    private float speed = 9;

    private EyeController eye;
    [SerializeField]
    private float maxDistanceWithCamera = 30;
    private Camera mainCamera;

    // Start is called before the first frame update

    void Start()
    {
        eye = transform.Find("Eye").GetComponent<EyeController>();
        eye.detectMain += SeeMain;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void FixedUpdate()
    {
        DisableIfTooFar();
        MoveToMain();

    }

    void MoveToMain()
    {
        if (main != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, main.transform.position, Time.fixedDeltaTime * speed);
            
        }
    }

    void DisableIfTooFar()
    {
        if ((transform.position - mainCamera.transform.position).sqrMagnitude > maxDistanceWithCamera * maxDistanceWithCamera)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "main")
        {
            this.PostEvent(EventID.OnCoinCollect);
            GetComponent<AudioSource>().Play();
        }
    }

    private void SeeMain(GameObject main)
    {
        this.main = main;
    }
}
