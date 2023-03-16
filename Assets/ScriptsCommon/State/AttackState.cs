using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public override void EnterState(Creep creep)
    {
        if (!ScreenHelper.CompareCurrentAnimationName(creep.animator, "Attack"))
        {
            creep.animator.SetTrigger("attack");
        }
    }

    public override void ExitState(Creep creep)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(Creep creep)
    {
    }
}
