using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : BaseState
{
    public GoHome(NPC npc) : base(npc)
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
        npc.MoveNPC(npc.homeWaypoint);
    }
}
