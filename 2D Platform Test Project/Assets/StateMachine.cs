using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public BaseState currentState;
    public BaseDelegates baseDelegates;

    List<BaseState> allStates;
    List<StateTransition> allTransitions;
    public StateMachine(AiObject AiObject, BaseDelegates BaseDelegates)
    {
        baseDelegates = BaseDelegates;
    }
    public void Update()
    {
        currentState.UpdateState();
    }

    public void FixedUpdate()
    {
        currentState.FixedUpdateState();
    }

    public void SwitchState(BaseState state)
    {
        //currentState = state;
        //currentState.EnterState();

        foreach (var transition in allTransitions)
        {
            if (transition.sourceState == currentState  )
            {
               // bool canTransition = transition.delegatePtr;
            }
        }
    }

    public void AddState(BaseState state)
    {
        allStates.Add(state);
        if(allStates.Count == 0)
        {
            currentState = state;
        }
    }

    public void AddTransition(StateTransition transition)
    {
        allTransitions.Add(transition);
    }
}

