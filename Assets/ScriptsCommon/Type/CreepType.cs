using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepType
{
    public int Damage { get; private set; }
    public float MaxDistanceWithCamera { get; private set; }
    public float Speed { get; private set; }
    public float RadiusAreaMoving { get; private set; }
    public float StandDuration { get; private set; }
    public float MaxHealth { get; private set; }

    public CreepType (int damage, float maxDistanceWithCamera, float speed, float radiusAreaMoving, float standDuration, float maxHealth)
    {
        Damage = damage;
        MaxDistanceWithCamera = maxDistanceWithCamera;
        Speed = speed;
        RadiusAreaMoving = radiusAreaMoving;
        StandDuration = standDuration;
        MaxHealth = maxHealth;
    }
}
