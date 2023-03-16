using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkingState : BaseState
{
    //public Vector3? destinationForRandomMove = null;
    public bool isTimerRun = true;
    private void RandomMovingAroundBornPos(Creep creep)
    {
        if (creep.transform.position == creep.destinationForRandomMove)
        {
            //creep.timer.Run();
            //isTimerRun = true;
            creep.SwitchState(creep.idleState);
        }
        //if (destinationForRandomMove == null || (creep.timer.Finished && isTimerRun))
        //{
        //    creep.SwitchState(creep.randomWalkingState);
        //    destinationForRandomMove = new Vector2(
        //        Random.Range(creep.bornPosition.x - creep.type.RadiusAreaMoving, creep.bornPosition.x + creep.type.RadiusAreaMoving),
        //        Random.Range(creep.bornPosition.y - creep.type.RadiusAreaMoving, creep.bornPosition.y + creep.type.RadiusAreaMoving)
        //    );
        //    isTimerRun = false;
        //}

        if (creep.speedAction > 0)
        {
            creep.stepPerFrame = Time.fixedDeltaTime * creep.speedAction;
            creep.gameObject.transform.position = Vector2.MoveTowards(creep.transform.position, (Vector2)creep.destinationForRandomMove, creep.stepPerFrame);
        }
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
        throw new System.NotImplementedException();
    }

    public override void UpdateState(Creep creep)
    {
        RandomMovingAroundBornPos(creep);
        Vector2 facingDirection = (Vector3)creep.destinationForRandomMove - creep.transform.position;
        ScreenHelper.Facing(facingDirection, creep.isFacingRight, creep.gameObject);
        // Lật ngược thêm 1 lần nữa để thanh health luôn quay về 1 phía
        ScreenHelper.Facing(facingDirection, creep.isFacingRight, creep.healthBar);
    }
}
