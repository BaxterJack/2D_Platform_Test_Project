using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateTransition 
{
    public BaseState sourceState;
    public BaseState transitionState;
    public Func<bool> delegatePtr;
    public StateTransition(BaseState SourceState, BaseState TransitionState, Func<bool> DelegatePtr)
    {
        BaseState sourceState = SourceState;
        BaseState transitionState = TransitionState;
        Func<bool> delegatePtr = DelegatePtr;
    }
}

