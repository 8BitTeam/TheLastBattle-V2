using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFactory : MonoBehaviour
{
    public abstract Bullet CreateBullet();
    public abstract Creep CreateCreep();
}
