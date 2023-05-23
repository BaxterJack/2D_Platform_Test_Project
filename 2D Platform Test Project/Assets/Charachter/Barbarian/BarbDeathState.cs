using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbDeathState : BarbBaseState
{
    //---------------------------------------------------------BarbarianAxeman
    public override void EnterState(BarbStateManager barbarian)
    {
        barbarian.barbarianAnimation.Die();
    }

    public override void UpdateState(BarbStateManager barbarian)
    {

    }

    public override void FixedUpdateState(BarbStateManager barbarian)
    {

    }
    //---------------------------------------------------------BarbarianBowman

    public override void EnterState(BarbBowStateManager barbarianBow)
    {
        barbarianBow.barbarianAnimation.Die();
    }

    public override void UpdateState(BarbBowStateManager barbarian)
    {

    }

    public override void FixedUpdateState(BarbBowStateManager barbarian)
    {

    }
}
