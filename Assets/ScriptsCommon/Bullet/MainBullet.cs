using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainBullet : Bullet
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Creep creep;
        if (collision.gameObject.TryGetComponent<Creep>(out creep))
        {
            gameObject.SetActive(false);
        }
    }   
}
