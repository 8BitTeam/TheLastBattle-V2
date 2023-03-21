using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class MainGun : Gun
{
    public GameObject nearbyCreep;
    public Transform barrel;

    public float distanceToNearestCreep;

    void Start()
    {
        // Start timer;
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = secondPerShoot;
        timer.Run();

        barrel = ScreenHelper.FindChildWithTag(gameObject, "gunBarrel").transform;
        factory = new MainFactory();
    }

    void Update()
    {
        (nearbyCreep, distanceToNearestCreep) = FindNearestCreep();
        if (nearbyCreep != null)
        {
            lookDirection = nearbyCreep.transform.position - transform.position;
            transform.right = lookDirection;
        }
        CheckCanShoot();
    }

    public (GameObject, float) FindNearestCreep()
    {
        float minDistance = float.PositiveInfinity;
        
        Creep[] nearbyCreepList = FindObjectsOfType<Creep>(false)
            .Where(c => !c.currentState.GetType().Equals(typeof(DeadState))).ToArray();
        if (nearbyCreepList.Count() == 0)
        {
            return (null, minDistance);
        }
        GameObject nearestCreep = nearbyCreepList[0].gameObject;
        foreach (Creep creep in nearbyCreepList)
        {
            float distance = (transform.position - creep.transform.position).sqrMagnitude;
            {
                if (distance < minDistance)
                {
                    nearestCreep = creep.gameObject;
                    minDistance = distance;
                }
            }
        }
        return (nearestCreep, minDistance);
    }

    public Vector3 GetBarrelDirection()
    {
        GameObject barrel = ScreenHelper.FindChildWithTag(gameObject, "gunBarrel");
        return barrel.transform.position - transform.position;
    }

    public override void CheckCanShoot()
    {
        if (timer.Finished && distanceToNearestCreep <= shootDistance * shootDistance)
        {
            Shoot();
            timer.Run();
        }
    }

    public override Vector3 GetShootDirection()
    {
        return barrel.position - transform.position;
    }
}
