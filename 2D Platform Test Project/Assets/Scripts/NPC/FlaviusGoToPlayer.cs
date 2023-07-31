using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaviusGoToPlayer : BaseState
{

    PlayerManager playerManager;
    public FlaviusGoToPlayer(NPC npc) : base(npc)
    {


    }


    public override void EnterState()
    {
        playerManager = PlayerManager.Instance;
        AudioManager.Instance.PlaySound("Horn");
    }

    public override void UpdateState()
    {
        npc.SetDestination();
        npc.DistanceToDestination = npc.SetDistance(npc.destinationWaypoint);
    }

    public override void FixedUpdateState()
    {
        npc.MoveNPC(npc.destinationWaypoint);

    }
}
