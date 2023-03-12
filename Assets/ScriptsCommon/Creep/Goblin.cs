using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Creep
{
    protected override void InitSubClass()
    {
        // Lấy type từ factory
        type = TypeFactory.Instance.GetCreepType("goblin", 5, 25, 2, 3, 1, 50);
        health = type.MaxHealth;
    }

    public override void AttachMain()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, mainLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<MainAttackScript>().health -= type.Damage;
            this.PostEvent(EventID.OnMainHealthChange);
        }
    }
}
