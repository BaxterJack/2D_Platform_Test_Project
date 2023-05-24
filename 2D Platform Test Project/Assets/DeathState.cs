using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : BaseState
{

    public DeathState(AiObject AiObject) : base(AiObject)
    {

    }

    public override void EnterState()
    {
        aiObject.barbarianAnimation.Die();
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }


}
