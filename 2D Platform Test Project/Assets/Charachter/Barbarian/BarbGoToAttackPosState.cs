using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbGoToAttackPosState : BarbBaseState
{
    BarbStateManager barb;
    public BarbGoToAttackPosState(BarbStateManager Barb)
    {
        barb = Barb;
    }

    float attackOffset;

    public override void EnterState(BarbStateManager barbarian)
    {

    }

    public override void UpdateState(BarbStateManager barbarian)
    {
        attackOffset = (barb.transform.position.x - barb.GetComponentInChildren<Attack_Point>().transform.position.x) * 1.25f;
        barb.destination = barb.player.transform.localPosition;
        barb.target = barb.destination;
        barb.destination.x += attackOffset;
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
}
