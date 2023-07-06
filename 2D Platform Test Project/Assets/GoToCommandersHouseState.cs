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
        npc.SetHasConversationCompleted(false);
        Debug.Log("Change to go to commanders house");
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {
        npc.MoveNPC();
    }
}
