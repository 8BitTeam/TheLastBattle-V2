using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormFireBallBullet : Bullet
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("main"))
        {
            collision.gameObject.GetComponent<MainAttackScript>().health -= type.Damage;
            this.PostEvent(EventID.OnMainHealthChange);
            gameObject.SetActive(false);
        }
    }
}
