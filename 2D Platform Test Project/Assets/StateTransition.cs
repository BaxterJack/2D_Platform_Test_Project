using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateTransition 
{
    public BaseState sourceState;
    public BaseState transitionState;
    public Func<bool> funcTest;
    public StateTransition(BaseState SourceState, BaseState TransitionState, Func<bool> FuncTest)
    {
        sourceState = SourceState;
        transitionState = TransitionState;
        funcTest = FuncTest;
    }
}

