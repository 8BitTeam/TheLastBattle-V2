using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormFireBallBullet : Bullet
{
    private GameObject main;

    private void Start()
    {
        main = GameObject.FindGameObjectWithTag("main");
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("main"))
        {
            collision.gameObject.GetComponent<MainAttackScript>().health -= damage;
            gameObject.SetActive(false);
        }
    }

    public override void DestroyIfFarAway()
    {
        if ((transform.position - main.transform.position).sqrMagnitude >= distanceCanFly * distanceCanFly)
        {
            gameObject.SetActive(false);
        }
    }
}
