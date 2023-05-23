using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbAttackState : BarbBaseState
{
    float distanceToTarget;
    float attackOffset;

    bool isAttacking;
    float timeSinceAttack = 0.0f;


    //---------------------------------------------------------BarbarianAxeman
    public override void EnterState(BarbStateManager barbarian)
    {
        
    }

    public override void UpdateState(BarbStateManager barbarian)
    {

        if (barbarian.healthBar.currentHealth <= 0)
        {
            barbarian.SwitchState(barbarian.deathState);
            return;
        }
        isAttacking = barbarian.barbarianAnimation.animator.GetCurrentAnimatorStateInfo(0).IsName("BarbSlashAnim");
        if(!isAttacking)
        {
            SlashAttack(barbarian);
        }
        else
        {
            timeSinceAttack += Time.deltaTime;
        }
        
        if(timeSinceAttack > 1.5f)
        {
            ApplyDamage(barbarian);
            timeSinceAttack = 0.0f;
            barbarian.attackCoolDown = 3.0f;
            barbarian.SwitchState(barbarian.goToAttackPosState);
        }
        
    }

    public override void FixedUpdateState(BarbStateManager barbarian)
    {

    }

    void SetAttackOffset(BarbStateManager barbarian)
    {
        attackOffset = (barbarian.transform.position.x - barbarian.GetComponentInChildren<Attack_Point>().transform.position.x) * 1.25f;
        barbarian.destination = barbarian.player.transform.localPosition;
        barbarian.target = barbarian.destination;
        barbarian.destination.x += attackOffset;
        distanceToTarget = (barbarian.destination - (Vector2)barbarian.transform.position).magnitude;
    }

    void SlashAttack(BarbStateManager barbarian)
    {
        barbarian.barbarianAnimation.Slash();
    }

    void ApplyDamage(BarbStateManager barbarian)
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(barbarian.attackPoint.transform.position, barbarian.attackPoint.attackRange, barbarian.playerLayers);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponentInChildren<HealthBar>().TakeDamage(20);
            Debug.Log("We hit " + player.name);
        }
    }


    //---------------------------------------------------------BarbarianBowman

    public override void EnterState(BarbBowStateManager barbarianBow)
    {

    }

    public override void UpdateState(BarbBowStateManager barbarian)
    {

    }

    public override void FixedUpdateState(BarbBowStateManager barbarian)
    {

    }
}
