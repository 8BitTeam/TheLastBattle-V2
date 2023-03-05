using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinFactory : AbstractFactory
{
    public override Bullet CreateBullet()
    {
        throw new System.NotImplementedException();
    }

    public override Creep CreateCreep()
    {
        GameObject creep = ObjectPooler.Instance.SpawnFromPool("goblinCreep", transform.position, Quaternion.identity);
        return creep.GetComponent<Creep>();
    }
}
