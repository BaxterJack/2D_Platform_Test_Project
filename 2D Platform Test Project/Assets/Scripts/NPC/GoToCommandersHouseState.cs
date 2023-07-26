using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCommandersHouseState : BaseState
{
    public GoToCommandersHouseState(NPC npc) : base(npc)
    {
        
    }

    public override void EnterState()
    {
        FortGuide.Instance.SetObjectivecomplete(FortGuide.FortObjective.IntroduceCommander);

    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {
        npc.MoveNPC(npc.homeWaypoint);
    }
}
