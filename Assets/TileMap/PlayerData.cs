using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int coinscore;
    public float health;
    public float manaSpend;

    public PlayerData (MainAttackScript player,Score score)
    {
        coinscore = score.ScoreNumber;
        health = player.health;
        manaSpend = player.manaSpend;
    }
}
