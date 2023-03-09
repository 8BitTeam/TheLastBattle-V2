using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCircleBullet : MonoBehaviour
{
    public int bulletAmount = 50;
    private float startAngle = 0, endAngle = 360;

    public float fireForceAmplitude = 20f;
    public int bulletDamage = 1;

    public AudioSource gunSound;
    public bool isCanShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        gunSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCanShoot)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (gunSound != null)
            gunSound.Play();
        float angleStep = endAngle / bulletAmount;
        float angle = startAngle;
        for (int i = 0; i < bulletAmount; i++)
        {
            float bulDirX = Mathf.Sin(angle);
            float bulDirY = Mathf.Cos(angle);

            Vector2 bulMoveVector = new Vector2(bulDirX, bulDirY);

            var instanceBullet = ObjectPooler.Instance.SpawnFromPool("basicBullet", transform.position, Quaternion.identity);
            Vector2 force = bulMoveVector.normalized * fireForceAmplitude;
            instanceBullet.GetComponent<Bullet>().Shoot(
                force, "dropOBullet",bulletDamage,
                gameObject,
                gameObject.transform.parent.gameObject
            );

            angle += angleStep;
        }
    }
}
