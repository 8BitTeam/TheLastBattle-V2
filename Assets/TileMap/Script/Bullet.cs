using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public abstract void DestroyIfFarAway();
    public abstract void OnTriggerEnter2D(Collider2D collision);

    public GameObject gun, shooter;
    public Rigidbody2D bulletBody;
    public int damage = 10;
    public float distanceCanFly = 20;

    public void Shoot(Vector3 force, int damage, GameObject gun, GameObject shooter)
    {
        this.shooter = shooter;
        this.gun = gun;
        this.damage = damage;

        bulletBody = GetComponent<Rigidbody2D>();
        bulletBody.velocity = force;
    }

    public GameObject GetShooter()
    {
        return shooter;
    }

    void FixedUpdate()
    {
        DestroyIfFarAway();
    }
}
