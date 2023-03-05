using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    [SerializeField]
    public float health = 50;
    [SerializeField]
    private int damage = 5;

    [SerializeField]
    private float speed = 2;

    private GameObject main;
    private Animator animator;

    private CreepMovingScript creepMovingScript;

    
 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //creepMovingScript = GetComponent<CreepMovingScript>();
        //if (creepMovingScript == null)
        //{
        //    creepMovingScript = gameObject.AddComponent<CreepMovingScript>();
        //}
   
        //creepMovingScript.Speed = speed;
        

    }

    // Update is called once per frame
    void Update()
    {
      
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject colliGameObj = collision.gameObject;
        CollisionWithBullet(colliGameObj);
        EnterCollisionWithExplosion(colliGameObj);
    }

    /** use for collider */
    private void CollisionWithBullet(GameObject bulletGameObject)
    {
        if (bulletGameObject.CompareTag("bullet"))
        {
            if (health > 0)
            {
                health -= bulletGameObject.GetComponent<BulletController>().damage;
            }
            if (health <= 0)
            {
                health = 0;            
            };
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        var colliGameObj = collision.gameObject;
        EnterCollisionWithMain(colliGameObj);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ExitCollisionWithMain(collision.gameObject);
    }

    /** use for collider */
    private void EnterCollisionWithMain(GameObject main)
    {
        if (main.CompareTag("main"))
        {
            this.main = main;
            if (!ScreenHelper.CompareCurrentAnimationName(animator, "Attack"))
            {
                animator.SetTrigger("attack");
            }
            creepMovingScript.canRun = false;
        }
    }

    private void EnterCollisionWithExplosion(GameObject explosion)
    {
        if (explosion.CompareTag("explosion"))
        {

            health = 0;
            if (!ScreenHelper.CompareCurrentAnimationName(animator, "Death"))
            {
                animator.SetTrigger("dead");
            }

            creepMovingScript.canRun = false;
            creepMovingScript.Die();
        };
    }


    /** use for animator */
    public void AttachMain()
    {
        if (main != null)
            main.GetComponent<MainAttackScript>().health -= damage;
    }

    /** use for collider */
    private void ExitCollisionWithMain(GameObject main)
    {
        if (main.CompareTag("main"))
        {
            this.main = null;
            creepMovingScript.canRun = true;
        }
    }

    public void EndDead()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    public void EndGetHit()
    {
        if (health > 0)
            creepMovingScript.canRun = true;
    }

    public void StartGetHit()
    {
        if (!ScreenHelper.CompareCurrentAnimationName(animator, "GetHit"))
        {
            animator.SetTrigger("getDamage");
        }

        creepMovingScript.canRun = false;
    }

    //private int damageStoring = 0;
    //private float speedStoring = 0;

    //private void OnEnable()
    //{
    //    damageStoring = damage;
    //    speedStoring = speed;
    //}

    //private void OnDisable()
    //{
        
    //    damage = damageStoring;
    //    speed = speedStoring;
    //}
}
