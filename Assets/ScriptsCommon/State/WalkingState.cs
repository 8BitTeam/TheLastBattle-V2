using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : BaseState
{
    public override void EnterState(Creep creep)
    {
        creep.speedAction = creep.Speed;
        if (!ScreenHelper.CompareCurrentAnimationName(creep.animator, "Walking"))
        {
            creep.animator.SetTrigger("walk");
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
