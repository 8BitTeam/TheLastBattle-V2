using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommonGunController : MonoBehaviour
{
    private GameObject nearbyCreep;
    private float distanceToNearestCreep;
    [SerializeField]
    private float shootDistance = 5;
    [SerializeField]
    private float secondPerShoot = 0.01f;
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        // Start timer;
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = secondPerShoot;
        timer.Run();
    }

    // Update is called once per frame
    Vector2 lookDirection;

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

    private (GameObject, float) FindNearestCreep()
    {
        float minDistance = float.PositiveInfinity;

        GameObject[] nearbyCreepList = GameObject.FindGameObjectsWithTag("creep");
        if (nearbyCreepList.Count() == 0)
        {
            return (null, minDistance);
        }
        GameObject nearestCreep = nearbyCreepList[0];
        foreach (GameObject creep in nearbyCreepList)
        {
            float distance = (transform.position - creep.transform.position).sqrMagnitude;
            {
                if (distance < minDistance)
                {
                    nearestCreep = creep;
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

    public bool isCanShoot = false;
    private void CheckCanShoot()
    {
        if (timer.Finished && distanceToNearestCreep <= shootDistance * shootDistance)
        {
            isCanShoot = true;
            timer.Run();
        }
        else
        {
            isCanShoot = false;
        }
    }
}
