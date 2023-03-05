using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabBullet;
    private int amountToPool = 50;
    private List<GameObject> pool = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject bullet = Instantiate(prefabBullet);
            bullet.transform.parent = gameObject.transform;
            bullet.SetActive(false);
            pool.Add(bullet);
        }
    }

    public GameObject GetBulletFromPool()
    {
        foreach (GameObject bullet in pool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }
}
