using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestTeachState : BaseState
{
    Dialogue dialogue;

    public PriestTeachState(NPC npc) : base(npc)
    {
        string sentence1 = "You know your stuff about the gods?";
        string sentence2 = "If you ever want to learn more, come back to me and we can talk";


        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.HasTabletPuzzle = false;
        dialogue.name = "Marcus Flavus";


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
