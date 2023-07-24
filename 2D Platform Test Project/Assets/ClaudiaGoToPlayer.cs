using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaudiaGoToPlayer : BaseState
{
    public ClaudiaGoToPlayer(NPC npc) : base(npc)
    {
        

    }


    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

            npc.MoveNPC();
     
    }
}
