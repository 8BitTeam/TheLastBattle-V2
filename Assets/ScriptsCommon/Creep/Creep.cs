using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creep : MonoBehaviour
{
    public abstract void AttachMain();
    protected abstract void InitSubClass();

    // Chỉ số giữ nguyên 


    // Thay thế chỉ số giữ nguyên bằng FlyWeight.
    public CreepType type;

    public float health;
    public GameObject main;
    public float stepPerFrame = 0;

    /**Animator để điều khiển animation tương ứng cho creep*/
    public Animator animator;
    public bool isFacingRight = true;

    public Transform attackPoint;
    public LayerMask mainLayers;
    /**Eye hoạt động như một radar, dùng để xác định nvat main khi đi vào trong vùng nhìn thấy của Eye*/
    public GameObject Eye;
    /** Born position để xác định tâm của vùng mà quái sẽ di chuyển linh tinh trong đó khi vừa sinh ra */
    public Vector3 bornPosition;
    public Timer timer;
    public Camera mainCamera;

    public HealthBar controlHealth;
    public AudioSource audioDeath;
    public GameObject healthBar;

    public Vector3? destinationForRandomMove = null;
    //public bool isTimerRun = false;

    // Biến tạm, dùng để sử dụng tốc độ cho hàm di chuyển,
    // bởi vì có những thời điểm tốc độ di chuyển về 0
    public float speedAction;

    //State
    BaseState currentState;
    public BaseState idleState = new IdleState();
    public BaseState runToMainState = new WalkingState();
    public BaseState randomWalkingState = new RandomWalkingState();
    public BaseState attackState = new AttackState();
    //public BaseState getHitState = new GetHitState();
    public BaseState deadState = new DeadState();

    void Start()
    {
        // Thực hiện các phương thức khởi tạo ở các lớp con kế thừa
        InitSubClass();

        animator = gameObject.GetComponent<Animator>();
        mainCamera = Camera.main;
        healthBar = transform.Find("ControlHealthCreep").gameObject;
        controlHealth = healthBar.GetComponent<HealthBar>();

        audioDeath = GetComponent<AudioSource>();
        // Put the eye to the body
        Eye = transform.Find("Eye").gameObject;
        // Gắn Hàm seeMain vào detectMain
        Eye.GetComponent<EyeController>().detectMain += SeeMain;

        // Set born position
        bornPosition = transform.position;

        timer = gameObject.AddComponent<Timer>();
        timer.Duration = type.StandDuration;

        controlHealth.SetMaxHealth(type.MaxHealth);
        health = type.MaxHealth;
        attackPoint = transform.Find("AttackPoint");

        // Đặt trạng thái là idle
        SwitchState(idleState);
    }

    private void FixedUpdate()
    {
        if (health <= 0 && currentState != deadState)
        {
            SwitchState(deadState);
            Die();
        }

        currentState.UpdateState(this);
        if (Vector2.Distance(transform.position, mainCamera.transform.position) > type.MaxDistanceWithCamera)
        {
            gameObject.SetActive(false);
        }
    }

    /** Chuyển đổi giữa các state */
    public void SwitchState(BaseState baseState)
    {
        currentState = baseState;
        baseState.EnterState(this);
    }

    // Thực hiện hành động khi chết
    public void Die()
    {
        currentState.ExitState(this);
    }

    private string tagStoring = "";

    private void OnEnable()
    {
        tagStoring = gameObject.tag;
        if(type != null)
        {
            health = type.MaxHealth;
        }
    }

    private void OnDisable()
    {
        gameObject.tag = tagStoring;
        SetCollider(true);
    }

    public void SetCollider(bool isEnable)
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

   

    #region Colider Trigger

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject colliGameObj = collision.gameObject;
        CollisionWithBullet(colliGameObj);
        EnterCollisionWithExplosion(colliGameObj);
        EnterCollisionWithMain(colliGameObj);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ExitCollisionWithMain(collision.gameObject);
    }

    /** use for collider */
    private void CollisionWithBullet(GameObject bulletGameObject)
    {
        if (bulletGameObject.CompareTag("bullet"))
        {
            //shooterFromBullet = bulletGameObject.GetComponent<Bullet>().GetShooter();
            if (health > 0)
            {
                health -= bulletGameObject.GetComponent<Bullet>().type.Damage;
            }
            if (health <= 0)
            {
                health = 0;
            };
            controlHealth.SetHeatlh(health);
        }
    }

    private void EnterCollisionWithExplosion(GameObject explosion)
    {
        if (explosion.CompareTag("explosion"))
        {
            health = 0;
            controlHealth.SetHeatlh(health);
        };
    }

    private void EnterCollisionWithMain(GameObject main)
    {
        if (main.CompareTag("main"))
        {
            SwitchState(attackState);
        }
    }

    private void ExitCollisionWithMain(GameObject main)
    {
        if (main.CompareTag("main"))
        {           
            SwitchState(runToMainState);
        }
    }

    #endregion

    /** 
     * Hàm này dùng cho Delegate trong Eye, và được Invoke trong OnTrigger ở Eye
     */
    private void SeeMain(GameObject main)
    {
        this.main = main;
        SwitchState(runToMainState);
    }

    /** Kết thúc animation Dead thì hàm này kích hoạt và spawn ra item đồng thời tăng mana cho Main, cũng như biến mất */
    public void EndDead()
    {
        gameObject.SetActive(false);

        GameObject.FindGameObjectWithTag("main").GetComponent<MainAttackScript>().GainMana(type.Damage);
        //Change Mana by send EventID
        this.PostEvent(EventID.OnManaChange);
        RandomSpawnItems.SpawnItem(transform.position, Quaternion.identity);
    }

    // Cuối animation bị đạn bắn thì hàm này được kích hoạt
    public void EndGetHit()
    {
        SwitchState(runToMainState);
    }

    // Khi mới bắt đầu bị đạn bắn vào thì con quái bị Stun
    public void StartGetHit()
    {
        if (!ScreenHelper.CompareCurrentAnimationName(animator, "GetHit"))
        {
            animator.SetTrigger("getDamage");
        }
    }



    /** Sử dụng để tạo hiệu ứng hiển thị vột vòng tròn damage tác động lên main */
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, type.AttackRange);
    }
}
