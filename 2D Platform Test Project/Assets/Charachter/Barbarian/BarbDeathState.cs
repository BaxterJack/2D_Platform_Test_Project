using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbDeathState : BarbBaseState
{
    BarbStateManager barb;

    public BarbDeathState(BarbStateManager Barb)
    {
        barb = Barb;
    }

    public override void EnterState(BarbStateManager barbarian)
    {
        barb.barbarianAnimation.Die();
    }

    public override void UpdateState(BarbStateManager barbarian)
    {
       
    }

    public override void FixedUpdateState(BarbStateManager barbarian)
    {
       
    }


}
