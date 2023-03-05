using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private GameObject chestclose,chestopen,item;
    // Start is called before the first frame update

    [SerializeField]
    private float maxDistanceWithCamera = 35;

    private AudioSource audio;
    private Camera mainCamera;

    void Start()
    {
        //chestclose = GameObject.FindGameObjectWithTag("closechest");
        chestclose = ScreenHelper.FindChildWithTag(gameObject, "closechest");
        //chestopen = GameObject.FindGameObjectWithTag("openchest");
        chestopen = ScreenHelper.FindChildWithTag(gameObject, "openchest");
        //item = GameObject.FindGameObjectWithTag("healthitem");
        item = ScreenHelper.FindChildWithTag(gameObject,"item");
        chestclose.SetActive(true);
        chestopen.SetActive(false);
        item.SetActive(false);
        audio = GetComponent<AudioSource>();
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        if ((transform.position - mainCamera.transform.position).sqrMagnitude > maxDistanceWithCamera * maxDistanceWithCamera)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(item != null)
        {
            if (collision.CompareTag("main"))
            {
                chestclose.SetActive(false);
                chestopen.SetActive(true);
                item.SetActive(true);
                audio.Play();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("main"))
        {
            chestclose.SetActive(false);
            chestopen.SetActive(true);           
        }
    }

}
