using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{

    private GameObject gun, shooter;

    private Rigidbody2D bulletBody;
    [HideInInspector]
    public int damage = 10;

    [SerializeField]
    private float distanceCanFly = 20;

    private GameObject main;

    private void Start()
    {
        main = GameObject.FindGameObjectWithTag("main");
    }

    void FixedUpdate()
    {
        DestroyIfFarAway();
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("main"))
        {
            collision.gameObject.GetComponent<MainAttackScript>().health -= damage;
            gameObject.SetActive(false);
        }
    }

    private void DestroyIfFarAway()
    {
        if ((transform.position - main.transform.position).sqrMagnitude >= distanceCanFly * distanceCanFly)
        {
            gameObject.SetActive(false);
        }
    }
}
