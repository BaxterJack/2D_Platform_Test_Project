using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateTransition 
{
    public BaseState sourceState;
    public BaseState transitionState;
    public Func<bool> canTransition;
    public StateTransition(BaseState SourceState, BaseState TransitionState, Func<bool> CanTransition)
    {
        sourceState = SourceState;
        transitionState = TransitionState;
        canTransition = CanTransition;
    }
}

