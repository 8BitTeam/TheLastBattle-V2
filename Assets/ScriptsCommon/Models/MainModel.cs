using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainModel
{
    private float x, y;
    private int health;
    private int mana;
    private int score;

    public float X { get { return x; } set { x = value; } }
    public float Y { get { return y; } set { y = value; } }
    public int Health { get { return health; } set { health = value; } }
    public int Mana { get { return mana; } set { mana = value; } }
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
        }
    }
}
