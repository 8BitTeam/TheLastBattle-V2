using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingGun : MainGun
{
    public override void Shoot()
    {
        Vector3 force = GetShootDirection().normalized * FireForceAmplitude;
        Bullet instanceBullet = factory.CreateBullet(barrel.position);
        if(instanceBullet != null )
        instanceBullet.Shoot(
            force, "gatlingGunBullet", bulletDamage,
            gameObject,
            transform.parent.gameObject
            );
    }
}
