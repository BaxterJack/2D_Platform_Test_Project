using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbDeathState : BarbBaseState
{
    BarbStateManager stateMachine;

    public BarbDeathState(BarbStateManager StateMachine)
    {
        stateMachine = StateMachine;
    }

    public override void EnterState(BarbStateManager barbarian)
    {
        stateMachine.barbarianAnimation.Die();
    }

    public override void UpdateState(BarbStateManager barbarian)
    {
       
    }

    public override void FixedUpdateState(BarbStateManager barbarian)
    {
       
    }


}
