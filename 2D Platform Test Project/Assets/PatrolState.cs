using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    int numWaypoints;
    int currentWaypoint; 

    public PatrolState(AiObject AiObject) : base(AiObject)
    {
        numWaypoints = aiObject.waypoints.Length;
        currentWaypoint = 0;
        aiObject.destination = aiObject.waypoints[currentWaypoint].transform.position;
        aiObject.target = aiObject.destination;
    }

    public override void EnterState()
    {
       
    }

    public override void UpdateState()
    {
        if (aiObject.healthBar.currentHealth <= 0)
        {
          //  barbarian.SwitchState(barbarian.deathState);
            return;
        }
        if (aiObject.aiSight.CanSeePlayer())
        {
           // barbarian.SwitchState(barbarian.goToAttackPosState);
            return;
        }
        if (aiObject.direction.magnitude < 0.35f)
        {
            ChooseNextWaypoint();
        }
    }

    public override void FixedUpdateState()
    {
        aiObject.MoveAI();
    }

    //public override bool CanTransition()
    //{
    //    return false;
    //}

    void ChooseNextWaypoint()
    {
        currentWaypoint++;
        if (currentWaypoint == numWaypoints)
        {
            currentWaypoint = 0;
        }
        aiObject.destination = aiObject.waypoints[currentWaypoint].transform.position;
        aiObject.target = aiObject.destination;
    }


}

