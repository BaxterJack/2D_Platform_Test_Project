using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbPatrolState : BarbBaseState
{
    BarbStateManager barb;
  
    int numWaypoints;
    int currentWaypoint;

    public BarbPatrolState(BarbStateManager Barb)
    {
        barb = Barb;
        numWaypoints = barb.waypoints.Length;
        currentWaypoint = 0;
        barb.destination = barb.waypoints[currentWaypoint];
        barb.target = barb.destination;
    }
    public override void EnterState(BarbStateManager barbarian)
    {
        
    }

    public override void UpdateState(BarbStateManager barbarian)
    {
        if (barb.direction.magnitude < 0.35f)
        {
            ChooseNextWaypoint();
        }
        if(barb.aiSight.CanSeePlayer())
        {
            barb.SwitchState(barb.goToAttackPosState);
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

    void ChooseNextWaypoint()
    {
        currentWaypoint++;
        if (currentWaypoint == numWaypoints)
        {
            currentWaypoint = 0;
        }
        barb.destination = barb.waypoints[currentWaypoint];
        barb.target = barb.destination;
    }
}
