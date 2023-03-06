using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFactory : AbstractFactory
{
    public override Bullet CreateBullet(Vector3 position)
    {
        GameObject bullet = ObjectPooler.Instance.SpawnFromPool("basicBullet", position, Quaternion.identity);
        if (bullet == null) return null;
        return bullet.GetComponent<Bullet>();
    }

    public override Creep CreateCreep(Vector3 position)
    {
        throw new System.NotImplementedException();
    }
}
