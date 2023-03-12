using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType
{
    public float Damage { get; private set; }
    public float DistanceCanFly { get; private set; }

    public BulletType (float damage, float distanceCanFly)
    {
        this.Damage = damage;
        this.DistanceCanFly = distanceCanFly;
    }
}
