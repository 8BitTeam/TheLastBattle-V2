using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public abstract void OnTriggerEnter2D(Collider2D collision);

    // Chỉ số giữ nguyên
    //public int damage = 10;
    //public float distanceCanFly = 20;

    public BulletType type;

    public GameObject  shooter;
    public Rigidbody2D bulletBody;
    private Transform main;

    public void Start()
    {
        main = GameObject.FindGameObjectWithTag("main").transform;
    }

    public void Shoot(Vector3 force, string bulletTypeKey, float damage, GameObject gun, GameObject shooter)
    {
        type = TypeFactory.Instance.GetBulletType(bulletTypeKey, damage, 20);
        this.shooter = shooter;
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

    private void DestroyIfFarAway()
    {
        if (Vector2.Distance(transform.position, main.position) >= type.DistanceCanFly)
        {
            gameObject.SetActive(false);
        }
    }
}
