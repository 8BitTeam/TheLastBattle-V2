using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GunType
{
    public float ShootDistance {get; private set; }
    public float SecondPerShoot { get; private set; }
    public float FireForceAmplitude { get; private set; }
    public int BulletDamage { get; private set; }

    public GunType(float shootDistance, float secondPerShoot, float fireForceAmplitude, int bulletDamage)
    {
        ShootDistance = shootDistance;
        SecondPerShoot = secondPerShoot;
        FireForceAmplitude = fireForceAmplitude;
        BulletDamage = bulletDamage;
    }
}