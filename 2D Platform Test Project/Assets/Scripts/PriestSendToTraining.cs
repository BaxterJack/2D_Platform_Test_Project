using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestSendToTraining : BaseState
{
    Dialogue dialogue;

    public PriestSendToTraining(NPC npc) : base(npc)
    {
        string sentence1 = "Are you the new recruit?";
        string sentence2 = "Shoulnd't you be at the training grounds?";


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
