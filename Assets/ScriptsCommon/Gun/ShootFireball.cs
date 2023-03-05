using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireball : Gun
{
    private GameObject main;
    private void Start()
    {
        // Start timer;
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = secondPerShoot;
        timer.Run();

        factory = new WormFactory();
    }

    private void FixedUpdate()
    {
        if (main != null)
        {
            lookDirection = main.transform.position - transform.position;
            transform.right = lookDirection;
            CheckCanShoot();
        }
    }

    public override Vector3 GetShootDirection()
    {
        return main.transform.position - transform.position;
    }

    public override void CheckCanShoot()
    {
        if (timer.Finished && !transform.parent.gameObject.CompareTag("deadCreep"))
        {
            Shoot();
            timer.Run();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("main"))
        {
            main = collision.gameObject;
        }
    }

    public override void Shoot()
    {
        Vector3 force = GetShootDirection().normalized * FireForceAmplitude;
        Bullet instanceBullet = factory.CreateBullet(transform.position);
        if (instanceBullet != null)
        {
            instanceBullet.Shoot(
                force, (int)bulletDamage,
                gameObject,
                transform.parent.gameObject
                );
        }
    }
}
