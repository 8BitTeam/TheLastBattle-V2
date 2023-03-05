using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MachineGunController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject bullet;
    private CommonGunController commonGunController;
    private GameObject barrel;

    [SerializeField]
    private float FireForceAmplitude = 30f;
    [SerializeField]
    private int bulletDamage = 1;

    void Start()
    {
        if(bullet == null)
        {
            bullet = (GameObject) Resources.Load(PrefabPath.BASIC_BULLET);
        }
        commonGunController = gameObject.GetComponent<CommonGunController>();
        barrel = ScreenHelper.FindChildWithTag(gameObject, "gunBarrel");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (commonGunController.isCanShoot)
        {
            Shoot();       
        }
    }

    private void Shoot()
    {
        //gunSound.Play();
        Vector3 force = GetShootDirection().normalized * FireForceAmplitude;
        //var instanceBullet = Instantiate(bullet, barrel.transform.position, Quaternion.LookRotation(Vector3.forward, GetShootDirection()));
        var instanceBullet = ObjectPooler.Instance.SpawnFromPool("basicBullet", barrel.transform.position, Quaternion.LookRotation(Vector3.forward, GetShootDirection()));
        instanceBullet.GetComponent<Bullet>().Shoot(
            force, bulletDamage,
            gameObject,
            gameObject.transform.parent.gameObject
            );  
    }

    private Vector3 GetShootDirection()
    {
        return barrel.transform.position - transform.position;
    }
}
