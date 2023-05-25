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

    }

    public override void UpdateState()
    {
        aiObject.SetAttackOffset();
        aiObject.SetDestination(aiObject.GetPlayerPosition(), aiObject.GetAttackOffset());
        aiObject.SetTarget(aiObject.GetPlayerPosition());
        aiObject.SetDistanceToDestintion();

        if(aiObject.attackCoolDown >= 0)
        {
            aiObject.attackCoolDown -= Time.deltaTime;
        }
    }

    public override void FixedUpdateState()
    {
        if(aiObject.GetDistanceToDestintion() > 0.1)
        {
            aiObject.MoveAI();
        }
        //aiObject.MoveAI();
    }
}
