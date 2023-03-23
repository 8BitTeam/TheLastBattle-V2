using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Creep
{
    protected override void InitSubClass()
    {
        GameConfigModel.Creep.Worm configWorm = ScreenHelper.LoadConfig().creep.worm;
        // Lấy type từ Factory
        type = TypeFactory.Instance.GetCreepType("worm", configWorm.damage,
            configWorm.maxDistanceWithCamera, configWorm.speed, configWorm.radiusAreaMoving,
            configWorm.standDuration, configWorm.maxHealth, configWorm.attackRange);
        health = type.MaxHealth;
    }

    public override void AttachMain()
    {
        // Không cần attack cận chiến
    }  
}
