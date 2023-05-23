using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BarbBaseState
{
    //--------------------------------------------------------------------BarbarianAxeman
    public abstract void EnterState(BarbStateManager barbarian);

    public abstract void UpdateState(BarbStateManager barbarian);

    public abstract void FixedUpdateState(BarbStateManager barbarian);

    //--------------------------------------------------------------------BarbarianBowman

    public abstract void EnterState(BarbBowStateManager barbarianBow);

    public abstract void UpdateState(BarbBowStateManager barbarianBow);

    public abstract void FixedUpdateState(BarbBowStateManager barbarianBow);

}


