using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepContext
{
    private State _state = null;

    public CreepContext(State state)
    {
        _state = state;
        _state.SetContext(this);
    }
}
