using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrocchusIntroduceClaudia : BaseState
{
    Dialogue dialogue;

    public BrocchusIntroduceClaudia(NPC npc) : base(npc)
    {
        string sentence1 = "Oh, and this here is my wife.";

        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.HasTabletPuzzle = false;
        dialogue.ForcedDialogue = true;
        dialogue.name = "Aelius Brocchus";
    }


    public override void EnterState()
    {
        npc.AssignDialogue(dialogue);

        AeliusBrocchus brocchus = (AeliusBrocchus)npc;
        brocchus.SpawnClaudia();
        //npc.GetComponent<DialogueTrigger>().enabled = false;
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }
}
