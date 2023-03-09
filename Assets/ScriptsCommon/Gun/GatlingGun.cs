using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingGun : MainGun
{
    public override void Shoot()
    {
        Vector3 force = GetShootDirection().normalized * FireForceAmplitude;
        //var instanceBullet = Instantiate(bullet, barrel.transform.position, Quaternion.LookRotation(Vector3.forward, GetShootDirection()));
        Bullet instanceBullet = factory.CreateBullet(barrel.position);
        //ObjectPooler.Instance.SpawnFromPool("basicBullet", barrel.transform.position, Quaternion.LookRotation(Vector3.forward, GetShootDirection()));
        instanceBullet.Shoot(
            force, "gatlingGunBullet", bulletDamage,
            gameObject,
            transform.parent.gameObject
            );
    }
}
