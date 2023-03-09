using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MainGun
{
    public int bulletAmount = 5;
    [Range(0.0f, 360.0f)]
    public float bulletAngle = 90f;
    private float startAngle, endAngle;

    public override void Shoot()
    {
        Vector2 shootDirection = GetShootDirection();
        float mainAngele = Vector2.SignedAngle(shootDirection, Vector2.up);
        startAngle = mainAngele - bulletAngle / 2;
        endAngle = mainAngele + bulletAngle / 2;

        float angleStep = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletAmount; i++)
        {
            float bulDirX = shootDirection.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = shootDirection.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector2 bulMoveVector = new Vector2(bulDirX, bulDirY);
            Vector2 force = bulMoveVector.normalized * FireForceAmplitude;

            //var instanceBullet = ObjectPooler.Instance.SpawnFromPool("basicBullet", barrel.position, Quaternion.identity);
            Bullet instanceBullet = factory.CreateBullet(barrel.position);

            instanceBullet.Shoot(
                force, "shotGunBullet", bulletDamage,
                gameObject,
                transform.parent.gameObject
            );

            angle += angleStep;
        }
    }


}
