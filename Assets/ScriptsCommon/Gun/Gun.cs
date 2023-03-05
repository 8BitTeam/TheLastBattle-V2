using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public abstract void Shoot();
    public abstract Vector3 GetShootDirection();
    public abstract void CheckCanShoot();

    public AbstractFactory factory;
    
    public float shootDistance = 5;
    public float secondPerShoot = 0.01f;
    public float FireForceAmplitude = 30f;
    public int bulletDamage = 1;

    protected Timer timer;
    protected Vector2 lookDirection;
}
