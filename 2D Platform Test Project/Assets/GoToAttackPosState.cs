using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToAttackPosState : BaseState
{

    public GoToAttackPosState(AiObject AiObject) : base(AiObject)
    {

    }

    public override void EnterState()
    {
        aiObject.SetAttackOffset();

        if (aiObject.distanceToTarget < 0.1 && aiObject.attackCoolDown <= 0.0f)
        {
           // barbarian.SwitchState(barbarian.attackState);
            return;
        }
        if (!aiObject.aiSight.CanSeePlayer())
        {
           // barbarian.SwitchState(barbarian.patrolState);
            return;
        }
        if (aiObject.healthBar.currentHealth <= 0)
        {
           // barbarian.SwitchState(barbarian.deathState);
            return;
        }
    }

    public override void UpdateState()
    {
        aiObject.MoveAI();
    }

    public override void FixedUpdateState()
    {

    }
}
