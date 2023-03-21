using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Creep
{
    protected override void InitSubClass()
    {
        // Lấy type từ factory
        GameConfigModel.Creep.Goblin configGoblin = ScreenHelper.LoadConfig().creep.goblin;
        type = TypeFactory.Instance.GetCreepType("goblin", configGoblin.damage,
            configGoblin.maxDistanceWithCamera, configGoblin.speed, configGoblin.radiusAreaMoving,
            configGoblin.standDuration, configGoblin.maxHealth, configGoblin.attackRange);
        health = type.MaxHealth;
    }

    public override void AttachMain()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, type.AttackRange, mainLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<MainAttackScript>().health -= type.Damage;
            this.PostEvent(EventID.OnMainHealthChange);
        }
    }
}
