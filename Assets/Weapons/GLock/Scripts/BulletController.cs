using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private GameObject gun, shooter;

    private Rigidbody2D bulletBody;
    [SerializeField]
    public float damage = 10;

    [SerializeField]
    private float distanceCanFly = 20;

    void FixedUpdate()
    {
        DestroyIfFarAway();
    }

    public void Shoot(Vector3 force, float damage, GameObject gun, GameObject shooter)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("creep"))
        {
            gameObject.SetActive(false);
        }
    }

    private void DestroyIfFarAway()
    {
        if (Vector2.Distance(transform.position, gun.transform.position) >= distanceCanFly)
        {
            gameObject.SetActive(false);
        }
    }
}
