using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeFactory : MonoBehaviour
{
    private Dictionary<string, CreepType> creepTypes;
    private Dictionary<string, BulletType> bulletTypes;
    private Dictionary<string, GunType> gunTypes;

    #region Singleton

    public static TypeFactory Instance;

    public void Awake()
    {
        Instance = this;
    }

    #endregion

    private void Start()
    {
        creepTypes = new Dictionary<string, CreepType>();
        bulletTypes = new Dictionary<string, BulletType>();
        gunTypes = new Dictionary<string, GunType>();
    }

    public CreepType GetCreepType(string typeKey, int damage, float maxDistanceWithCam,
        float speed, float radiusAreaMoving,
        float standDuration, float maxHealth, float attackRange)
    {
        if (creepTypes.ContainsKey(typeKey)) return creepTypes[typeKey];
        else
        {
            CreepType type = new CreepType(damage, maxDistanceWithCam, speed,
                radiusAreaMoving, standDuration, maxHealth, attackRange);
            creepTypes.Add(typeKey, type);
            return type;
        };
    }

    public BulletType GetBulletType(string typeKey, float damage, float distanceCanFly)
    {
        if (bulletTypes.ContainsKey(typeKey)) return bulletTypes[typeKey];
        else
        {
            BulletType type = new BulletType(damage, distanceCanFly);
            bulletTypes.Add(typeKey, type);
            return type;
        };
    }

    public GunType GetGunType(string typeKey, float shootDistance, float secondPerShoot,
        float fireForceAmplitude, int bulletDamage)
    {
        if (gunTypes.ContainsKey(typeKey)) return gunTypes[typeKey];
        else
        {
            GunType type = new GunType(shootDistance, secondPerShoot,
         fireForceAmplitude, bulletDamage);
            gunTypes.Add(typeKey, type);
            return type;
        };
    }
}
