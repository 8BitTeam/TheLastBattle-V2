using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    
    [SerializeField]
    private Rigidbody2D bullet;

    [SerializeField]
    private Transform barrel;
    [SerializeField]
    private int timeFire;

    private float bulletSpeed = 500f;
    Timer timer;
    string currentWeaponName;
    GameObject shotter;
    // Start is called before the first frame update
    void Start()
    {
        currentWeaponName = gameObject.name.Substring(0, name.IndexOf("_"));
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = timeFire;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
           
                
                WeaponFire(currentWeaponName);
            timer.Run();
            
        }
    }
    private void WeaponFire(string weaponName)
    {
        if(weaponName == "Pistol")
        {
            var spawnedBullet = Instantiate(bullet,barrel.position,barrel.rotation);
            spawnedBullet.AddForce(barrel.up * bulletSpeed);
        }
        else if(weaponName == "Shotgun")
        {
            for(int i = 0; i <= 2; i++)
            {
                var spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);

                switch (i)
                {
                    case 0:
                        spawnedBullet.AddForce(barrel.up * bulletSpeed + new Vector3(0f,-90f,0f));
                        break;
                    case 1:
                        spawnedBullet.AddForce(barrel.up * bulletSpeed + new Vector3(0f, 0f, 0f));
                        break;
                    case 2:
                        spawnedBullet.AddForce(barrel.up * bulletSpeed + new Vector3(0f, 90f, 0f));
                        break;
                }
            }
            
        }
    }
}
