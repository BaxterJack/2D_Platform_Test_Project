using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrocchusClearRaiders : BaseState
{
    Dialogue dialogue;

    public BrocchusClearRaiders(NPC npc) : base(npc)
    {
        string sentence1 = "If you could clear out all the raiders, that'd be great";


        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.HasTabletPuzzle = false;
        dialogue.name = "Aelius Brocchus";


    }


    public override void EnterState()
    {
        npc.AssignDialogue(dialogue);
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }
}
