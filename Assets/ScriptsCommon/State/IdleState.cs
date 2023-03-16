using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    //public Vector3? destinationForRandomMove = null;
    public bool isTimerRun = true;
    public override void EnterState(Creep creep)
    {
        creep.speedAction = 0;
        if (!ScreenHelper.CompareCurrentAnimationName(creep.animator, "Idle"))
        {
            creep.animator.SetTrigger("idle");
        }
        creep.timer.Run();
    }

    public override void ExitState(Creep creep)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(Creep creep)
    {
        if (creep.timer.Finished)
        {
            creep.destinationForRandomMove = new Vector2(
                Random.Range(creep.bornPosition.x - creep.type.RadiusAreaMoving, creep.bornPosition.x + creep.type.RadiusAreaMoving),
                Random.Range(creep.bornPosition.y - creep.type.RadiusAreaMoving, creep.bornPosition.y + creep.type.RadiusAreaMoving)
            );
            
            creep.SwitchState(creep.randomWalkingState);

        }
    }
}
