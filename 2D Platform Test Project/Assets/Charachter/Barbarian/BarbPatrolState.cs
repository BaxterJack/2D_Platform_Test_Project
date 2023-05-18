using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbPatrolState : BarbBaseState
{
    BarbStateManager barb;

    Vector2 direction;
    Vector2 destination;
    Vector2 target;
    int numWaypoints;
    int currentWaypoint;

    public BarbPatrolState(BarbStateManager Barb)
    {
        barb = Barb;
        numWaypoints = barb.waypoints.Length;
        currentWaypoint = 0;
        destination = barb.waypoints[currentWaypoint];
        target = destination;
    }
    public override void EnterState(BarbStateManager barbarian)
    {
        
    }

    public override void UpdateState(BarbStateManager barbarian)
    {
        if (direction.magnitude < 0.35f)
        {
            ChooseNextWaypoint();
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
       direction = (barbPosition - destination);
       velocity.x = direction.normalized.x * -barb.speed;
       rigidbody2D.velocity = velocity;
    }

    void ChooseNextWaypoint()
    {
        currentWaypoint++;
        if (currentWaypoint == numWaypoints)
        {
            currentWaypoint = 0;
        }
        destination = barb.waypoints[currentWaypoint];
        target = destination;
    }
}
