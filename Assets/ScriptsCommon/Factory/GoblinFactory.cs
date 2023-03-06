using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinFactory : AbstractFactory
{
    public override Bullet CreateBullet(Vector3 position)
    {
        throw new System.NotImplementedException();
    }

    public override Creep CreateCreep(Vector3 position)
    {
        GameObject creep = ObjectPooler.Instance.SpawnFromPool("goblinCreep", position, Quaternion.identity);
        if (creep != null)
        {
            return null;
        }
        return creep.GetComponent<Creep>();
    }
}
