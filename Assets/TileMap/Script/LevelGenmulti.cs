using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenmulti : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 100f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform levelPart;
    [SerializeField] private Transform player;


    private Vector3 lastRightPosition;
    private Vector3 lastUpPosition;
    private Vector3 lastLeftPosition;
    private Vector3 lastDownPosition;
    private Vector3 playerPosition;

    private void Awake()
    {
        if(levelPart_Start != null)
        {
            lastRightPosition = levelPart_Start.Find("EndPoint").position;
            lastUpPosition = levelPart_Start.Find("UpPoint").position;
            lastLeftPosition = levelPart_Start.Find("StartPoint").position;
            lastDownPosition = levelPart_Start.Find("DownPoint").position;
        }
    }

    private void Update()
    {
        playerPosition = player.transform.position;

        if (Vector3.Distance(playerPosition, lastRightPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPartRight();
        }
        if (Vector3.Distance(playerPosition, lastUpPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPartUp();
        }
        if (Vector3.Distance(playerPosition, lastLeftPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPartLeft();
        }
        if (Vector3.Distance(playerPosition, lastDownPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPartDown();
        }
    }

    private void SpawnLevelPartRight()
    {
        Transform chosenLevelPart = levelPart;
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastRightPosition);
        lastRightPosition = lastLevelPartTransform.Find("EndPoint").position;


    }
    private void SpawnLevelPartUp()
    {
        Transform chosenLevelPart = levelPart;
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastUpPosition);
        lastUpPosition = lastLevelPartTransform.Find("UpPoint").position;
    }
    private void SpawnLevelPartLeft()
    {
        Transform chosenLevelPart = levelPart;
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastLeftPosition);
        lastLeftPosition = lastLevelPartTransform.Find("StartPoint").position;
    }
    private void SpawnLevelPartDown()
    {
        Transform chosenLevelPart = levelPart;
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastDownPosition);
        lastDownPosition = lastLevelPartTransform.Find("DownPoint").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
