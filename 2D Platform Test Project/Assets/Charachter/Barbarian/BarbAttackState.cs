using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbAttackState : BarbBaseState
{
    BarbStateManager stateManager;

    float distanceToTarget;
    float attackOffset;

    bool isAttacking;


    float timeSinceAttack = 0.0f;

    public BarbAttackState(BarbStateManager StateManager)
    {
        stateManager = StateManager;
    }
    public override void EnterState(BarbStateManager barbarian)
    {
        
    }

    public override void UpdateState(BarbStateManager barbarian)
    {

        if (stateManager.healthBar.currentHealth <= 0)
        {
            stateManager.SwitchState(stateManager.deathState);
            return;
        }
        isAttacking = stateManager.barbarianAnimation.animator.GetCurrentAnimatorStateInfo(0).IsName("BarbSlashAnim");
        if(!isAttacking)
        {
            SlashAttack();
        }
        else
        {
            timeSinceAttack += Time.deltaTime;
        }
        
        if(timeSinceAttack > 1.5f)
        {
            ApplyDamage();
            timeSinceAttack = 0.0f;
            stateManager.attackCoolDown = 3.0f;
            stateManager.SwitchState(stateManager.goToAttackPosState);
        }
        
    }

    public override void FixedUpdateState(BarbStateManager barbarian)
    {

    }

    void SetAttackOffset()
    {
        attackOffset = (stateManager.transform.position.x - stateManager.GetComponentInChildren<Attack_Point>().transform.position.x) * 1.25f;
        stateManager.destination = stateManager.player.transform.localPosition;
        stateManager.target = stateManager.destination;
        stateManager.destination.x += attackOffset;
        distanceToTarget = (stateManager.destination - (Vector2)stateManager.transform.position).magnitude;
    }

    void SlashAttack()
    {
        stateManager.barbarianAnimation.Slash();


    }

    void ApplyDamage()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(stateManager.attackPoint.transform.position, stateManager.attackPoint.attackRange, stateManager.playerLayers);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponentInChildren<HealthBar>().TakeDamage(20);
            Debug.Log("We hit " + player.name);
        }
    }
}
