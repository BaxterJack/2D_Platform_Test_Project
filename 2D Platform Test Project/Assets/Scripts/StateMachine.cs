using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateMachine 
{
    public BaseState currentState;

    List<StateTransition> allTransitions;
    public StateMachine()
    {
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

    public void SetInitialState(BaseState initialState)
    {
        currentState = initialState;
        EnterState();

    }
    public void AddTransition( StateTransition transition)
    {
        allTransitions.Add(transition);
    }
}

