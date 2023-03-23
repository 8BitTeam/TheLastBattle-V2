using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigModel
{
    
    public class MainGun
    {
        public class GatlingGun
        {
            public float shootDistance;
            public float secondPerShoot;
            public float fireForceAmplitude;
            public int bulletDamage;
        }
        public class ShotGun
        {
            public float shootDistance;
            public float secondPerShoot;
            public float fireForceAmplitude;
            public int bulletDamage;
        }

        public GatlingGun gatlingGun;
        public ShotGun shotGun;

        public MainGun()
        {
            gatlingGun = new GatlingGun();
            shotGun = new ShotGun();
        }
    }

    public class ShootFireballGun
    {
        public float shootDistance;
        public float secondPerShoot;
        public float fireForceAmplitude;
        public int bulletDamage;
    }

    public class Creep
    {
        public class Goblin
        {
            public int damage;
            public float maxDistanceWithCamera;
            public float speed;
            public float radiusAreaMoving;
            public float standDuration;
            public float maxHealth;
            public float attackRange;
        }
        public class Worm
        {
            public int damage;
            public float maxDistanceWithCamera;
            public float speed;
            public float radiusAreaMoving;
            public float standDuration;
            public float maxHealth;
            public float attackRange;
        }
        public class GiantGoblin
        {
            public int damage;
            public float maxDistanceWithCamera;
            public float speed;
            public float radiusAreaMoving;
            public float standDuration;
            public float maxHealth;
            public float attackRange;
        }

        public Goblin goblin;
        public Worm worm;
        public GiantGoblin giantGoblin;

        public Creep()
        {
            goblin = new Goblin();
            worm = new Worm();
            giantGoblin = new GiantGoblin();
        }
    }

    public MainGun mainGun;
    public ShootFireballGun shootFireballGun;
    public Creep creep;

    public GameConfigModel()
    {
        mainGun = new MainGun();
        shootFireballGun = new ShootFireballGun();
        creep = new Creep();
    }
}
