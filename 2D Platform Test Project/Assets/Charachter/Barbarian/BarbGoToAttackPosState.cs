using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbGoToAttackPosState : BarbBaseState
{
    BarbStateManager barb;
    float distanceToTarget;
    float attackOffset;
    public BarbGoToAttackPosState(BarbStateManager Barb)
    {
        barb = Barb;
    }

    public override void EnterState(BarbStateManager barbarian)
    {

    }

    public override void UpdateState(BarbStateManager barbarian)
    {
        SetAttackOffset();
        if(distanceToTarget < 0.1 && barb.attackCoolDown <=0.0f)
        {
            barb.SwitchState(barb.attackState);
            return;
        }
        if (!barb.aiSight.CanSeePlayer())
        {
            barb.SwitchState(barb.patrolState);
            return;
        }
        if (barb.healthBar.currentHealth <= 0)
        {
            barb.SwitchState(barb.deathState);
            return;
        }
    }

    public override void FixedUpdateState(BarbStateManager barbarian)
    {
        MoveAI();
    }

    void MoveAI()
    {
        Rigidbody2D rigidbody2D = barb.GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody2D.velocity;
        Vector2 barbPosition = rigidbody2D.transform.transform.position;
        barb.direction = (barbPosition - barb.destination);
        velocity.x = barb.direction.normalized.x * -barb.speed;
        rigidbody2D.velocity = velocity;
    }

    void SetAttackOffset()
    {
        attackOffset = (barb.transform.position.x - barb.GetComponentInChildren<Attack_Point>().transform.position.x) * 1.25f;
        barb.destination = barb.player.transform.localPosition;
        barb.target = barb.destination;
        barb.destination.x += attackOffset;
        distanceToTarget = (barb.destination - (Vector2)barb.transform.position).magnitude;
    }
}
