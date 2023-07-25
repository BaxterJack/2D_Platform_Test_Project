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
        Vector3 playerPos = playerManager.transform.position;
        float offset = 0.5f;
        playerPos.x += offset;
        npc.homeWaypoint = playerPos;
    }

    public override void FixedUpdateState()
    {
        npc.MoveNPC();
     
    }
}
