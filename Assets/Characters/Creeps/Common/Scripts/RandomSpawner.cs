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
            factory = new GoblinFactory();
            SpawnCreep();
            spawnGoblinTimer.Run();
        }
        if (spawnWormTimer.Finished)
        {
            factory = new WormFactory();
            SpawnCreep();
            spawnWormTimer.Run();
        }
        //if (spawnGiantGoblinTimer.Finished)
        //{
        //    SpawnGiantGob();
        //    spawnGiantGoblinTimer.Run();
        //}
        //if (spawnChestTimer.Finished)
        //{
        //    SpawnChest();
        //    spawnChestTimer.Run();
        //}
    }

    AbstractFactory factory;
    private void SpawnCreep()
    {
        Vector2 location_creep = SpawnPosition();
        Creep creep = factory.CreateCreep(location_creep);
        if (creep == null) return;
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
