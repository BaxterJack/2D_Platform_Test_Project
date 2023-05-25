using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public BaseState currentState;
//    public BaseDelegates baseDelegates;

    List<BaseState> allStates;
    List<StateTransition> allTransitions;
    public StateMachine()
    {
        allStates = new List<BaseState>();
        allTransitions = new List<StateTransition>();
    }

  
    public void Update()
    {
        SwitchState();
        currentState.UpdateState();
    }

    public void FixedUpdate()
    {
        currentState.FixedUpdateState();
    }

    public void SwitchState(/*BaseState state*/)
    {
        //currentState = state;
        //currentState.EnterState();

        foreach (var transition in allTransitions)
        {
            bool correctState = transition.sourceState == currentState;
            bool canTransition = transition.funcTest();
                if (correctState && canTransition)
                {
                currentState = transition.transitionState;
            }
        }
    }

    public void AddState(BaseState state)
    {
        allStates.Add(state);
        if(allStates.Count == 1)
        {
            currentState = state;
        }
    }

    public void AddTransition( StateTransition transition)
    {
        allTransitions.Add(transition);
    }
}

