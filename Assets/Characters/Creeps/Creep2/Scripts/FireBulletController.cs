using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class FireBulletController : MonoBehaviour
{
    private GameObject main;
    [SerializeField]
    private float shootDistance = 5;
    [SerializeField]
    private float secondPerShoot = 0.01f;
    private Timer timer;
    [SerializeField]
    private float FireForceAmplitude = 30f;
    [SerializeField]
    private float bulletDamage = 1;

    private Vector2 lookDirection;

    // Start is called before the first frame update
    void Start()
    {

        // Start timer;
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = secondPerShoot;
        timer.Run();
    }

    private void FixedUpdate()
    {
        if (main != null)
        {
            lookDirection = main.transform.position - transform.position;
            transform.right = lookDirection;
            CheckCanShoot();
        }
    }

    public Vector3 GetShootDirection()
    {
        return main.transform.position - transform.position;
    }

    public bool isCanShoot = false;
    private void CheckCanShoot()
    {
        if (timer.Finished && !transform.parent.gameObject.CompareTag("deadCreep"))
        {
            Shoot();
            timer.Run();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("main"))
        {
            main = collision.gameObject;
        }
    }

    private void Shoot()
    {
        Vector3 force = GetShootDirection().normalized * FireForceAmplitude;
        var instanceBullet = ObjectPooler.Instance.SpawnFromPool("fireball", transform.position, Quaternion.identity);
        if(instanceBullet != null) {
        instanceBullet.GetComponent<Bullet>().Shoot(
            force, (int) bulletDamage,
            gameObject,
            gameObject.transform.parent.gameObject
            );
        }
    }
}
