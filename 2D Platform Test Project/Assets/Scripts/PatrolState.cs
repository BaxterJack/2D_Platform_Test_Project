using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    int numWaypoints;
    int currentWaypointIndex = 0;

    public PatrolState(AiObject AiObject) : base(AiObject)
    {
        numWaypoints = aiObject.GetNumWaypoints();
        currentWaypointIndex = 0;
        aiObject.SetDestination(aiObject.GetWaypoint(currentWaypointIndex));
        aiObject.SetTarget(aiObject.GetDestination());
    }

    public override void EnterState()
    {
       
    }

    public override void UpdateState()
    {
        aiObject.SetTarget(aiObject.GetDestination());
        aiObject.SetDistanceToDestintion();
        if (aiObject.attackCoolDown >= 0)
        {
            aiObject.attackCoolDown -= Time.deltaTime;
        }
        if (aiObject.GetDistanceToDestintion() < 0.5f)
        {
            ChooseNextWaypoint();
        }
    }

    public override void FixedUpdateState()
    {
        aiObject.MoveAI();
    }


    void ChooseNextWaypoint()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex == numWaypoints)
        {
            currentWaypointIndex = 0;
        }
        aiObject.SetDestination(aiObject.GetWaypoint(currentWaypointIndex));
        aiObject.SetTarget(aiObject.GetDestination());
    }


}

