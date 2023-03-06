using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class MainMovingScript : MonoBehaviour
{
    [SerializeField]
    public float speed = 5;
    private float oldSpeed;

    private float speedMultiplier = 1;
    private float stepPerFrame = 0;
    private Joystick joyStick;

    // Control Character
    private Vector3 movingDirection;
    private Animator animator;
    private Rigidbody2D body;
    private SpriteRenderer spriteRender;
    private GameObject machineGun, shotGun, rain;

    private bool isFacingRight = false;
    private MainAttackScript attackScript;
    [HideInInspector]
    public Timer timer;

    public bool enableMovement = true;

    private Transform boundTopLeft, boundBotRight;


    private void Awake()
    {
        timer = gameObject.AddComponent<Timer>();
        boundTopLeft = GameObject.Find("BoundTopLeft").transform;
        boundBotRight = GameObject.Find("BoundBotRight").transform;
        joyStick = GameObject.FindGameObjectWithTag("joystick").GetComponent<FloatingJoystick>();
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        rain = transform.Find("Rain").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        timer.Duration = 1f;      
        machineGun = transform.Find("MachineGun").gameObject;
        shotGun = transform.Find("ShotGun").gameObject;

        attackScript = GetComponent<MainAttackScript>();
        if (attackScript == null)
        {
            attackScript = gameObject.AddComponent<MainAttackScript>();
        }

        if (gameObject.GetComponent<MainSkillsScript>() == null)
        {
            gameObject.AddComponent<MainSkillsScript>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Bound();
        if (enableMovement)
            MovingWithJoystick();
        if (timer.Finished)
        {
            speed = 5;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

    }

    private void MovingWithJoystick()
    {
        float jHorizon = JoyStickNormalized().y;
        float jVertical = JoyStickNormalized().x;

        movingDirection = new Vector3(jHorizon, jVertical, 0);
        Moving(movingDirection);

        if (jHorizon != 0 || jVertical != 0)
        {
            StartWalking();
            ScreenHelper.Facing(movingDirection, isFacingRight, gameObject);
            ScreenHelper.Facing(movingDirection, isFacingRight, machineGun);
            ScreenHelper.Facing(movingDirection, isFacingRight, shotGun);
            ScreenHelper.Facing(movingDirection, isFacingRight, rain);
        }
        else
        {
            EndWalking();
        }
    }

    public void StartWalking()
    {
        animator.ResetTrigger("isIdling");
        animator.SetTrigger("isWalking");
    }

    public void EndWalking()
    {
        animator.ResetTrigger("isWalking");
        animator.SetTrigger("isIdling");
    }

    private void Moving(Vector3 direction)
    {
        stepPerFrame = Time.fixedDeltaTime * speed * speedMultiplier;
        transform.position += direction * stepPerFrame;
        //body.MovePosition(direction * stepPerFrame);
    }

    private Vector2 JoyStickNormalized()
    {
        Vector3 input = new Vector3(joyStick.Vertical, joyStick.Horizontal);
        return input.normalized;
    }

    private bool MinimizePosition(Vector2 position)
    {
        return position.x > 250 && position.x < 500 && position.y > -650 && position.y < -350;
    }

    private void Bound()
    {
        if(transform.position.x < boundTopLeft.position.x)
        {
            transform.position = new Vector2(boundTopLeft.position.x, transform.position.y);
        }
        if (transform.position.x > boundBotRight.position.x)
        {
            transform.position = new Vector2(boundBotRight.position.x, transform.position.y);
        }
        if(transform.position.y < boundBotRight.position.y)
        {
            transform.position = new Vector2(transform.position.x, boundBotRight.position.y);
        }
        if(transform.position.y > boundTopLeft.position.y)
        {
            transform.position = new Vector2(transform.position.x, boundTopLeft.position.y);
        }
    }
}
