using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFactory : AbstractFactory
{
    public override Bullet CreateBullet()
    {
        GameObject bullet = ObjectPooler.Instance.SpawnFromPool("basicBullet", transform.position, Quaternion.identity);
        return bullet.GetComponent<Bullet>();
    }

    public override Creep CreateCreep()
    {
        throw new System.NotImplementedException();
    }
}
