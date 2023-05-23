using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BarbBaseState
{
    public abstract void EnterState(BarbStateManager barbarian);

    public abstract void UpdateState(BarbStateManager barbarian);

    public abstract void FixedUpdateState(BarbStateManager barbarian);

}

//public abstract class BarbBaseState
//{
//    public abstract void EnterState(AiStateMachine barbarian);

//    public abstract void UpdateState(AiStateMachine barbarian);

//    public abstract void FixedUpdateState(AiStateMachine barbarian);

//}
