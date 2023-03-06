using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected CreepContext context;

    public void SetContext(CreepContext context)
    {
       this.context = context;
    }

    public abstract void StartState();
    public abstract void EndState();
}
