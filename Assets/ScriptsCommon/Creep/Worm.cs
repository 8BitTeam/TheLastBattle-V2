using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Creep
{
    protected override void InitSubClass()
    {
        // Lấy type từ Factory
        type = TypeFactory.Instance.GetCreepType("worm", 5, 25, 2, 3, 1, 50, 0.5f);
        health = type.MaxHealth;
    }

    public override void AttachMain()
    {
        // Không cần attack cận chiến
    }  
}
