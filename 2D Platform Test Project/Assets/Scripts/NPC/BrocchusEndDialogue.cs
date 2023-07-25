using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrocchusEndDialogue : BaseState
{

    public BrocchusEndDialogue(NPC npc) : base(npc)
    {
       
    }


    public override void EnterState()
    {
        npc.GetComponent<DialogueTrigger>().enabled = false;
        npc.GetComponent<CircleCollider2D>().enabled = false;
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }
}
