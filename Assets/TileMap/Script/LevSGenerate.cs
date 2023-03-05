using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevSGenerate : MonoBehaviour
{
    private float player_distance_swpan = 200f;
    [SerializeField]
    private Transform startPart;
    [SerializeField]
    private Transform mapTranform;
    [SerializeField]
    private GameObject player;
    private Vector3 lastendposition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    private void Awake()
    {
        lastendposition = startPart.Find("StartPoint").position;
        //Transform levelPastTransform;
        int startspawnlevelpart = 2;
        for (int i = 0; i < startspawnlevelpart; i++)
        {
            spawnlevelpart();
        }
        //spawnlevelpart();
        //levelPastTransform = spwanTileMap(startPart.Find("EndPoint").position);
        //levelPastTransform =  spwanTileMap(levelPastTransform.Find("EndPoint").position);
        //levelPastTransform = spwanTileMap(levelPastTransform.Find("EndPoint").position);
        //levelPastTransform = spwanTileMap(levelPastTransform.Find("EndPoint").position);
        //levelPastTransform = spwanTileMap(levelPastTransform.Find("EndPoint").position);
        // spwanTileMap(new Vector3(0.2f, 0)+new Vector3(70,0));
        // spwanTileMap(new Vector3(0.2f, 0)+new Vector3(70+70,0));
    }
    void Update()
    {
        if (Vector3.Distance(player.transform.position, lastendposition) < player_distance_swpan)
        {
            spawnlevelpart();
        }
    }
    private void spawnlevelpart()
    {
        Transform lastleveltransform = spwanTileMap(lastendposition);
        lastendposition = lastleveltransform.Find("StartPoint").position;

    }
    private Transform spwanTileMap(Vector3 spwanpositon)
    {
        Transform levelPart = Instantiate(mapTranform, spwanpositon, Quaternion.identity);
        return levelPart;
    }
}
