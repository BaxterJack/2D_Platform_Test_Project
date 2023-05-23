using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbGoToAttackPosState : BarbBaseState
{
    float distanceToTarget;
    float attackOffset;

    //---------------------------------------------------------BarbarianAxeman
    public override void EnterState(BarbStateManager barbarian)
    {

    }

    public override void UpdateState(BarbStateManager barbarian)
    {
        SetAttackOffset(barbarian);
        if(distanceToTarget < 0.1 && barbarian.attackCoolDown <=0.0f)
        {
            barbarian.SwitchState(barbarian.attackState);
            return;
        }
        if (!barbarian.aiSight.CanSeePlayer())
        {
            barbarian.SwitchState(barbarian.patrolState);
            return;
        }
        if (barbarian.healthBar.currentHealth <= 0)
        {
            barbarian.SwitchState(barbarian.deathState);
            return;
        }
    }

    public override void FixedUpdateState(BarbStateManager barbarian)
    {
        MoveAI(barbarian);
    }

    void MoveAI(BarbStateManager barbarian)
    {
        Rigidbody2D rigidbody2D = barbarian.GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody2D.velocity;
        Vector2 barbPosition = rigidbody2D.transform.transform.position;
        barbarian.direction = (barbPosition - barbarian.destination);
        velocity.x = barbarian.direction.normalized.x * -barbarian.speed;
        rigidbody2D.velocity = velocity;
    }

    void SetAttackOffset(BarbStateManager barbarian)
    {
        attackOffset = (barbarian.transform.position.x - barbarian.GetComponentInChildren<Attack_Point>().transform.position.x) * 1.25f;
        barbarian.destination = barbarian.player.transform.localPosition;
        barbarian.target = barbarian.destination;
        barbarian.destination.x += attackOffset;
        distanceToTarget = (barbarian.destination - (Vector2)barbarian.transform.position).magnitude;
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
