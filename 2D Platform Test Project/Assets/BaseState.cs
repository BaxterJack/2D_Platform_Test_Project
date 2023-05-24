using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected AiObject aiObject;
    protected BaseState(AiObject AiObject)
    {
        aiObject = AiObject;
    }

    public abstract void EnterState(/*BarbStateManager barbarian*/);

    public abstract void UpdateState(/*BarbStateManager barbarian*/);

    public abstract void FixedUpdateState(/*BarbStateManager barbarian*/);

    //public abstract bool CanTransition();
}
