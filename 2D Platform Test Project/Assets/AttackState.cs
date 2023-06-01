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
        //aiObject.SetDestination(aiObject.GetPlayerPosition(), aiObject.GetAttackOffset());
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
        //if (aiObject.timeSinceAttack >= 1.5f)
        //{
        //    //ApplyDamage();
        //    aiObject.timeSinceAttack = 0.0f;
        //    aiObject.attackCoolDown = 3.0f;
        //}
    }

    public override void FixedUpdateState()
    {

    }

    void SlashAttack()
    {
        aiObject.barbarianAnimation.Slash();
    }

    //void ApplyDamage()
    //{
    //    Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(aiObject.attackPoint.transform.position, aiObject.attackPoint.attackRange, aiObject.playerLayers);

    //    foreach (Collider2D player in hitPlayer)
    //    {
    //        player.GetComponentInChildren<HealthBar>().TakeDamage(20);
    //        Debug.Log("We hit " + player.name);
    //    }
    //}
}
