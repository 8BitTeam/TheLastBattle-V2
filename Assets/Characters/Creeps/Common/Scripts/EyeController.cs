using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    private GameObject main;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("main"))
        {
            main = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("main"))
        {
            main = null;
        }
    }

    public GameObject SeeMain()
    {
        if (main == null)
        {
            return null;
        }
        return main;
    }
}
