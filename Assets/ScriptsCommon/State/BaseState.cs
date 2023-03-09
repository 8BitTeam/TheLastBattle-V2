using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(Creep creep);
    //public abstract void UpdateState(Creep creep);
    public abstract void ExitState(Creep creep);
}
