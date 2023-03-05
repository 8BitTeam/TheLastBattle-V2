using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormFactory : AbstractFactory
{
    public override Bullet CreateBullet()
    {
        GameObject worm = ObjectPooler.Instance.SpawnFromPool("fireball", transform.position, Quaternion.identity);
        return worm.GetComponent<Bullet>();
    }

    public override Creep CreateCreep()
    {
        GameObject worm = ObjectPooler.Instance.SpawnFromPool("wormCreep", transform.position, Quaternion.identity);
        return worm.GetComponent<Creep>();
    }
}
