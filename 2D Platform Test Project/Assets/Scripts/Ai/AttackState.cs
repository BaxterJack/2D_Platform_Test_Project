using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    
    bool isAttacking;
    
    public AttackState(AiObject AiObject) : base(AiObject)
    {

    }

    public override void EnterState()
    {
        //aiObject.timeSinceAttack = 0.0f;
        
    }

    public override void UpdateState()
    {
        aiObject.SetAttackOffset();
        aiObject.SetDestination(aiObject.PlayerPosition, aiObject.AttackOffset);
        aiObject.SetTarget(aiObject.GetPlayerPosition());
        aiObject.SetDistanceToDestintion();
        isAttacking = aiObject.barbarianAnimation.animator.GetCurrentAnimatorStateInfo(0).IsName("BarbSlashAnim");
        
        if (!isAttacking)
        {
            SlashAttack();
        }
        else
        {
            aiObject.attackCoolDown += Time.deltaTime;
        }
    }

    public override void FixedUpdateState()
    {

    }

    void SlashAttack()
    {
        aiObject.barbarianAnimation.Slash();
    }


}
