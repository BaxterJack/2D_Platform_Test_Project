using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public BaseState currentState;

//    List<BaseState> allStates;
    List<StateTransition> allTransitions;
    public StateMachine()
    {
//        allStates = new List<BaseState>();
        allTransitions = new List<StateTransition>();
    }

    public void EnterState()
    {
        currentState.EnterState();
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

    public void SwitchState()
    {
        foreach (var transition in allTransitions)
        {
            bool correctState = transition.sourceState == currentState;
            if (correctState && transition.canTransition())
            {
                currentState = transition.transitionState;
                Debug.Log(currentState);
                currentState.EnterState();
            }
        }
    }

    //public void AddState(BaseState state)
    //{
    //    allStates.Add(state);
    //    if(allStates.Count == 1)
    //    {
    //        currentState = state;
    //    }
    //}
    public void SetInitialState(BaseState initialState)
    {
        currentState = initialState;
    }
    public void AddTransition( StateTransition transition)
    {
        allTransitions.Add(transition);
    }
}

