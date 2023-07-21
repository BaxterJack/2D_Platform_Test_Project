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
        
    }

    public override void UpdateState()
    {
        aiObject.SetDestination(aiObject.PlayerPosition);
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
