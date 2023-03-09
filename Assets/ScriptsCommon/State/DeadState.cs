using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : BaseState
{
    public override void EnterState(Creep creep)
    {
        if (!ScreenHelper.CompareCurrentAnimationName(creep.animator, "Death"))
        {
            creep.animator.SetTrigger("dead");
            creep.audioDeath.Play();
        }
    }
    public override void ExitState(Creep creep)
    {
        creep.gameObject.tag = "deadCreep";
        creep.SetCollider(false);
        // Trạng thái của biến canRun == false để không di chuyển nữa, việc kiểm tra biến này nằm trong hàm Update
        creep.canRun = false;
    }
    //public override void UpdateState(Creep creep)
    //{
    //    throw new System.NotImplementedException();
    //}
}
