using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConfigModel.MainGun;

public class ShootFireball : Gun
{
    private GameObject main;
    private void Start()
    {
        GameConfigModel.ShootFireballGun shootFireballConfig = ScreenHelper.LoadConfig().shootFireballGun;
        type = TypeFactory.Instance.GetGunType("shootFireball", shootFireballConfig.shootDistance,
        shootFireballConfig.secondPerShoot, shootFireballConfig.fireForceAmplitude, shootFireballConfig.bulletDamage);

        // Start timer;
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = type.SecondPerShoot;
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
        if (timer.Finished && 
            !transform.parent.gameObject.GetComponent<Creep>().currentState.GetType().Equals(typeof(DeadState)))
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
        Vector3 force = GetShootDirection().normalized * type.FireForceAmplitude;
        Bullet instanceBullet = factory.CreateBullet(transform.position);
        if (instanceBullet != null)
        {
            instanceBullet.Shoot(
                force, "fireBallBullet", type.BulletDamage,
                gameObject,
                transform.parent.gameObject
                );
        }
    }
}
