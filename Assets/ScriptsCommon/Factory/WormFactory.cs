using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormFactory : AbstractFactory
{
    public override Bullet CreateBullet(Vector3 position)
    {
        GameObject worm = ObjectPooler.Instance.SpawnFromPool("fireball", position, Quaternion.identity);
        if(worm == null)
        {
            return null;
        }
        return worm.GetComponent<Bullet>();
    }

    public override Creep CreateCreep(Vector3 position)
    {
        GameObject worm = ObjectPooler.Instance.SpawnFromPool("wormCreep", position, Quaternion.identity);
        if(worm == null)
        {
            return null;
        }
        return worm.GetComponent<Creep>();
    }
}
