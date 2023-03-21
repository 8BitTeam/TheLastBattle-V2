using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingGun : MainGun
{
    public override void InitSubClass()
    {
        GameConfigModel.MainGun.GatlingGun galtingGun = ScreenHelper.LoadConfig().mainGun.gatlingGun;

        type = TypeFactory.Instance.GetGunType("gatlingGun", galtingGun.shootDistance,
            galtingGun.secondPerShoot, galtingGun.fireForceAmplitude, galtingGun.bulletDamage);

    }

    public override void Shoot()
    {
        Vector3 force = GetShootDirection().normalized * type.FireForceAmplitude;
        Bullet instanceBullet = factory.CreateBullet(barrel.position);
        if(instanceBullet != null )
        instanceBullet.Shoot(
            force, "gatlingGunBullet", type.BulletDamage,
            gameObject,
            transform.parent.gameObject
            );
    }
}
