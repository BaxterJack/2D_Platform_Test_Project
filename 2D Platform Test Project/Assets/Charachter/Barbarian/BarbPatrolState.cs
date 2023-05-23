using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbPatrolState : BarbBaseState
{
    //BarbStateManager barb;
  
    int numWaypoints;
    int currentWaypoint;


    //---------------------------------------------------------BarbarianAxeman
    public BarbPatrolState(BarbStateManager barbarian)
    {
        //barb = Barb;
        numWaypoints = barbarian.waypoints.Length;
        currentWaypoint = 0;
        barbarian.destination = barbarian.waypoints[currentWaypoint];
        barbarian.target = barbarian.destination;
        

    }
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
        if (barbarian.aiSight.CanSeePlayer())
        {
            barbarian.SwitchState(barbarian.goToAttackPosState);
            return;
        }
        if (barbarian.direction.magnitude < 0.35f)
        {
            ChooseNextWaypoint(barbarian);
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

    void ChooseNextWaypoint(BarbStateManager barbarian)
    {
        currentWaypoint++;
        if (currentWaypoint == numWaypoints)
        {
            currentWaypoint = 0;
        }
        barbarian.destination = barbarian.waypoints[currentWaypoint];
        barbarian.target = barbarian.destination;
    }


    //---------------------------------------------------------BarbarianBowman

    public BarbPatrolState(BarbBowStateManager barbarianBow)
    {
        numWaypoints = barbarianBow.waypoints.Length;
        currentWaypoint = 0;
        barbarianBow.destination = barbarianBow.waypoints[currentWaypoint];
        barbarianBow.target = barbarianBow.destination;


    }
    public override void EnterState(BarbBowStateManager barbarianBow)
    {

    }

    public override void UpdateState(BarbBowStateManager barbarianBow)
    {
        if (barbarianBow.healthBar.currentHealth <= 0)
        {
            barbarianBow.SwitchState(barbarianBow.deathState);
            return;
        }
        if (barbarianBow.aiSight.CanSeePlayer())
        {
            //barbarianBow.SwitchState(barbarianBow.goToAttackPosState);
            return;
        }
        if (barbarianBow.direction.magnitude < 0.35f)
        {
            ChooseNextWaypoint(barbarianBow);
        }
    }

    public override void FixedUpdateState(BarbBowStateManager barbarianBow)
    {
        MoveAI(barbarianBow);
    }

    void MoveAI(BarbBowStateManager barbarianBow)
    {
        Rigidbody2D rigidbody2D = barbarianBow.GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody2D.velocity;
        Vector2 barbPosition = rigidbody2D.transform.transform.position;
        barbarianBow.direction = (barbPosition - barbarianBow.destination);
        velocity.x = barbarianBow.direction.normalized.x * -barbarianBow.speed;
        rigidbody2D.velocity = velocity;
    }

    void ChooseNextWaypoint(BarbBowStateManager barbarianBow)
    {
        currentWaypoint++;
        if (currentWaypoint == numWaypoints)
        {
            currentWaypoint = 0;
        }
        barbarianBow.destination = barbarianBow.waypoints[currentWaypoint];
        barbarianBow.target = barbarianBow.destination;
    }
}
