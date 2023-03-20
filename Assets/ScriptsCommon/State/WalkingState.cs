using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : BaseState
{
    private void RunToMain(float speed, Creep creep)
    {
        creep.stepPerFrame = Time.fixedDeltaTime * speed;
        creep.gameObject.transform.position = Vector2.MoveTowards(creep.transform.position, creep.main.transform.position, creep.stepPerFrame);
    }
    public override void EnterState(Creep creep)
    {
        creep.speedAction = creep.type.Speed;
        if (!ScreenHelper.CompareCurrentAnimationName(creep.animator, "Walking"))
        {
            creep.animator.SetTrigger("walk");
        }
    }

    public override void ExitState(Creep creep)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState(Creep creep)
    {
        RunToMain(creep.speedAction, creep);
        Vector2 facingDirection = creep.main.transform.position - creep.transform.position;
        ScreenHelper.Facing(facingDirection, creep.isFacingRight, creep.gameObject);
    }
}
