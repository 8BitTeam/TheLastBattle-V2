using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField]
    //GameObject prefabGoblin;
    public float spawnGoblinTime = 1f;
    public float spawnWormTime = 5f;
    public float spawnGiantGoblinTime = 100f;
    public float spawnChestTime = 60 * 5f;

    private Timer spawnGoblinTimer;
    private Timer spawnWormTimer;
    private Timer spawnGiantGoblinTimer;
    private Timer spawnChestTimer;


    Bounds bounds;
    float f_min_x;
    float f_max_x;
    float f_min_y;
    float f_max_y;
    float min_x;
    float max_x;
    float min_y;
    float max_y;
    float bounce = 3f;
    int spawnSide;

    void Start()
    {
        spawnSide = Random.Range(0, 4);
        spawnGoblinTimer = gameObject.AddComponent<Timer>();
        spawnGoblinTimer.Duration = spawnGoblinTime;
        spawnGoblinTimer.Run();

        spawnWormTimer = gameObject.AddComponent<Timer>();
        spawnWormTimer.Duration = spawnWormTime;
        spawnWormTimer.Run();

        spawnGiantGoblinTimer = gameObject.AddComponent<Timer>();
        spawnGiantGoblinTimer.Duration = spawnGiantGoblinTime;
        spawnGiantGoblinTimer.Run();

        spawnChestTimer = gameObject.AddComponent<Timer>();
        spawnChestTimer.Duration = spawnChestTime;
        spawnChestTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        bounds = ScreenHelper.OrthographicBounds(Camera.main);
        f_min_x = bounds.min.x;
        f_max_x = bounds.max.x;
        f_min_y = bounds.min.y;
        f_max_y = bounds.max.y;
        min_x = f_min_x - bounce;
        max_x = f_max_x + bounce;
        min_y = f_min_y - bounce;
        max_y = f_max_y + bounce;
        if (spawnGoblinTimer.Finished)
        {
            SpawnGob();
            spawnGoblinTimer.Run();
        }
        if (spawnWormTimer.Finished)
        {
            SpawnWor();
            spawnWormTimer.Run();
        }
        if (spawnGiantGoblinTimer.Finished)
        {
            SpawnGiantGob();
            spawnGiantGoblinTimer.Run();
        }
        if (spawnChestTimer.Finished)
        {
            SpawnChest();
            spawnChestTimer.Run();
        }
    }

    private void SpawnGob()
    {
        Vector2 location_creep = SpawnPosition() ;
        
        //Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        //GameObject gob = Instantiate<GameObject>(prefabGoblin, location_creep, Quaternion.identity) as GameObject;
        GameObject gob = ObjectPooler.Instance.SpawnFromPool("goblinCreep", location_creep, Quaternion.identity);
        if (gob == null) return;
    }

    private void SpawnWor()
    {
        Vector2 location_creep = SpawnPosition();     
        //Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        GameObject worm = ObjectPooler.Instance.SpawnFromPool("wormCreep", location_creep, Quaternion.identity);
        if (worm == null) return;
    }

    private void SpawnGiantGob()
    {
        Vector2 location_creep = SpawnPosition();
        //Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        GameObject worm = ObjectPooler.Instance.SpawnFromPool("giantGoblinCreep", location_creep, Quaternion.identity);
        if (worm == null) return;
    }

    private void SpawnChest()
    {
        Vector2 location_chest = SpawnPosition();
        //Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        var random = Random.Range(0, 1);
        var tag = "chest1";
        if(random > 0.5)
        {
            tag = "chest1";
        }
        GameObject chest = ObjectPooler.Instance.SpawnFromPool(tag, location_chest, Quaternion.identity);
        if (chest == null) return;
    }

    private Vector2 SpawnPosition()
    {
        Vector2 location_creep;
        switch (spawnSide)
        {
            case 0:
                {
                    location_creep = new Vector2(Random.Range(f_max_x, max_x),
            Random.Range(f_max_y, max_y));
                    spawnSide = Random.Range(0, 4);
                    break;
                }
            case 1:
                {
                    location_creep = new Vector2(Random.Range(f_max_x, max_x),
            Random.Range(f_min_y, min_y));
                    spawnSide = Random.Range(0, 4);
                    break;
                }
            case 2:
                {
                    location_creep = new Vector2(Random.Range(f_min_x, min_x),
            Random.Range(f_min_y, min_y));
                    spawnSide = Random.Range(0, 4);
                    break;
                }
            case 3:
                {
                    location_creep = new Vector2(Random.Range(f_min_x, min_x),
            Random.Range(f_max_y, max_y));
                    spawnSide = Random.Range(0, 4);
                    break;
                }
            default:
                {
                    location_creep = new Vector2(Random.Range(f_min_x, min_x),
            Random.Range(f_min_y, min_y));
                    break;
                }
        };
        return location_creep;
    }
}
