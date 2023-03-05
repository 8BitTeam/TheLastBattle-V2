using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBullet : Bullet
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("creep"))
        {
            gameObject.SetActive(false);
        }
    }

    public override void DestroyIfFarAway()
    {
        if (Vector2.Distance(transform.position, gun.transform.position) >= distanceCanFly)
        {
            gameObject.SetActive(false);
        }
    }
}
