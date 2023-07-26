using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaudiaGoToPlayer : BaseState
{
    PlayerManager playerManager;
    public ClaudiaGoToPlayer(NPC npc) : base(npc)
    {
        

    }


    public override void EnterState()
    {
        playerManager = PlayerManager.Instance;
    }

    public override void UpdateState()
    {
        npc.SetDestination();
    }

    public override void FixedUpdateState()
    {
        npc.MoveNPC(npc.destinationWaypoint);
     
    }
}
