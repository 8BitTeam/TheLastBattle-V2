using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevUGenerate : MonoBehaviour
{
    private float player_distance_swpan = 200f;
    [SerializeField]
    private Transform mapTranform;
    [SerializeField]
    private Transform startPart;
    private Vector3 lastendposition;
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
    private void Awake()
    {
        lastendposition = startPart.Find("UpPoint").position;
        int startspawnlevelpart = 2;
        for (int i = 0; i < startspawnlevelpart; i++)
        {
            spawnlevelpart();
        }
    }
    private void spawnlevelpart()
    {
        Transform lastleveltransform = spwanTileMap(lastendposition);
        lastendposition = lastleveltransform.Find("UpPoint").position;

    }
    private Transform spwanTileMap(Vector3 spwanpositon)
    {
        Transform levelPart = Instantiate(mapTranform, spwanpositon, Quaternion.identity);
        return levelPart;
    }
    void Update()
    {
        if (Vector3.Distance(player.transform.position, lastendposition) < player_distance_swpan)
        {
            spawnlevelpart();
        }
    }
}
