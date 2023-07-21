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
        if (aiObject.type == "BarbAxeman")
        {
            aiObject.barbarianAnimation.animator.ResetTrigger("SlashAttack");
        }
       

    }

    public override void UpdateState()
    {
        GameObject.Destroy(aiObject.gameObject, 30);
    }

    public override void FixedUpdateState()
    {

    }


}
