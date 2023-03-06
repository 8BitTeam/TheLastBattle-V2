using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepModel
{
    private string name;
    private float x, y;
    private float health;

    public string Name { get { return name; } set { name = value; } }
    public float X { get { return x; } set { x = value; } }
    public float Y { get { return y; } set { y = value; } }
    public float Health { get { return health; } set { health = value; } }
}
