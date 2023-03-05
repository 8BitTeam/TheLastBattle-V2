using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunController : MonoBehaviour
{

    private Transform barrel;
    private GameObject bullet;
    private CommonGunController commonGunController;

    [SerializeField]
    private int bulletAmount = 5;
    [Range(0.0f, 360.0f)]
    [SerializeField]
    private float bulletAngle = 90f;

    private float startAngle, endAngle;

    [SerializeField]
    private float fireForceAmplitude = 20f;
    [SerializeField]
    private float bulletDamage = 1f;

    private AudioSource gunSound;

    // Start is called before the first frame update
    void Start()
    {
        barrel = ScreenHelper.FindChildWithTag(gameObject, "gunBarrel").transform;
        if (bullet == null)
        {
            bullet = (GameObject)Resources.Load(PrefabPath.BASIC_BULLET);
        }
        commonGunController = gameObject.GetComponent<CommonGunController>();
        if (commonGunController == null)
        {
            commonGunController = gameObject.AddComponent<CommonGunController>();
        }


        gunSound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (commonGunController.isCanShoot)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (gunSound != null)
            gunSound.Play();
        Vector2 shootDirection = GetShootDirection();
        float mainAngele = Vector2.SignedAngle(shootDirection, Vector2.up);
        startAngle = mainAngele - bulletAngle/2;
        endAngle = mainAngele + bulletAngle/2;

        float angleStep = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletAmount; i++)
        {
            float bulDirX = shootDirection.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = shootDirection.y + Mathf.Cos((angle * Mathf.PI) / 180f);


            Vector2 bulMoveVector = new Vector2(bulDirX, bulDirY);

            var instanceBullet = ObjectPooler.Instance.SpawnFromPool("basicBullet", barrel.position, Quaternion.identity);

            Vector2 force = bulMoveVector.normalized * fireForceAmplitude;
            instanceBullet.GetComponent<BulletController>().Shoot(
                force, bulletDamage,
                gameObject,
                gameObject.transform.parent.gameObject
            );

            angle += angleStep;
        }
    }

    private Vector3 GetShootDirection()
    {
        return barrel.position - transform.position;
    }
}
