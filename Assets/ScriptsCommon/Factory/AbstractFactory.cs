using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFactory
{
    public abstract Bullet CreateBullet(Vector3 position);
    public abstract Creep CreateCreep(Vector3 position);
}
