using Assets.ScriptsCommon;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainSkillsScript : MonoBehaviour
{
    private Rigidbody2D body;
    private MainMovingScript mainMoving;
    private MainAttackScript mainAttack;
    private GameObject machineGun, shotGun, boom;
    private DropCircleBullet shotGunController;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        mainMoving = GetComponent<MainMovingScript>();
        mainAttack = GetComponent<MainAttackScript>();
        shotGunController = transform.Find("InnerPowerBulletHell").GetComponent<DropCircleBullet>();
        machineGun = transform.Find("MachineGun").gameObject;
        shotGun = transform.Find("ShotGun").gameObject;
        boom = (GameObject) Resources.Load(PrefabPath.BOOM);

        Button btnDash = GameObject.Find("DashButton").GetComponent<Button>();
        btnDash.onClick.AddListener(Dash);

        Button btnChangeGun = GameObject.Find("ChangeGun").GetComponent<Button>();
        btnChangeGun.onClick.AddListener(ChangeGun);

        Button btnBom = GameObject.Find("ThrowBombButton").GetComponent<Button>();
        btnBom.onClick.AddListener(Bom);

        Button btnCBullet = GameObject.Find("CircleBulletButton").GetComponent<Button>();
        btnCBullet.onClick.AddListener(CircleBullet);
    }

    void Update() 
    {

    }
    private bool change = false;
    private void ChangeGun()
    {

        if (!change)
        {
            machineGun.SetActive(false);
            shotGun.SetActive(true);
            change = true;
        }
        else
        {
            machineGun.SetActive(true);
            shotGun.SetActive(false);
            change = false;
        }
    }

    private void CircleBullet()
    {
        if (mainAttack.mana.TrySpendMana(50))
        {
            shotGunController.Shoot();
        }
    }

    private void Bom()
    {
        if (mainAttack.mana.TrySpendMana(50)) {
            Instantiate(boom, gameObject.transform.position, Quaternion.identity);
        }
    }

    private void Dash()
    {
        if (mainAttack.mana.TrySpendMana(30))
        {
            mainMoving.enableMovement = false;
            StartCoroutine(Dashing());

        }
    }

    [SerializeField]
    private float dashingTime = 0.35f;
    [SerializeField]
    private float dashingStrength = 4;
    private IEnumerator Dashing()
    {
        Joystick joyStick = GameObject.FindGameObjectWithTag("joystick").GetComponent<FloatingJoystick>();

        float jHorizon = JoyStickNormalized().y;
        float jVertical = JoyStickNormalized().x;
        Vector2 dashingDirection = new Vector3(jHorizon, jVertical, 0);
        if (dashingDirection == Vector2.zero)
        {
            dashingDirection.x = transform.localScale.normalized.x;
        }

        body.AddForce(dashingDirection * dashingStrength * 1000f);

        yield return new WaitForSeconds(dashingTime);
        body.velocity = Vector2.zero;
        mainMoving.enableMovement = true;


        Vector2 JoyStickNormalized()
        {
            Vector3 input = new Vector3(joyStick.Vertical, joyStick.Horizontal);
            return input.normalized;
        }
    }
}
