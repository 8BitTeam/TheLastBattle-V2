using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creep : MonoBehaviour
{
    public float health = 20;
    public int damage = 5;

    public float maxDistanceWithCamera = 25;
    public GameObject main;
    public float stepPerFrame = 0;
    public bool canRun = true;
    /**Animator để điều khiển animation tương ứng cho creep*/
    public Animator animator;
    /// <summary>
    /// Speed là tốc độ chạy của creep, phải set speed khi muốn creep di chuyển
    /// </summary>
   
    public float Speed;
    public bool isFacingRight = true;

    /**Eye hoạt động như một radar, dùng để xác định nvat main khi đi vào trong vùng nhìn thấy của Eye*/
    public GameObject Eye;
    /** Born position để xác định tâm của vùng mà quái sẽ di chuyển linh tinh trong đó khi vừa sinh ra */
    public Vector3 bornPosition;
    public Timer timer;

    public Camera mainCamera;

    public HealthBar controlHealth;
    public AudioSource audioDeath;
    public GameObject healthBar;

    public float radiusAreaMoving = 3;
    public Vector3? destinationForRandomMove = null;
    public float standDuration = 1;
    public bool isTimerRun = false;
    public float speedAction;

    private void FixedUpdate()
    {
        controlHealth.SetHeatlh((int)health);
        if (main == null)
        {
            RandomMovingAroundBornPos();
            Vector2 facingDirection = (Vector3)destinationForRandomMove - transform.position;
            ScreenHelper.Facing(facingDirection, isFacingRight, gameObject);
            // Lật ngược thêm 1 lần nữa để thanh health luôn quay về 1 phía
            ScreenHelper.Facing(facingDirection, isFacingRight, healthBar);

            main = Eye.GetComponent<EyeController>().SeeMain();
        }
        if (main != null && canRun)
        {
            RunToMain(Speed);
            if (!ScreenHelper.CompareCurrentAnimationName(animator, "Walking"))
            {
                animator.SetTrigger("walk");
            }
            Vector2 facingDirection = main.transform.position - transform.position;
            ScreenHelper.Facing(facingDirection, isFacingRight, gameObject);
        }

        if ((transform.position - mainCamera.transform.position).sqrMagnitude > maxDistanceWithCamera * maxDistanceWithCamera)
        {
            gameObject.SetActive(false);
        }

        if (health <= 0)
        {
            if (!ScreenHelper.CompareCurrentAnimationName(animator, "Death"))
            {
                animator.SetTrigger("dead");
                audioDeath.Play();
            }
            Die();
        }
    }


    // Thực hiện việc chạy lại gần Main (DK: Không chết)
    private void RunToMain(float speed)
    {
        stepPerFrame = Time.fixedDeltaTime * speed;
        gameObject.transform.position = Vector2.MoveTowards(transform.position, main.transform.position, stepPerFrame);
    }

    // Thực hiện việc di chuyển xung quanh 1 điểm random bất kì trong bán kính cho trước khi vừa sinh ra (DK: không chết và main == null)
    private void RandomMovingAroundBornPos()
    {
        if (transform.position == destinationForRandomMove && !isTimerRun)
        {
            timer.Run();
            isTimerRun = true;
            speedAction = 0;
            if (!ScreenHelper.CompareCurrentAnimationName(animator, "Idle"))
            {
                animator.SetTrigger("idle");
            }

        }
        if (destinationForRandomMove == null || (timer.Finished && isTimerRun))
        {
            speedAction = Speed;
            if (!ScreenHelper.CompareCurrentAnimationName(animator, "Walking"))
            {
                animator.SetTrigger("walk");
            }
            destinationForRandomMove = new Vector2(
                Random.Range(bornPosition.x - radiusAreaMoving, bornPosition.x + radiusAreaMoving),
                Random.Range(bornPosition.y - radiusAreaMoving, bornPosition.y + radiusAreaMoving)
            );
            isTimerRun = false;
        }
        if (speedAction > 0)
        {
            stepPerFrame = Time.fixedDeltaTime * speedAction;
            gameObject.transform.position = Vector2.MoveTowards(transform.position, (Vector2)destinationForRandomMove, stepPerFrame);
        }
    }

    private GameObject shooterFromBullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {

        }
        GameObject colliGameObj = collision.gameObject;
        CollisionWithBullet(colliGameObj);
        EnterCollisionWithExplosion(colliGameObj);
    }

    public bool isAlive()
    {
        return canRun == true;
    }

    // Thực hiện hành động khi chết
    public void Die()
    {
        gameObject.tag = "deadCreep";
        SetCollider(false);

        // Trạng thái của biến canRun == false để không di chuyển nữa, việc kiểm tra biến này nằm trong hàm Update
        canRun = false;
    }

    private float stepPerFrameStoring = 0;
    private bool canRunStoring = true;
    private string tagStoring = "";
    private float healthStoring = 0;

    private void OnEnable()
    {
        healthStoring = health;
        stepPerFrameStoring = stepPerFrame;
        canRunStoring = canRun;
        tagStoring = gameObject.tag;
        damageStoring = damage;
        speedStoring = Speed;
    }

    private void OnDisable()
    {
        health = healthStoring;
        stepPerFrame = stepPerFrameStoring;
        canRun = canRunStoring;
        gameObject.tag = tagStoring;
        damage = damageStoring;
        Speed = speedStoring;
        SetCollider(true);
    }

    private int damageStoring = 0;
    private float speedStoring = 0;

    private void SetCollider(bool isEnable)
    {
        var capsuleColli = GetComponent<CapsuleCollider2D>();
        var polyColli = GetComponent<PolygonCollider2D>();
        var boxColli = GetComponent<BoxCollider2D>();
        if (capsuleColli != null)
        {
            capsuleColli.enabled = isEnable;
        }
        if (polyColli != null)
        {
            polyColli.enabled = isEnable;
        }
        if (boxColli != null)
        {
            boxColli.enabled = isEnable;
        }
    }

    /** use for collider */
    private void CollisionWithBullet(GameObject bulletGameObject)
    {
        if (bulletGameObject.CompareTag("bullet"))
        {
            shooterFromBullet = bulletGameObject.GetComponent<Bullet>().GetShooter();
            if (health > 0)
            {
                health -= bulletGameObject.GetComponent<Bullet>().damage;
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
            canRun = false;
        }
    }

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask mainLayers;
    public abstract void AttachMain();

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    private void EnterCollisionWithExplosion(GameObject explosion)
    {
        if (explosion.CompareTag("explosion"))
        {
            health = 0;
            //if (!ScreenHelper.CompareCurrentAnimationName(animator, "Death"))
            //{
            //    animator.SetTrigger("dead");
            //}
            //canRun = false;
            //Die();
        };
    }

    private void ExitCollisionWithMain(GameObject main)
    {
        if (main.CompareTag("main"))
        {
            this.main = null;
            canRun = true;
        }
    }


    // Kết thúc animation Dead thì hàm này kích hoạt và spawn ra item đồng thời tăng mana cho Main, cũng như biến mất
    public void EndDead()
    {
        gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("main").GetComponent<MainAttackScript>().GainMana(10);
        RandomSpawnItems.SpawnItem(transform.position, Quaternion.identity);
    }

    // Cuối animation bị đạn bắn thì hàm này được kích hoạt và biến canRUn được set thành true để quái tiếp tục di chuyển
    public void EndGetHit()
    {
        if (health > 0)
            canRun = true;
    }


    // Khi mới bắt đầu bị đạn bắn vào thì con quái bị Stun nên biến canRun cũng được set thành false
    public void StartGetHit()
    {
        if (!ScreenHelper.CompareCurrentAnimationName(animator, "GetHit"))
        {
            animator.SetTrigger("getDamage");
        }
        canRun = false;
    }
}
