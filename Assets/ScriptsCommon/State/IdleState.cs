using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void EnterState(Creep creep)
    {
        creep.speedAction = 0;
        if (!ScreenHelper.CompareCurrentAnimationName(creep.animator, "Idle"))
        {
            creep.animator.SetTrigger("idle");
        }
    }

    public override void ExitState(Creep creep)
    {
        throw new System.NotImplementedException();
    }

    //public override void UpdateState(Creep creep)
    //{
    //    throw new System.NotImplementedException();
    //}
}
