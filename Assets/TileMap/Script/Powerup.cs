using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupEffects effects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("main"))
        {
            effects.Apply(collision.gameObject);
        }
    }
}
