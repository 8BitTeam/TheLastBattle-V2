using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : BaseState
{
    public override void EnterState(Creep creep)
    {
        if (!ScreenHelper.CompareCurrentAnimationName(creep.animator, "Death"))
        {
            creep.SetCollider(false);
            creep.animator.SetTrigger("dead");
            creep.audioDeath.Play();
        }
    }

    public override void ExitState(Creep creep)
    {
    }
    public override void UpdateState(Creep creep)
    {
    }
}
